using Microsoft.AspNetCore.Mvc;
using Assignment4_WebApiCRUD.Models;

namespace Assignment4_WebApiCRUD.Controllers;

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
            Salary = 50000,
            Permanent = true
        },

        new Employee
        {
            Id = 2,
            Name = "Rahul",
            Department = "HR",
            Salary = 45000,
            Permanent = false
        },

        new Employee
        {
            Id = 3,
            Name = "Akshay",
            Department = "Finance",
            Salary = 60000,
            Permanent = true
        }
    ];

    // GET ALL

    [HttpGet]

    public ActionResult<List<Employee>> GetEmployees()
    {
        return Ok(employees);
    }

    // GET BY ID

    [HttpGet("{id}")]

    public ActionResult<Employee> GetEmployee(int id)
    {
        var employee = employees.FirstOrDefault(e => e.Id == id);

        if (employee == null)
            return NotFound();

        return Ok(employee);
    }

    // POST

    [HttpPost]

    public ActionResult<Employee> AddEmployee([FromBody] Employee employee)
    {
        employees.Add(employee);

        return CreatedAtAction(
            nameof(GetEmployee),
            new { id = employee.Id },
            employee);
    }

    // PUT

    [HttpPut("{id}")]

    public ActionResult<Employee> UpdateEmployee(
        int id,
        [FromBody] Employee employee)
    {
        if (id <= 0)
        {
            return BadRequest("Invalid employee id");
        }

        var existingEmployee =
            employees.FirstOrDefault(e => e.Id == id);

        if (existingEmployee == null)
        {
            return BadRequest("Invalid employee id");
        }

        existingEmployee.Name = employee.Name;
        existingEmployee.Department = employee.Department;
        existingEmployee.Salary = employee.Salary;
        existingEmployee.Permanent = employee.Permanent;

        return Ok(existingEmployee);
    }

    // DELETE

    [HttpDelete("{id}")]

    public IActionResult DeleteEmployee(int id)
    {
        var employee = employees.FirstOrDefault(e => e.Id == id);

        if (employee == null)
        {
            return BadRequest("Invalid employee id");
        }

        employees.Remove(employee);

        return Ok("Employee deleted successfully");
    }
}