CREATE DATABASE Accounting

CREATE TABLE Countries(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] nvarchar(10) NOT NULL
)
CREATE TABLE Addresses(
Id INT PRIMARY KEY IDENTITY(1,1),
StreetName nvarchar(20) NOT NULL,
StreetNumber int  NULL,
PostCode int NOT NULL,
City nvarchar(25) NOT NULL,
CountryId INT FOREIGN KEY REFERENCES Countries(Id)
)
CREATE TABLE Vendors(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] nvarchar(25) NOT NULL,
NumberVAT nvarchar(15) NOT NULL,
AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)
CREATE TABLE Clients(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] nvarchar(25) NOT NULL,
NumberVAT nvarchar(15) NOT NULL,
AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)
CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] nvarchar(10) NOT NULL
)
CREATE TABLE Products(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] nvarchar(35) NOT NULL,
Price decimal(18,2) NOT NULL,
CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
VendorId INT FOREIGN KEY REFERENCES Vendors(Id)
)
CREATE TABLE Invoices(
Id INT PRIMARY KEY IDENTITY(1,1),
Number  int UNIQUE NOT NULL,
IssueDate DATETIME2 NOT NULL,
DueDate DATETIME2 NOT NULL,
Amount decimal(18,2) NOT NULL,
Currency nvarchar(5) NOT NULL,
ClientId INT FOREIGN KEY REFERENCES Clients(Id)
)
CREATE TABLE ProductsClients(
ClientId INT FOREIGN KEY REFERENCES Clients(Id),
ProductId INT FOREIGN KEY REFERENCES Products(Id),
PRIMARY KEY(ClientId,ProductId)
)

INSERT INTO Products ([Name],Price,CategoryId,VendorId)
VALUES 
('SCANIA Oil Filter XD01',78.69,1,1),
('MAN Air Filter XD01',97.38,1,5),
('DAF Light Bulb 05FG87',55.00,2,13),
('ADR Shoes 47-47.5',49.85,3,5),
('Anti-slip pads S',5.87,5,7)

INSERT INTO Invoices (Number,IssueDate,DueDate,Amount,Currency,ClientId)
VALUES 
(1219992181,'2023-03-01','2023-04-30',180.96,'BGN',3),
(1729252340,'2022-11-06','2023-01-04',158.18,'EUR',13),
(1950101013,'2023-02-17','2023-04-18',615.15,'USD',19)


UPDATE Invoices
SET DueDate='2023-04-01'
WHERE MONTH(IssueDate)=11 AND YEAR(IssueDate)=2022

UPDATE Clients
SET AddressId=3
WHERE [Name] like '%CO%'

DELETE
FROM ProductsClients
WHERE ClientId IN(11,30)
DELETE 
FROM Invoices
where  ClientId in (11,30)
DELETE 
FROM Clients
where  Id in (11)

SELECT Number,Currency
from Invoices
ORDER BY Amount DESC, DueDate ASC

SELECT p.Id,p.[Name],Price,c.[Name]
from Products as p
JOIN Categories as c
ON p.CategoryId=c.Id
where c.[Name]='ADR' OR c.[Name]='Others'
ORDER BY Price DESC

SELECT c.Id,c.[Name],
CONCAT(a.StreetName,' ',a.StreetNumber,', ',a.City,', ',a.PostCode,', ',co.Name) as 'Address'
from Clients as c
JOIN Addresses as a
ON c.AddressId=a.Id
JOIN Countries as co
ON a.CountryId=co.Id
left JOIN ProductsClients as pc
ON pc.ClientId=c.Id
WHERE ProductId is null

select *
from Addresses
