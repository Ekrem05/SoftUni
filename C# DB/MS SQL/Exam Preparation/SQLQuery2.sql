INSERT INTO Boardgames ([Name], YearPublished, Rating,CategoryId,PublisherId,PlayersRangeId) VALUES
('Deep Blue', 2019,5.67,1,15,7),
('Paris', 2016,9.78,7,1,5),
('Catan: Starfarers', 2021,9.87,7,13,6),
('Bleeding Kansas', 2020,3.25,3,7,4),
('One Small Step', 2019,5.75,5,9,2)

INSERT INTO Publishers([Name], AddressId,Website,Phone) VALUES
('Agman Games', 5,'www.agmangames.com','+16546135542'),
('Amethyst Games', 7,'www.amethystgames.com','+15558889992'),
('BattleBooks', 13,'www.battlebooks.com','+12345678907')

UPDATE PlayersRanges
SET PlayersMax+=1
WHERE PlayersMax=2 and PlayersMin=2

Update Boardgames
Set [Name]+='V2'
Where YearPublished>=2020

DELETE
from CreatorsBoardgames
Where BoardgameId in(1,16,31,47,52)

DELETE
from Boardgames
Where PublisherId in(1,16)
Delete
from Publishers
WHERE AddressId=5
DELETE
FROM Addresses
WHERE LEFT(Town,1)='L'

SELECT [NAME],Rating
from Boardgames
ORDER BY YearPublished ASC, [NAME] DESC

SELECT b.Id,b.[NAME],YearPublished,c.[Name]
from Boardgames as b
JOIN Categories AS c
ON b.CategoryId=c.Id
WHERE c.[Name]='Strategy Games' Or c.[Name]='Wargames'
ORDER BY YearPublished DESC

Select Id,CONCAT(FirstName,' ',LastName)AS CreatorName, Email
from Creators as c
LEFT JOIN CreatorsBoardgames as cb
On c.Id=cb.CreatorId
Where BoardgameId is NULL

SELECT TOP 5 b.[Name],Rating,c.[Name]
from Boardgames as b
join Categories as c
ON b.CategoryId=c.Id
JOIN PlayersRanges as pr
On b.PlayersRangeId=pr.Id
Where Rating>7.00 and b.[Name] like '%a%' or Rating>7.5 and PlayersMin=2 and PlayersMax=5
ORDER BY b.[Name] asc, Rating desc

SELECT CONCAT_WS(' ',[FirstName],LastName)as FullName, Email, MAX(Rating)
from Creators as c
JOIN CreatorsBoardgames AS cb
ON c.Id=cb.CreatorId
JOIN Boardgames as b
ON cb.BoardgameId=b.Id
Where Right(Email,4)='.com'
GROUP BY FirstName,LastName,Email
ORDER BY FullName ASC

SELECT c.LastName,Ceiling(AVG(Rating)) as AverageRating,p.[Name]
from Creators as c
JOIN CreatorsBoardgames AS cb
ON c.Id=cb.CreatorId
JOIN Boardgames as b
ON cb.BoardgameId=b.Id
JOIN Publishers AS p
ON b.PublisherId=p.Id
Where p.[Name]='Stonemaier Games'
GROUP BY c.LastName, p.Name
Order by AVG(Rating) desc



Create Function udf_CreatorWithBoardgames(@name nvarchar(50))
RETURNS INT
	as
	BEGIN
		DECLARE @result INT= (
		Select Count(*)
		from Creators AS c
		JOIN CreatorsBoardgames as cb
		ON c.Id=cb.CreatorId
		WHERE c.FirstName=@name
		)
		RETURN @result
	END

CREATE PROCEDURE usp_SearchByCategory(@category nvarchar(30))
	AS
	 SELECT b.[Name],YearPublished,Rating,c.[Name] AS CategoryName,p.[Name] as PublisherName
	 ,Concat(PlayersMin,' people') as MinPlayers,Concat(PlayersMax,' people')as MaxPlayers
	 FROM Boardgames as b
	 JOin Categories as c
	 ON b.CategoryId=c.Id
	 JOin PlayersRanges as pr
	 on b.PlayersRangeId=pr.Id
	 Join Publishers as p
	 ON b.PublisherId=p.Id
	 WHERE c.Name=@category
	 ORDER BY PublisherName asc, YearPublished desc

	 EXEC usp_SearchByCategory 'Wargames'