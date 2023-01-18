namespace PresidioAcademy.Domain.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Role { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Asset> Assets { get; } = new List<Asset>();
}
