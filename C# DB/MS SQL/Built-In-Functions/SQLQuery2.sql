
Select FirstName,LastName
from Employees
Where YEAR(HireDate)>2000

Select FirstName,LastName
from Employees
Where DATALENGTH(LastName)=5

Select EmployeeID, FirstName,LastName, Salary, DENSE_RANK() OVER( PARTITION BY Salary ORDER BY EmployeeID asc) as 'Rank'
from Employees
Where Salary BETWEEN 10000 AND 50000
Order by
Salary
desc

