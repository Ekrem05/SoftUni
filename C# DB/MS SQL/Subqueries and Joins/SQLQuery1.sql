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

