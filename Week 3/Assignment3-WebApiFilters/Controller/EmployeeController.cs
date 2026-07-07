using Microsoft.AspNetCore.Mvc;

using Assignment3_WebApiFilters.Models;

using Assignment3_WebApiFilters.Filters;

namespace Assignment3_WebApiFilters.Controllers;


[ApiController]

[Route("api/[controller]")]

[CustomAuthFilter]

public class EmployeeController : ControllerBase
{

    private List<Employee>

        GetStandardEmployeeList()

    {

        return
        [

            new Employee
            {

                Id = 1,

                Name = "Swaraj",

                Salary = 50000,

                Permanent = true,

                Department =
                new Department
                {

                    Id = 1,

                    Name = "IT"

                },

                Skills =
                [

                    new Skill
                    {

                        Id = 1,

                        Name = "C#"

                    },

                    new Skill
                    {

                        Id = 2,

                        Name = ".NET"

                    }

                ],

                DateOfBirth =

                    new DateTime(

                        2003,

                        4,

                        10)

            }

        ];

    }


    [HttpGet]


    [ProducesResponseType(

        StatusCodes.Status200OK)]


    [ProducesResponseType(

        StatusCodes.Status500InternalServerError)]


    public ActionResult<List<Employee>>

        Get()

    {

        return Ok(

            GetStandardEmployeeList());

    }

}