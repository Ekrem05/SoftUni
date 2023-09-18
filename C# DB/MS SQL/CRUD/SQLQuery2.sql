Select *
from Departments

Select Name 
from Departments

Select  FirstName, LastName,Salary
from Employees

Select FirstName, MiddleName, LastName
from Employees

Select Concat(FirstName,'.',LastName,'@softuni.bg') as 'Full Email Address'
from Employees

Select DISTINCT  Salary 
from Employees

Select *
from Employees
Where JobTitle = 'Sales Representative'

Select FirstName, LastName, JobTitle
from Employees
Where Salary>=20000 and Salary<=30000

Select Concat(FirstName,' ', MiddleName, ' ',LastName)
from Employees
Where Salary=25000 or Salary='14000' or Salary='12500 'or Salary='23600'

Select FirstName, LastName
from Employees
Where ManagerID is Null

Select FirstName, LastName, Salary
from Employees
Where Salary>=50000
Order by Salary DESC

Select TOP 5 FirstName, LastName
from Employees
Order by Salary Desc

Select FirstName, LastName 
from Employees
Where DepartmentID !=4

Select *
from Employees
ORDER BY Salary DESC, FirstName ASC, LastName DESC, MiddleName ASC;

CREATE VIEW V_EmployeesSalaries as 
Select FirstName, LastName, Salary
from Employees

CREATE VIEW V_EmployeeNameJobTitle as 
Select CONCAT_WS(' ',FirstName,MiddleName,LastName) as 'Full Name', JobTitle AS 'Job Title'
from Employees


Select Distinct JobTitle
from Employees

Select TOP 10 *
from Projects
Order by StartDate ASC,NAME ASC

Select TOP 7 FirstName, LastName, HireDate
from Employees
Order by HireDate Desc

Update Employees
Set Salary-=Salary*0.12
Where DepartmentID=1 or DepartmentID=2 or DepartmentID=11

Select PeakName
from Peaks
Order By PeakName