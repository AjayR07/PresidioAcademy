using PresidioAcademy.Application.Interfaces;
using PresidioAcademy.Domain.Models;
namespace PresidioAcademy.Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    
    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
   
    }
    public IEnumerable<Employee> GetAllEmployees()
    {
        return _employeeRepository.GetAll();
    }

    public Employee? GetEmployeeById(int id)
    {
        return _employeeRepository.Get(id);
    }

    public void AddNewEmployee(Employee employee)
    {
        employee.Password = BCrypt.Net.BCrypt.HashPassword(employee.Password);
        _employeeRepository.Add(employee);
    }

    public void RemoveEmployee(int id)
    {
        var employee = GetEmployeeById(id);
        if (employee != null)
        {
            _employeeRepository.Delete(employee);
        }
    }

    public void UpdateEmployee(Employee employee)
    {
        employee.Password = BCrypt.Net.BCrypt.HashPassword(employee.Password);
        _employeeRepository.Update(employee);
    }
    
}