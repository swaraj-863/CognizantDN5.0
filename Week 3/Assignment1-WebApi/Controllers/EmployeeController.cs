using Microsoft.AspNetCore.Mvc;

using Assignment1_WebApi.Models;

namespace Assignment1_WebApi.Controllers
{

    [ApiController]

    [Route("api/[controller]")]

    public class EmployeeController : ControllerBase
    {

        private static List<Employee> employees =
            new List<Employee>()
            {

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
                    Salary=40000,
                    Permanent=false
                }

            };



        [HttpGet]

        public IActionResult GetEmployees()
        {
            return Ok(employees);
        }



        [HttpGet("{id}")]

        public IActionResult GetEmployee(int id)
        {

            var employee =
                employees.FirstOrDefault(e => e.Id == id);


            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);

        }



        [HttpPost]

        public IActionResult AddEmployee(Employee employee)
        {

            employees.Add(employee);

            return Ok(employee);

        }



        [HttpPut("{id}")]

        public IActionResult UpdateEmployee
        (
            int id,
            Employee emp
        )

        {

            var employee =
                employees.FirstOrDefault
                (
                    e => e.Id == id
                );

            if (employee == null)
            {
                return BadRequest
                (
                    "Employee Not Found"
                );
            }

            employee.Name = emp.Name;

            employee.Department = emp.Department;

            employee.Salary = emp.Salary;

            employee.Permanent = emp.Permanent;

            return Ok(employee);

        }



        [HttpDelete("{id}")]

        public IActionResult DeleteEmployee(int id)

        {

            var employee =
                employees.FirstOrDefault
                (
                    e => e.Id == id
                );

            if (employee == null)
            {
                return BadRequest
                (
                    "Employee Not Found"
                );
            }

            employees.Remove(employee);

            return Ok
            (
                "Employee Deleted Successfully"
            );

        }

    }

}