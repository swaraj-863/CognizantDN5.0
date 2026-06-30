CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY IDENTITY(1,1),
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Salary DECIMAL(10,2)
);

INSERT INTO Employees (FirstName, LastName, Salary) VALUES
('John', 'Peter', 50000),
('Alice', 'Mary', 60000);

CREATE FUNCTION fn_CalculateAnnualSalary
(
    @EmployeeID INT
)
RETURNS DECIMAL(10,2)
AS
BEGIN
    DECLARE @AnnualSalary DECIMAL(10,2);

    SELECT @AnnualSalary = Salary * 12
    FROM Employees
    WHERE EmployeeID = @EmployeeID;

    RETURN @AnnualSalary;
END;
GO

-- Exercise 7: Return Data from Scalar Function
SELECT dbo.fn_CalculateAnnualSalary(1) AS AnnualSalary;