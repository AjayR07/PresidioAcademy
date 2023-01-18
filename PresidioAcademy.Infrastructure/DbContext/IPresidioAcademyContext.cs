using Microsoft.EntityFrameworkCore;
using PresidioAcademy.Domain.Models;

namespace PresidioAcademy.Infrastructure.DbContext;

public interface IPresidioAcademyContext
{
    DbSet<Asset> Assets { get; set; }

    DbSet<Employee> Employees { get; set; }
}