namespace Assignment4_WebApiCRUD.Models;

public class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public string Department { get; set; } = "";

    public decimal Salary { get; set; }

    public bool Permanent { get; set; }
}