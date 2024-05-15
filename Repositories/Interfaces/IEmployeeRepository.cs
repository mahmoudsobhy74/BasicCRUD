using BasicCRUD.Models.Entities;

namespace BasicCRUD.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllAsync();
        Task<Employee> GetByIdAsync(Guid id);
        Task<Employee> AddAsync(Employee employeeRequest);
        Task<Employee> UpdateAsync(Guid id, Employee updateEmployeeRequest);
        Task<Employee> DeleteAsync(Guid id);
    }
}
