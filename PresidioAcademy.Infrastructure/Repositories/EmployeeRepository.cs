using PresidioAcademy.Application.Interfaces;
using PresidioAcademy.Domain.Models;
using PresidioAcademy.Infrastructure.DbContext;

namespace PresidioAcademy.Infrastructure.Repositories;

public class EmployeeRepository: GenericRepository<Employee>, IEmployeeRepository
{
    private readonly PresidioAcademyContext _context;

    public EmployeeRepository(PresidioAcademyContext context) : base(context)
    {
        _context = context;
    }
    
}