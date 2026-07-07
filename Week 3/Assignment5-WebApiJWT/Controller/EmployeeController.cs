using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Assignment5_WebApiJWT.Models;

namespace Assignment5_WebApiJWT.Controllers;

[ApiController]

[Route("api/[controller]")]

[Authorize]

public class EmployeeController : ControllerBase
{
    private static List<Employee> employees =
    [
        new Employee
        {
            Id=1,
            Name="Swaraj",
            Department="IT",
            Salary=50000,
            Permanent=true
        },

        new Employee
        {
            Id=2,
            Name="Rahul",
            Department="HR",
            Salary=45000,
            Permanent=false
        },

        new Employee
        {
            Id=3,
            Name="Akshay",
            Department="Finance",
            Salary=60000,
            Permanent=true
        }
    ];

    [HttpGet]

    public ActionResult<List<Employee>>
        GetEmployees()
    {
        return Ok(employees);
    }

    [HttpGet("{id}")]

    public ActionResult<Employee>
        GetEmployee(int id)
    {
        var employee =
            employees.FirstOrDefault(
                e=>e.Id==id);

        if(employee==null)
            return NotFound();

        return Ok(employee);
    }
}