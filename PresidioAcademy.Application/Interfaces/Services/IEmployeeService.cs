using System.Text.Json.Nodes;
using PresidioAcademy.Domain.Models;

namespace PresidioAcademy.Application.Interfaces;

public interface IEmployeeService
{
    IEnumerable<Employee> GetAllEmployees();

    Employee? GetEmployeeById(int id);

    void AddNewEmployee(Employee employee);

    void RemoveEmployee(int id);

    void UpdateEmployee(Employee employee);
}