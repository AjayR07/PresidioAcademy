using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresidioAcademy.Application.Interfaces;
using PresidioAcademy.Domain.Models;

namespace PresidioAcademy.API.Controllers;
[ApiController]
[Authorize]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    [Route("all")]
    public ActionResult<Employee> GetAll()
    {
        var employees = _employeeService.GetAllEmployees();
        return Ok(employees);
    }
    
    [HttpGet]
    public ActionResult<Employee > Get(int id)
    {
        var employees = _employeeService.GetEmployeeById(id);
        return Ok(employees);
    }

    [HttpPost]
    public ActionResult<Employee> AddEmployee(Employee employee)
    {
        _employeeService.AddNewEmployee(employee);
        return employee;
    }
    
    [HttpDelete]
    public ActionResult<string> DeleteAsset(int id)
    {
        _employeeService.RemoveEmployee(id);
        return Ok("Deleted Successfully");
    }

    [HttpPut]
    public ActionResult<string> UpdateAsset(Employee employee)
    {
        _employeeService.UpdateEmployee(employee);
        return Ok("Updated Successfully");
    }
}