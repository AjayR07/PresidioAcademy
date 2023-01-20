using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresidioAcademy.Application.DTO;
using PresidioAcademy.Application.Interfaces;
using PresidioAcademy.Domain.Models;

namespace PresidioAcademy.API.Controllers;
[ApiController]
// [Authorize]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;
    private readonly IMapper _mapper;

    public EmployeeController(IEmployeeService employeeService,IMapper mapper)
    {
        _employeeService = employeeService;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("all")]
    public ActionResult<List<Employee>> GetAll()
    {
        var employees = _employeeService.GetAllEmployees();
        List<EmployeeDTO> result = new List<EmployeeDTO>();
        foreach (var employee in employees)
        {
            var employeeDto =_mapper.Map<EmployeeDTO>(employee);
            result.Add(employeeDto);
        }
        return Ok(result);
    }
    
    [HttpGet]
    public ActionResult<Employee > Get(int id)
    {
        var employee = _employeeService.GetEmployeeById(id);
        var result = _mapper.Map<EmployeeDTO>(employee);
        return Ok(result);
    }

    [HttpPost]
    public ActionResult<Employee> AddEmployee(Employee employee)
    {
        _employeeService.AddNewEmployee(employee);
        return employee;
    }
    
    [HttpDelete]
    public ActionResult DeleteAsset(int id)
    {
        _employeeService.RemoveEmployee(id);
        return Ok();
    }

    [HttpPut]
    public ActionResult UpdateAsset(Employee employee)
    {
        _employeeService.UpdateEmployee(employee);
        return Ok();
    }
}