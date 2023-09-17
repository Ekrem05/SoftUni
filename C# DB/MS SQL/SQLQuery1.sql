CREATE TABLE [Towns](
Id int primary key,
[Name] nvarchar(60)
)
CREATE TABLE [Minions](
Id int primary key,
[Name] nvarchar(60),
[Age] int
)
Alter table [Minions]
ADD [TownId] INT foreign key References [Towns]([id])NOT NULL

INSERT INTO[Towns]
Values (1,'Sofia'),
(2,'Plovdiv'),
(3,'Varna')

INSERT INTO[Minions]
Values (1,'Kevin',22,1),
(2,'Bob',15,3),
(3,'Steward',Null,2)

Truncate Table [Minions]
drop table [Minions],[Towns]

create table [People](
[Id] int primary key identity(1,1),
[Name] nvarchar(200) Not null,
[Picture] image null,
[Height] decimal(3,2)null,
[Weight] decimal(5,2)null,
[Gender] char(1) Not null,
[Birthdate] date Not null,
[Biography] text null,
)
INSERT INTO[People]([Name],[Height],[Weight],[Gender],Birthdate)
Values ('Kevin',1.32,64.33,'M','12/12/2022'),
('Kevin',1.42,84.33,'M','12/12/2022'),
('Kevin',1.52,344.33,'W','12/12/2022'),
('Kevin',1.62,124.33,'M','12/12/2022'),
('Kevin',1.72,34.33,'W','12/12/2022')