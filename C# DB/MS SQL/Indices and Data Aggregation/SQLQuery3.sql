Select DepartmentID, Sum(Salary) as TotalSalary
from Employees
Group by DepartmentID

Select DepartmentID, MIN(Salary) as MinimumSalary
from Employees
Where DepartmentID=2 or DepartmentID=5 or DepartmentID=7 and HireDate>'01.01.2000'
Group by DepartmentID

Select * into EmployeesNew
from Employees
Where Salary>30000

DELETE 
from EmployeesNew
Where ManagerID=42

Update EmployeesNew
Set Salary=Salary+5000
Where DepartmentID=1

Select DepartmentID, AVG(Salary) as AverageSalary
from EmployeesNew
Group by DepartmentID

Select DepartmentID, MAX(Salary) as MaxSalary
from Employees
GROUP BY DepartmentID
Having Max(Salary) not between 30000 and 70000

Select Count(*) as Count
from Employees
Where ManagerID is null