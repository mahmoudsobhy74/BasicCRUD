using BasicCRUD.Data;
using BasicCRUD.Models.Entities;
using BasicCRUD.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BasicCRUD.Repositories;

public class EmployeeRepository : IEmployeeRepository
{

    private readonly EmployeeDbContext _context;

    public EmployeeRepository(EmployeeDbContext context)
    {
        _context = context;
    }

    public async Task<List<Employee>> GetAllAsync()
    {
        var employees = await _context.Employees.ToListAsync();
        return (employees);
    }

    public async Task<Employee> GetByIdAsync(Guid id)
    {
        var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id)?? null;
 
        return (employee);
    }


    public async Task<Employee> AddAsync(Employee employeeRequest)
    {

        employeeRequest.Id = Guid.NewGuid();
        await _context.Employees.AddAsync(employeeRequest);
        await _context.SaveChangesAsync();

        return employeeRequest;

    }

    public async Task<Employee> UpdateAsync(Guid id, Employee updateEmployeeRequest)
    {
        var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id)?? null;

        if (employee != null)
        {

            employee.Name = updateEmployeeRequest.Name;
            employee.Email = updateEmployeeRequest.Email;
            employee.Salary = updateEmployeeRequest.Salary;
            employee.Phone = updateEmployeeRequest.Phone;
            employee.Department = updateEmployeeRequest.Department;

            await _context.SaveChangesAsync();
        }
            return employee;
       
    }

    public async Task<Employee> DeleteAsync(Guid id)
    {

        var employee = await _context.Employees.FindAsync(id)?? null;

        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();

        return employee;
    }

    public void Dispose()
    {
        _context?.Dispose();
    }

}

