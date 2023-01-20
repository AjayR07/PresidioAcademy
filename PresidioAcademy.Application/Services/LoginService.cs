using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PresidioAcademy.Application.DTO;
using PresidioAcademy.Application.Interfaces;
using PresidioAcademy.Domain.Models;

namespace PresidioAcademy.Application.Services;

public class LoginService: ILoginService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IConfiguration _configuration;
    private readonly IMemoryCache _memoryCache;

    public LoginService(IEmployeeRepository employeeRepository,IConfiguration configuration, IMemoryCache memoryCache)
    {
        _employeeRepository = employeeRepository;
        _configuration = configuration;
        _memoryCache = memoryCache;
    }
    public TokenDTO Authenticate(LoginDTO loginDto)
    {
 
        var cacheOutput = _memoryCache.Get<LoginCache>(loginDto.EmployeeId);
        if (cacheOutput is not null)
        {
            if (BCrypt.Net.BCrypt.Verify(loginDto.Password, cacheOutput.Password))
            {
                return cacheOutput.Token;
            }
        }
            
        var employee = _employeeRepository.Get(loginDto.EmployeeId);
        if (employee != null)
        {
            if (BCrypt.Net.BCrypt.Verify(loginDto.Password, employee.Password))
            {
               
                var cache = new LoginCache()
                {
                    Password = employee.Password, 
                    Token = new TokenDTO()
                    {
                        Token = GenerateToken(employee)
                    }
                };
                
                // Set cache options
                var cacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(10));
                // Set object in cache
                _memoryCache.Set(loginDto.EmployeeId,cache);
                return cache.Token;
            }
            else
            {
                // throw Invalid password
                return null;
            }
        }
        else
        {
            //throw Invalid Employee ID
            return null;
        }
      
    }

    private string GenerateToken(Employee employee)
    {
        //Generate JSON Web Token
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, employee.Name)
            }),
            Expires = DateTime.UtcNow.AddMinutes(10),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}

class LoginCache
{
    public string Password { get; set; }
    
    public TokenDTO Token { get; set; }
}