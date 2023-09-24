Select FirstName, LastName
from Employees
Where FirstName like 'Sa_%'

Select FirstName, LastName
from Employees
Where LastName like '%_ei_%'

Select FirstName
from Employees
Where DepartmentID=3 or DepartmentID=10 and YEAR(HireDate)>1995 and YEAR(HireDate)<2005
