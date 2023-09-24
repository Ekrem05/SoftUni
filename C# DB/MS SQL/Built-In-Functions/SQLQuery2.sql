
Select FirstName,LastName
from Employees
Where YEAR(HireDate)>2000

Select FirstName,LastName
from Employees
Where DATALENGTH(LastName)=5