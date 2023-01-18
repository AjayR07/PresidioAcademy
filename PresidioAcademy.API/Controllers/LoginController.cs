using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresidioAcademy.Application.DTO;
using PresidioAcademy.Application.Interfaces;

namespace PresidioAcademy.API.Controllers;

[ApiController]
[Authorize]
[Route("api/login")]
public class LoginController:ControllerBase
{
    private readonly ILoginService _loginService;

    public LoginController(ILoginService loginService)
    {
        _loginService = loginService;
    }

    [AllowAnonymous]
    [HttpPost]
    public TokenDTO Authenticate(LoginDTO loginDto)
    {
        return _loginService.Authenticate(loginDto);
    }
}