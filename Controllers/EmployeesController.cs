using BasicCRUD.Data;
using BasicCRUD.Models.Entities;
using BasicCRUD.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasicCRUD.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : Controller
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeesController(IEmployeeRepository employeeRepository)
    {

        _employeeRepository = employeeRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllEmployees()
    {
        var employees = await _employeeRepository.GetAllAsync();

        if (employees == null)
        {
            return NotFound();
        }
        return Ok(employees);
    }


    [HttpGet]
    [Route("{id:Guid}")]
    public async Task<IActionResult> GetEmployeeById([FromRoute] Guid id)
    {
        var employee = await _employeeRepository.GetByIdAsync(id);

        if (employee == null)
        {
            return NotFound();
        }

        return Ok(employee);
    }

    [HttpPost]
    public async Task<IActionResult> AddEmployee([FromBody] Employee employeeRequest)
    {
        var employee = await _employeeRepository.AddAsync(employeeRequest);

        if (employee == null)
        {
            return BadRequest("Failed");
        }
        else
            return Ok(employee);
    }

    [HttpPut]
    [Route("{id:Guid}")]
    public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, Employee updateEmployeeRequest)
    {
        var employee = await _employeeRepository.UpdateAsync(id, updateEmployeeRequest);

        if (employee == null)
        {
            return BadRequest("Failed");
        }
        else
        return Ok(employee);
    }


    [HttpDelete]
    [Route("{id:Guid}")]
    public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
    {
        var employee = await _employeeRepository.DeleteAsync(id);

        if (employee == null)
        {
            return BadRequest("Failed");
        }
        else
        return Ok(employee.Id);
    }

}
