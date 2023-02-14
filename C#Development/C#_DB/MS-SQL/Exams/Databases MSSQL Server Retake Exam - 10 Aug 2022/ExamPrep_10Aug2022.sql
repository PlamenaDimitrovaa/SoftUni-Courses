CREATE DATABASE NationalTouristSitesOfBulgaria
USE NationalTouristSitesOfBulgaria

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Locations
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	Municipality VARCHAR(50),
	Province VARCHAR(50)
)

CREATE TABLE Sites
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL,
	LocationId INT NOT NULL REFERENCES Locations(Id),
	CategoryId INT NOT NULL REFERENCES Categories(Id),
	Establishment VARCHAR(15)
)

CREATE TABLE Tourists
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	Age INT NOT NULL CHECK(Age BETWEEN 0 AND 120),
	PhoneNumber VARCHAR(20) NOT NULL,
	Nationality VARCHAR(30) NOT NULL,
	Reward VARCHAR(20)
)

CREATE TABLE SitesTourists
(
	TouristId INT NOT NULL REFERENCES Tourists(Id),
	SiteId INT NOT NULL REFERENCES Sites(Id)

	CONSTRAINT PK_TouristSite PRIMARY KEY(TouristId, SiteId)
)

CREATE TABLE BonusPrizes
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE TouristsBonusPrizes
(
	TouristId INT NOT NULL REFERENCES Tourists(Id),
	BonusPrizeId INT NOT NULL REFERENCES BonusPrizes(Id)

	CONSTRAINT PK_TouristBonusPrize PRIMARY KEY(TouristId, BonusPrizeId)
)

INSERT INTO Tourists ([Name], Age, PhoneNumber, Nationality, Reward)
	VALUES
('Borislava Kazakova',	52,	'+359896354244',	'Bulgaria',	NULL),
('Peter Bosh',	48,	'+447911844141',	'UK',	NULL),
('Martin Smith',	29,	'+353863818592',	'Ireland',	'Bronze badge'),
('Svilen Dobrev',	49,	'+359986584786',	'Bulgaria',	'Silver badge'),
('Kremena Popova',	38,	'+359893298604',	'Bulgaria',	NULL)

INSERT INTO Sites ([Name], LocationId, CategoryId, Establishment)
	VALUES
('Ustra fortress',	90,	7,	'X'),
('Karlanovo Pyramids',	65,	7,	NULL),
('The Tomb of Tsar Sevt',	63,	8,	'V BC'),
('Sinite Kamani Natural Park',	17,	1,	NULL),
('St. Petka of Bulgaria – Rupite',	92,	6,	'1994')

UPDATE Sites 
	SET Establishment = 'not defined'
		WHERE Establishment IS NULL

DELETE FROM TouristsBonusPrizes
	WHERE BonusPrizeId = 5
DELETE FROM BonusPrizes
	WHERE [Name] = 'Sleeping bag'

SELECT [Name], Age, PhoneNumber, Nationality FROM Tourists
	ORDER BY Nationality, Age DESC, [Name]

SELECT s.[Name], l.[Name], Establishment, c.[Name] FROM Sites AS s
	JOIN Locations AS l ON l.Id = s.LocationId
	JOIN Categories AS c ON c.Id = s.CategoryId
	ORDER BY c.[Name] DESC, l.[Name], s.[Name]

SELECT l.Province, l.Municipality, l.[Name] AS 'Location', COUNT(s.Id) AS CountOfSites 
	FROM Locations AS l
	JOIN Sites AS s ON s.LocationId = l.Id
	WHERE Province = 'Sofia'
	GROUP BY l.Province, l.Municipality, l.Name
	ORDER BY CountOfSites DESC, l.[Name] ASC

SELECT s.[Name], l.[Name], l.Municipality, l.Province, s.Establishment
	FROM Sites AS s 
	JOIN Locations AS l ON s.LocationId = l.Id
	WHERE LEFT(l.[Name], 1) NOT LIKE '[B, M, D]' AND Establishment LIKE '%BC'
	ORDER BY s.[Name]

SELECT t.[Name], t.Age, t.PhoneNumber, t.Nationality, ISNULL(bp.[Name], '(no bonus prize)') 
	FROM Tourists AS t
	LEFT JOIN TouristsBonusPrizes AS tbp ON tbp.TouristId = t.Id
	LEFT JOIN BonusPrizes AS bp ON bp.Id = tbp.BonusPrizeId
	ORDER BY t.[Name]

SELECT DISTINCT SUBSTRING(t.[Name], CHARINDEX(' ', t.[Name]) + 1, LEN(t.[Name])) AS 'LastName'
	,t.Nationality
	, t.Age
	, t.PhoneNumber
	FROM Tourists AS t 
	JOIN SitesTourists AS st ON st.TouristId = t.Id
	JOIN Sites AS s ON s.Id = st.SiteId
	JOIN Categories AS c ON c.Id = s.CategoryId
	WHERE c.[Name] = 'History and archaeology'
	ORDER BY LastName

CREATE FUNCTION udf_GetTouristsCountOnATouristSite (@Site VARCHAR(100)) 
RETURNS INT
AS
BEGIN
	DECLARE @Result INT = (SELECT COUNT(t.Id) FROM Tourists AS t
											JOIN SitesTourists AS st ON st.TouristId = t.Id
											JOIN Sites AS s ON s.Id = st.SiteId
											WHERE s.[Name] = @Site)
    RETURN @Result
END

CREATE PROC usp_AnnualRewardLottery(@TouristName VARCHAR(50))
AS
BEGIN
IF (SELECT COUNT(s.Id) FROM Sites AS s
			JOIN SitesTourists AS st ON s.Id = st.SiteId
			JOIN Tourists AS t ON st.TouristId = t.Id
			WHERE t.Name = @TouristName) >= 100
	BEGIN 
			UPDATE Tourists
			SET	Reward = 'Gold badge'
			WHERE Name = @TouristName
	END
ELSE IF (SELECT COUNT(s.Id) FROM Sites AS s
			JOIN SitesTourists AS st ON s.Id = st.SiteId
			JOIN Tourists AS t ON st.TouristId = t.Id
			WHERE t.Name = @TouristName) >= 50
	BEGIN 
			UPDATE Tourists
			SET	Reward = 'Silver badge'
			WHERE Name = @TouristName
	END
ELSE IF (SELECT COUNT(s.Id) FROM Sites AS s
			JOIN SitesTourists AS st ON s.Id = st.SiteId
			JOIN Tourists AS t ON st.TouristId = t.Id
			WHERE t.Name = @TouristName) >= 25
	BEGIN 
			UPDATE Tourists
			SET	Reward = 'Bronze badge'
			WHERE Name = @TouristName
	END
SELECT Name, Reward FROM Tourists
WHERE Name = @TouristName
END