Select FirstName, LastName
from Employees
Where FirstName like 'Sa_%'

Select FirstName, LastName
from Employees
Where LastName like '%_ei_%'

Select FirstName
from Employees
Where DepartmentID=3 or DepartmentID=10 and YEAR(HireDate)>1995 and YEAR(HireDate)<2005

Select FirstName,LastName,UPPER(JobTitle)
from Employees
Where UPPER(JobTitle) not like'%ENGINEER%'

Select [Name]
from Towns
Where DATALENGTH([Name])=5 or DATALENGTH([Name])=6
Order by [Name]

Select TownID, [Name]
from Towns
WHERE [Name] LIKE 'M%' OR [Name] LIKE 'K%' OR [Name] LIKE 'B%' OR [Name] LIKE 'E%'
Order by [Name]


Select TownID, [Name]
from Towns
WHERE [Name] not LIKE 'R%' and [Name] not LIKE 'D%' and [Name] not LIKE 'B%' 
Order by [Name]