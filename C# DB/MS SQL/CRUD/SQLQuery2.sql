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