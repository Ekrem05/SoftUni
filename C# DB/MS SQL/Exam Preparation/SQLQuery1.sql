CREATE DATABASE Boardgames


Create TABLE Categories(
Id INT PRIMARY KEY IDENTITY(1,1),
Name varchar(50) NOT NULL,

)

Create TABLE Addresses(
Id INT PRIMARY KEY IDENTITY(1,1),
StreetName varchar(100) NOT NULL,
StreetNumber Int NOT NULL,
Town varchar(30) NOT NULL,
Country varchar(50) NOT NULL,
ZIP INT NOT NULL,
)
Create TABLE Publishers(
Id INT PRIMARY KEY IDENTITY(1,1),
Name varchar(30) UNIQUE NOT NULL,
AddressId INT Foreign KEY REFERENCES Addresses(Id),
Website varchar(40) NULL,
Phone varchar(20)  NULL,
)

Create TABLE PlayersRanges(
Id INT PRIMARY KEY IDENTITY(1,1),
PlayersMin int NOT NULL,
PlayersMax int NOT NULL,

)

Create TABLE Boardgames(
Id INT PRIMARY KEY IDENTITY(1,1),
Name nvarchar(30)  NOT NULL,
YearPublished int NOT NULL,
Rating DECIMAL(4,2) NOT NULL,
CategoryId INT Foreign Key References Categories(Id),
PublisherId INT Foreign Key References Publishers(Id),
PlayersRangeId INT Foreign Key References PlayersRanges(Id),
)

Create TABLE Creators(
Id INT PRIMARY KEY IDENTITY(1,1),
FirstName nvarchar(30)  NOT NULL,
LastName nvarchar(30)  NOT NULL,
Email nvarchar(30)  NOT NULL,

)
Create TABLE CreatorsBoardgames(
CreatorId INT Foreign Key References Creators(Id),
BoardgameId INT Foreign Key References Boardgames(Id),
PRIMARY KEY(CreatorId,BoardgameId)
)
