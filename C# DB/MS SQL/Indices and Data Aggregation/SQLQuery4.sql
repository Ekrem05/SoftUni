CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000()
AS
	Select FirstName as [First Name], LastName as [Last Name]
	from Employees
	Where Salary>35000