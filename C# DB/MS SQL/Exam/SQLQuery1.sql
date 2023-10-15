CREATE TABLE Countries(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] nvarchar(50) NOT NULL
)
CREATE TABLE Destinations(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] nvarchar(50) NOT NULL,
CountryId INT FOREIGN KEY REFERENCES Countries(Id)
)
CREATE TABLE Rooms(
Id INT PRIMARY KEY IDENTITY(1,1),
Type nvarchar(40) NOT NULL,
Price DECIMAL(18,2) NOT NULL,
BedCount INT NOT NULL CHECK (BedCount > 0 AND BedCount <= 10)
)
CREATE TABLE Hotels(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] nvarchar(50) NOT NULL,
DestinationId INT FOREIGN KEY REFERENCES Destinations(Id)
)
CREATE TABLE Tourists(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] nvarchar(80) NOT NULL,
PhoneNumber nvarchar(20) NOT NULL,
Email nvarchar(80) NULL,
CountryId INT FOREIGN KEY REFERENCES Countries(Id)
)
CREATE TABLE Bookings(
Id INT PRIMARY KEY IDENTITY(1,1),
ArrivalDate DATETIME2 NOT NULL,
DepartureDate DATETIME2 NOT NULL,
AdultsCount INT NOT NULL CHECK (AdultsCount >= 1 AND AdultsCount <= 10),
ChildrenCount INT NOT NULL CHECK (ChildrenCount >= 0 AND ChildrenCount <= 9),
TouristId INT FOREIGN KEY REFERENCES Tourists(Id),
HotelId INT FOREIGN KEY REFERENCES Hotels(Id),
RoomId INT FOREIGN KEY REFERENCES Rooms(Id)
)
CREATE TABLE HotelsRooms(
HotelId INT FOREIGN KEY REFERENCES Hotels(Id),
RoomId INT FOREIGN KEY REFERENCES Rooms(Id),
PRIMARY KEY(HotelId,RoomId)
)

INSERT INTO Tourists ( [Name], PhoneNumber, Email,CountryId) VALUES
('John Rivers', '653-551-1555', 'john.rivers@example.com', 6),
('Adeline Aglaé', '122-654-8726', 'adeline.aglae@example.com', 2),
('Sergio Ramirez', '233-465-2876', 's.ramirez@example.com', 3),
('Johan Müller', '322-876-9826', 'j.muller@example.com', 7),
('Eden Smith', '551-874-2234', 'eden.smith@example.com', 6)

INSERT INTO Bookings ( ArrivalDate, DepartureDate, AdultsCount,ChildrenCount,TouristId,HotelId,RoomId) VALUES
('2024-03-01', '2024-03-11', 1,0,21,3,5),
('2023-12-28', '2024-01-06', 2,1,22,13,3),
('2023-11-15', '2023-11-20', 1,2,23,19,7),
('2023-12-05', '2023-12-09', 4,0,24,6,4),
('2024-05-01', '2024-05-07', 6,0,25,14,6)


UPDATE Bookings
SET DepartureDate = DATEADD(DAY, 1, DepartureDate)
WHERE MONTH(DepartureDate)=12 AND YEAR(DepartureDate)=2023

UPDATE Tourists
SET Email = NULL
Where [Name] like '%MA%'


select Id
from Tourists
Where RIGHT([Name],6) =' Smith' 
--6 16 25

SELECT Id
FROM Bookings
Where TouristId in (6,16,25)
--16 17 18 50

DELETE 
FROM Bookings
Where Id in(16,17,18,50)

DELETE 
FROM Tourists
Where Id in (6,16,25)

SELECT FORMAT(ArrivalDate,'yyyy-MM-dd' ),
AdultsCount,ChildrenCount
FROM Bookings AS b
join Rooms AS r
ON b.RoomId=r.Id
ORDER BY Price DESC, ArrivalDate ASC

SELECT h.Id,[Name]
From Hotels as h
JOIN Bookings as b
ON h.Id=b.HotelId
JOIN HotelsRooms as hr
ON h.Id=hr.HotelId
Where hr.RoomId=8
GROUP BY
    h.Id, h.Name
ORDER BY
    COUNT(*) DESC;

SELECT  t.Id,[Name],PhoneNumber
from Tourists as t
LEFT JOIN Bookings as b
ON t.Id=b.TouristId
Where TouristId is NUll
ORDER BY [Name] asc

SELECT TOP 10 h.[Name],d.[Name],c.[Name]
from Hotels as h
JOIN Destinations as d
ON h.DestinationId=d.Id
JOIN Countries as c
ON d.CountryId=c.Id
JOIN Bookings as b
ON b.HotelId=h.Id
Where b.ArrivalDate<'2023-12-31' and h.Id % 2 = 1
ORDER BY c.[Name],ArrivalDate

SELECT  h.[Name],r.Price
from Tourists as t
 JOIN Bookings as b
ON b.TouristId=t.Id
 JOIN Hotels as h
ON h.Id=b.HotelId
 JOIN Rooms as r
ON b.RoomId=r.Id
WHERE Right(t.[Name],2)!='EZ'
ORDER BY r.Price DESC

SELECT *
FROM Bookings
Where HotelId=7

Select h.[Name], 
Sum(DATEDIFF(DAY, DAY(ArrivalDate),DAY(DepartureDate))*r.Price)as HotelRevenue
FROM Hotels as h
JOIN Bookings as b ON h.Id=b.HotelId
JOIN Rooms as r ON b.RoomId=r.Id
GROUP BY h.[Name]
ORDER BY HotelRevenue desc




CREATE FUNCTION udf_RoomsWithTourists(@name VARCHAR(50))
RETURNS INT
	BEGIN 
	DECLARE @result INT;

		SET @result=(
			SELECT SUM(AdultsCount+ChildrenCount)
			FROM Bookings AS b
			JOIN Rooms AS r ON b.RoomId=r.Id
			WHERE r.[Type]=@name
			)


	RETURN @result
	END
SELECT dbo.udf_RoomsWithTourists('Double Room')


CREATE PROCEDURE usp_SearchByCountry(@country VARCHAR(30))
	as
		SELECT t.[Name],t.PhoneNumber,Email, Count(b.Id) as CountOfBookings
		from Tourists as t
		JOIN Countries as c ON t.CountryId=c.Id
		JOIN Bookings AS b ON b.TouristId=t.Id
		Where c.Name=@country
		GROUP BY t.[Name],t.PhoneNumber,Email

	
EXEC usp_SearchByCountry 'Greece'
