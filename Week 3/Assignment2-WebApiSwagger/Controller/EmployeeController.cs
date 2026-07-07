using Microsoft.AspNetCore.Mvc;

using Assignment2_WebApiSwagger.Models;

namespace Assignment2_WebApiSwagger.Controllers;

[ApiController]

[Route("api/[controller]")]

public class EmployeeController : ControllerBase
{

    private static List<Employee> employees =
    [
        new Employee
        {
            Id = 1,
            Name = "Swaraj",
            Department = "IT",
            Salary = 50000
        },

        new Employee
        {
            Id = 2,
            Name = "Rahul",
            Department = "HR",
            Salary = 45000
        }
    ];


    [HttpGet]

    [ProducesResponseType(StatusCodes.Status200OK)]

    public ActionResult<List<Employee>> GetEmployees()
    {
        return Ok(employees);
    }


    [HttpGet("{id}")]

    public IActionResult GetEmployee(int id)
    {

        var emp = employees.FirstOrDefault(

            x => x.Id == id);

        if (emp == null)

            return NotFound();

        return Ok(emp);

    }


    [HttpPost]

    public IActionResult AddEmployee(

        Employee employee)

    {

        employees.Add(employee);

        return CreatedAtAction(

            nameof(GetEmployee),

            new { id = employee.Id },

            employee);

    }

}