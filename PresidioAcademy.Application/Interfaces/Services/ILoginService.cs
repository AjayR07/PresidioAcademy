using PresidioAcademy.Application.DTO;

namespace PresidioAcademy.Application.Interfaces;

public interface ILoginService
{
    TokenDTO Authenticate(LoginDTO loginDto);
}