using PresidioAcademy.Domain.Models;

namespace PresidioAcademy.Application.DTO;

public class EmployeeDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Role { get; set; }
}