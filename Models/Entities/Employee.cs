using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicCRUD.Models.Entities;

public class Employee
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(100)]
    public string Name { get; set; }

    [Required]
    [StringLength(100)]
    public string Email { get; set; }

    [Required]
    public long Phone { get; set; }

    [Required]
    public long Salary { get; set; }

    [Required]
    [StringLength(100)]
    public string Department { get; set; }

}
