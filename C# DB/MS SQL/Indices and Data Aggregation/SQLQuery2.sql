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