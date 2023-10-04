Select top 5 EmployeeID,JobTitle,a.AddressID,AddressText
from Employees as e
join Addresses as a
On e.AddressID=a.AddressID
order by e.AddressID asc

Select top 50 FirstName,LastName,[Name]as Town,AddressText
from Employees as e
join Addresses as a
On e.AddressID=a.AddressID
join Towns as t
on a.TownID=t.TownID
order by e.FirstName asc, LastName asc



Select EmployeeID,FirstName,LastName,d.Name as DepartmentName
from Employees as e
Join Departments as d
on e.DepartmentID=d.DepartmentID
Where d.Name='Sales'
Order by EmployeeID asc

Select top 5 EmployeeID,FirstName,Salary,d.Name as DepartmentName
from Employees as e
Join Departments as d
on e.DepartmentID=d.DepartmentID
Where e.Salary>15000
Order by e.DepartmentID asc

Select top 3 e.EmployeeID,FirstName
from Employees as e
Where e.EmployeeID not in(Select EmployeeID from EmployeesProjects)
Order by e.EmployeeID asc

Select FirstName,LastName,HireDate,d.[Name] as DeptName
from Employees as e
Join Departments as d
on e.DepartmentID=d.DepartmentID
Where e.HireDate>'1/1/1999' AND d.[Name]='Sales' or d.[Name]='Finance'
Order by e.HireDate asc

Select top 5 e.EmployeeID,FirstName,p.[Name] as ProjectName
from Employees as e
Join EmployeesProjects as ep
on e.EmployeeID=ep.EmployeeID
join Projects as p
on ep.ProjectID=p.ProjectID
Where p.StartDate>'2002-08-13' and p.endDate is null 
Order by EmployeeID asc