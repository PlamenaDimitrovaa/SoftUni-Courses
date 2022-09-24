--CREATE DATABASE ColonialJourney

--USE ColonialJourney

--CREATE TABLE Planets
--(
--	Id INT PRIMARY KEY IDENTITY,
--	[Name] VARCHAR(30) NOT NULL,
--)

--CREATE TABLE Spaceports
--(
--	Id INT PRIMARY KEY IDENTITY,
--	[Name] VARCHAR(50) NOT NULL,
--	PlanetId INT NOT NULL REFERENCES Planets(Id)
--)

--CREATE TABLE Spaceships
--(
--	Id INT PRIMARY KEY IDENTITY,
--	[Name] VARCHAR(50) NOT NULL,
--	Manufacturer VARCHAR(30) NOT NULL,
--	LightSpeedRate INT DEFAULT 0
--)

--CREATE TABLE Colonists
--(
--	Id INT PRIMARY KEY IDENTITY,
--	FirstName VARCHAR(20) NOT NULL,
--	LastName VARCHAR(20) NOT NULL,
--	Ucn VARCHAR(10) UNIQUE NOT NULL,
--	BirthDate DATE NOT NULL
--)

--CREATE TABLE Journeys
--(
--	Id INT PRIMARY KEY IDENTITY,
--	JourneyStart DATETIME NOT NULL,
--	JourneyEnd DATETIME NOT NULL,
--	Purpose VARCHAR(11) CHECK(Purpose IN ('Medical', 'Technical', 'Educational', 'Military')),
--	DestinationSpaceportId INT NOT NULL REFERENCES Spaceports(Id),
--	SpaceshipId INT NOT NULL REFERENCES Spaceships(Id)
--)

--CREATE TABLE TravelCards
--(
--	Id INT PRIMARY KEY IDENTITY,
--	CardNumber VARCHAR(10) CHECK(LEN(CardNumber) = 10) UNIQUE NOT NULL,
--	JobDuringJourney VARCHAR(8) CHECK(JobDuringJourney IN ('Pilot', 'Engineer', 'Trooper', 'Cleaner', 'Cook')),
--	ColonistId INT NOT NULL REFERENCES Colonists(Id),
--	JourneyId INT NOT NULL REFERENCES Journeys(Id)
--)

--INSERT INTO Planets ([Name]) VALUES 
--('Mars'),
--('Earth'),
--('Jupiter'),
--('Saturn')

--INSERT INTO Spaceships ([Name], Manufacturer, LightSpeedRate) VALUES
--('Golf',	'VW',	3),
--('WakaWaka',	'Wakanda',	4),
--('Falcon9',	'SpaceX',	1),
--('Bed',	'Vidolov',	6)

--UPDATE Spaceships 
--	SET LightSpeedRate += 1
--	WHERE Id BETWEEN 8 AND 12

--DELETE FROM TravelCards WHERE JourneyId IN (1,2,3)
--DELETE FROM Journeys WHERE Id IN (1,2,3)

--SELECT Id, FORMAT(JourneyStart, 'dd/MM/yyyy') AS JourneyStart, FORMAT(JourneyEnd, 'dd/MM/yyyy') AS JourneyEnd
--	FROM Journeys
--	WHERE Purpose = 'Military'
--	ORDER BY JourneyStart

--SELECT c.Id, FirstName + ' ' + LastName AS FullName
--	FROM Colonists c
--	JOIN TravelCards tc ON c.Id = tc.ColonistId
--	WHERE JobDuringJourney = 'Pilot'
--	ORDER BY c.Id, FullName

--SELECT COUNT(c.Id) AS [count]
--	FROM Colonists c
--	JOIN TravelCards tc ON tc.ColonistId = c.Id
--	JOIN Journeys j ON j.Id = tc.JourneyId
--	WHERE Purpose = 'Technical'

--SELECT s.[Name], s.Manufacturer
--	FROM Colonists c
--	JOIN TravelCards tc ON tc.ColonistId = c.Id
--	JOIN Journeys j ON j.Id = tc.JourneyId
--	JOIN Spaceships s ON s.Id = j.SpaceshipId
--	WHERE JobDuringJourney = 'Pilot' AND DATEDIFF(YEAR, c.BirthDate, '01/01/2019') < 30
--	GROUP BY s.[Name], s.Manufacturer
--	ORDER BY s.[Name]

--SELECT p.[Name], COUNT(j.Id) AS JourneysCount
--	FROM Planets p 
--	JOIN Spaceports s ON s.PlanetId = p.Id
--	JOIN Journeys j ON s.Id = j.DestinationSpaceportId
--	GROUP BY p.[Name]
--	ORDER BY JourneysCount DESC, p.[Name]

--SELECT * FROM (SELECT t.JobDuringJourney,
--	c.[FirstName] + ' ' + c.LastName AS FullName,
--	DENSE_RANK() OVER (PARTITION BY t.JobDuringJourney ORDER BY c.BirthDate) AS [JobRank]
--	FROM Colonists c
--	JOIN TravelCards t ON t.ColonistId = c.Id) AS Ranked
--	WHERE JobRank = 2

--CREATE FUNCTION dbo.udf_GetColonistsCount(@PlanetName VARCHAR (30))
--RETURNS INT
--AS
--BEGIN
--	RETURN (SELECT COUNT(*)
--		    FROM Colonists c
--			JOIN TravelCards tc ON c.Id = tc.ColonistId
--			JOIN Journeys j ON tc.JourneyId = j.Id
--			JOIN Spaceports s ON j.DestinationSpaceportId = s.Id
--			JOIN Planets p ON s.PlanetId = p.Id
--			WHERE p.[Name] = @PlanetName)
--END

--CREATE PROC usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(30))
--AS
--BEGIN
--	IF (SELECT Id FROM Journeys WHERE Id = @JourneyId) IS NULL
--		THROW 50001, 'The journey does not exist!', 1;
	
--	IF(SELECT Purpose FROM Journeys WHERE Id = @JourneyId) = @NewPurpose
--		THROW 50002, 'You cannot change the purpose!', 1;

--	UPDATE Journeys
--		SET Purpose = @NewPurpose
--			WHERE Id = @JourneyId
--END