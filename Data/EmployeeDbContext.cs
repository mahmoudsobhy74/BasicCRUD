using BasicCRUD.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BasicCRUD.Data;

public class EmployeeDbContext : DbContext
{
    public EmployeeDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
}
