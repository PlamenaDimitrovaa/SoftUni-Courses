CREATE DATABASE Boardgames
USE Boardgames

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY,
	StreetName NVARCHAR(100) NOT NULL,
	StreetNumber INT NOT NULL,
	Town VARCHAR(30) NOT NULL,
	Country VARCHAR(50) NOT NULL,
	ZIP INT NOT NULL
)

CREATE TABLE Publishers
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) UNIQUE NOT NULL,
	AddressId INT NOT NULL REFERENCES Addresses(Id),
	Website NVARCHAR(40),
	Phone NVARCHAR(20)
)

CREATE TABLE PlayersRanges
(
	Id INT PRIMARY KEY IDENTITY,
	PlayersMin INT NOT NULL,
	PlayersMax INT NOT NULL
)

CREATE TABLE Boardgames
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	YearPublished INT NOT NULL,
	Rating DECIMAL(18, 2) NOT NULL,
	CategoryId INT NOT NULL REFERENCES Categories(Id),
	PublisherId INT NOT NULL REFERENCES Publishers(Id),
	PlayersRangeId INT NOT NULL REFERENCES PlayersRanges(Id)
)

CREATE TABLE Creators
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Email NVARCHAR(30) NOT NULL
)

CREATE TABLE CreatorsBoardgames
(
	CreatorId INT NOT NULL REFERENCES Creators(Id),
	BoardgameId INT NOT NULL REFERENCES Boardgames(Id)

	CONSTRAINT PK_CreatorBoardgame PRIMARY KEY (CreatorId, BoardgameId)
)

INSERT INTO Boardgames ([Name],	YearPublished,	Rating,	CategoryId,	PublisherId,	PlayersRangeId)
VALUES
('Deep Blue',	2019,	5.67,	1,	15,	7),
('Paris',	2016,	9.78,	7,	1,	5),
('Catan: Starfarers',	2021,	9.87,	7,	13,	6),
('Bleeding Kansas',	2020,	3.25,	3,	7,	4),
('One Small Step',	2019,	5.75,	5,	9,	2)

INSERT INTO Publishers ([Name],	AddressId,	Website,	Phone)
VALUES
('Agman Games',	5,	'www.agmangames.com',	'+16546135542'),
('Amethyst Games',	7,	'www.amethystgames.com',	'+15558889992'),
('BattleBooks',	13,	'www.battlebooks.com',	'+12345678907')

UPDATE PlayersRanges
	SET PlayersMax += 1
		WHERE Id = 1
UPDATE Boardgames
	SET Name = CONCAT(Name, 'V2')
		WHERE YearPublished >= 2020

DELETE FROM CreatorsBoardgames
	WHERE BoardgameId IN (SELECT Id 
		FROM Boardgames b
		WHERE PublisherId IN (1, 16))
DELETE FROM Boardgames
	WHERE PublisherId IN (1, 16)
DELETE FROM Publishers
	WHERE Id IN (SELECT p.Id 
		FROM Publishers p
		JOIN Addresses a ON a.Id = p.AddressId
		WHERE Town LIKE 'L%')
DELETE FROM Addresses
	WHERE Town LIKE 'L%'

SELECT [Name], Rating FROM Boardgames
	ORDER BY YearPublished ASC, [Name] DESC

SELECT b.Id, b.[Name], YearPublished, c.[Name] AS CategoryName
	FROM Boardgames AS b 
	LEFT JOIN Categories AS c ON c.Id = b.CategoryId
	WHERE c.[Name] IN ('Strategy Games', 'Wargames')
	ORDER BY YearPublished DESC

SELECT c.Id, c.FirstName + ' ' + c.LastName AS CreatorName, Email
	FROM Creators AS c
	WHERE Id IN (5, 7)
	ORDER BY CreatorName

SELECT TOP 5 b.[Name], Rating, c.[Name] AS CategoryName
	FROM Boardgames AS b 
	JOIN PlayersRanges AS pr ON pr.Id = b.PlayersRangeId
	JOIN Categories AS c ON c.Id = b.CategoryId
	WHERE (Rating > 7.00 AND CHARINDEX('a', b.[Name]) > 0) OR 
		(Rating > 7.50 AND pr.Id = 4)
	ORDER BY b.[Name], Rating DESC

SELECT c.FirstName + ' ' + c.LastName AS FullName, Email, MAX(Rating) AS Rating
	FROM Creators AS c 
	JOIN CreatorsBoardgames AS cb ON cb.CreatorId = c.Id
	JOIN Boardgames AS b ON b.Id = cb.BoardgameId
	WHERE Email LIKE '%.com'
	GROUP BY c.FirstName + ' ' + c.LastName, Email
	ORDER BY FullName

SELECT c.LastName, CEILING(AVG(b.Rating)) AS AverageRating,
	p.Name AS PublisherName
	FROM Creators c
	LEFT JOIN CreatorsBoardgames cb ON cb.CreatorId = c.Id
	LEFT JOIN Boardgames b ON b.Id = cb.BoardgameId
	LEFT JOIN Publishers p ON p.Id = b.PublisherId
	WHERE p.Name = 'Stonemaier Games'
	GROUP BY c.LastName, p.Name
	ORDER BY AVG(b.Rating) DESC

CREATE FUNCTION udf_CreatorWithBoardgames(@name VARCHAR(50))
RETURNS INT
AS
BEGIN
	DECLARE @Result INT = (SELECT COUNT(*) FROM Boardgames AS b
											JOIN CreatorsBoardgames AS cb ON cb.BoardgameId = b.Id
											JOIN Creators AS c ON c.Id = cb.CreatorId
											WHERE @name = c.FirstName)
		RETURN @Result
END


CREATE PROCEDURE usp_SearchByCategory(@category VARCHAR(50))
AS
BEGIN
	SELECT b.[Name], YearPublished, Rating, c.[Name] AS CategoryName, 
		p.[Name] AS PublisherName, 
		CONCAT(PlayersMin, ' people') AS MinPlayers, 
		CONCAT(PlayersMax, ' people') AS MaxPlayers
		FROM Boardgames AS b 
		JOIN Categories AS c ON c.Id = b.CategoryId
		JOIN Publishers AS p ON p.Id = b.PublisherId
		JOIN PlayersRanges AS pr ON pr.Id = b.PlayersRangeId
		WHERE c.Name = @category
		ORDER BY p.[Name], YearPublished DESC
END

EXEC usp_SearchByCategory 'Wargames'
