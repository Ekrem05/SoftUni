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
		`
    RETURN @result
	END
	
SELECT Salary,dbo.ufn_GetSalaryLevel(Salary)
from Employees


Create procedure usp_EmployeesBySalaryLevel(@level varchar(10))
	as 
		Select FirstName,LastName
		from Employees
		Where dbo.ufn_GetSalaryLevel(Salary)=@level

		Exec usp_EmployeesBySalaryLevel 'High'


Create FUNCTION ufn_IsWordComprised(@setOfLetters varchar(100), @word varchar(20))
	RETURNS BIT
	AS
	BEGIN
		DECLARE @i INT=1
		WHILE(@i<=LEN(@word))
		BEGIN
			DECLARE @letter char=SUBSTRING(@word,@i,1)
			IF(CHARINDEX(@letter,@setOfLetters)=0)
				RETURN 0
			ELSE
			SET @i+=1
		END
		RETURN 1
	END

	Select dbo.ufn_IsWordComprised ('HELLO','HELLO')


	Create Procedure usp_DeleteEmployeesFromDepartment(@departmentId INT)
	AS 
	DELETE Employees
	WHERE DepartmentID=@departmentId
	Delete Departments
	WHERE DepartmentID=@departmentId
	SELECT COUNT(*)
	from Employees
	Where DepartmentID=@departmentId

