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

