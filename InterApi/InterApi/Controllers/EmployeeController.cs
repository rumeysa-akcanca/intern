using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace InterApi.Controllers;


public class Employee
{
    [Required]
    [StringLength(maximumLength: 250, MinimumLength = 10, ErrorMessage ="Invalid Name")]
    public string Name { get; set; }

    [EmailAddress(ErrorMessage = "Email address is not valid.")]
    public string Email { get; set; }

    [Phone(ErrorMessage = "Phone is not valid.")]
    public string Phone { get; set; }

    [Range(minimum: 30, maximum: 400, ErrorMessage = "Hourly salary does not fall within allowed range.")]
    public decimal HourlySalary { get; set; }
}

[ApiController]
[Route("interapi/v1.0/[controller]")]
public class EmployeeController : ControllerBase
{
    public EmployeeController()
    {
    }

    [HttpPost]
    public string Post([FromBody] Employee request)
    {
        return DateTime.UtcNow.ToString();
    }




}
