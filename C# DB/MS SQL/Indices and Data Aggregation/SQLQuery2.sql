Select max(MagicWandSize) as LongestMagicWand
from WizzardDeposits

Select DepositGroup, max(MagicWandSize) as LongestMagicWand
FROM WizzardDeposits
Group by DepositGroup

Select top 2 DepositGroup
FROM WizzardDeposits
Group by DepositGroup
ORDER by AVG(MagicWandSize) ASC

SELECT DepositGroup, SUM(DepositAmount) as TotalSum
FROM WizzardDeposits
Group by DepositGroup


SELECT DepositGroup, SUM(DepositAmount) as TotalSum
FROM WizzardDeposits
Where MagicWandCreator='Ollivander family'
Group by DepositGroup

SELECT DepositGroup, SUM(DepositAmount) as TotalSum
FROM WizzardDeposits
Where MagicWandCreator='Ollivander family'
Group by DepositGroup
Having Sum(DepositAmount)<150000
Order BY Sum(DepositAmount) Desc

SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) as MinDepositCharge
FROM WizzardDeposits
Group by DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup

SELECT AgeGroups, Count(*) as [WizzardCount] FROM(
	SELECT Age,
		Case
		WHEN Age between 0 and 10 then '[0-10]'
		WHEN Age between 11 and 20 then '[11-20]'
		WHEN Age between 21 and 30 then '[21-30]'
		WHEN Age between 31 and 40 then '[31-40]'
		WHEN Age between 41 and 50 then '[41-50]'
		WHEN Age between 51 and 60 then '[51-60]'
		ELSE '[61+]'
		END as AgeGroups
	FROM WizzardDeposits) AS ASD
Group by AgeGroups

Select  LEFT(FirstName,1) as FirstLetter 
from WizzardDeposits
WHERE DepositGroup='Troll Chest'
Group by LEFT(FirstName,1)


Select DepositGroup,IsDepositExpired,AVG(DepositInterest) as AverageInterest
from WizzardDeposits
WHERE DepositStartDate>'01/01/1985'
GROUP BY DepositGroup,IsDepositExpired
ORDER BY DepositGroup desc

