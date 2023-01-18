using System.ComponentModel.DataAnnotations;

namespace PresidioAcademy.Application.DTO;

public class LoginDTO
{
    [Required]
    public int EmployeeId { get; set; }
    
    [Required]
    [MinLength(8,ErrorMessage = "Password must have atleast 8 characters")]
    [MaxLength(16,ErrorMessage = "Password length must be between 8 and 16")]
    public string Password { get; set; }
}