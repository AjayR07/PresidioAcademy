using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PresidioAcademy.Application.DTO;
using PresidioAcademy.Application.Interfaces;

namespace PresidioAcademy.Application.Services;

public class LoginService: ILoginService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IConfiguration _configuration;

    public LoginService(IEmployeeRepository employeeRepository,IConfiguration configuration)
    {
        _employeeRepository = employeeRepository;
        _configuration = configuration;
    }
    public TokenDTO Authenticate(LoginDTO loginDto)
    {
        var employee = _employeeRepository.Get(loginDto.EmployeeId);
        if (employee != null)
        {
            if (BCrypt.Net.BCrypt.Verify(loginDto.Password, employee.Password))
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
                return new TokenDTO { Token = tokenHandler.WriteToken(token) };
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
}