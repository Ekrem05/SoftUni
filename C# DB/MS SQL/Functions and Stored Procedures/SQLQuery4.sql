CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS
	Select FirstName, LastName
	from Employees
	Where Salary>35000
	
GO

EXEC usp_GetEmployeesSalaryAbove35000

CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber(@number Decimal(18,4))
AS
	Select FirstName, LastName
	from Employees
	Where Salary>=@number
	
GO
EXEC usp_GetEmployeesSalaryAboveNumber 48100

CREATE OR ALTER PROCEDURE usp_GetTownsStartingWith @letter nvarchar(50)

AS
	Select	[Name] as Town
	from Towns
	Where [Name] like CONCAT(@letter,'%')
	
GO
EXEC usp_GetTownsStartingWith 'B'


CREATE Procedure usp_GetEmployeesFromTown @townName nvarchar(50)

AS
	Select FirstName, LastName
	from Employees as e
	JOIN Addresses as a
	On e.AddressID=a.AddressID
	JOIN Towns as t
	On a.TownID=t.TownID
	Where t.Name= @townName

EXEC usp_GetEmployeesFromTown 'Berlin'

CREATE function ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS varchar(10)
	AS
	Begin
		DECLARE @result varchar(10)
		IF @salary < 30000
        SET @result = 'Low'
    ELSE IF @salary >= 30000 AND @salary <= 50000
        SET @result = 'Average'
    ELSE
        SET @result = 'High'

    RETURN @result
	END
	