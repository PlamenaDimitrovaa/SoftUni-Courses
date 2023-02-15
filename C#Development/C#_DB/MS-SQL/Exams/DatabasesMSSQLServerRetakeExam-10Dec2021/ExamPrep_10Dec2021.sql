CREATE DATABASE Airport
USE Airport

CREATE TABLE Passengers
(
	Id INT PRIMARY KEY IDENTITY,
	FullName VARCHAR(100) UNIQUE NOT NULL,
	Email VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Pilots
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30) UNIQUE NOT NULL,
	LastName VARCHAR(30) UNIQUE NOT NULL,
	Age TINYINT NOT NULL CHECK(Age BETWEEN 21 AND 62),
	Rating FLOAT CHECK(Rating BETWEEN 0.0 AND 10.0)
)

CREATE TABLE AircraftTypes
(
	Id INT PRIMARY KEY IDENTITY,
	TypeName VARCHAR(30) UNIQUE NOT NULL
)

CREATE TABLE Aircraft
(
	Id INT PRIMARY KEY IDENTITY,
	Manufacturer VARCHAR(25) NOT NULL,
	Model VARCHAR(30) NOT NULL,
	[Year] INT NOT NULL,
	FlightHours INT,
	Condition CHAR(1) NOT NULL,
	TypeId INT NOT NULL REFERENCES AircraftTypes(Id)
)

CREATE TABLE PilotsAircraft
(
	AircraftId INT NOT NULL REFERENCES Aircraft(Id),
	PilotId INT NOT NULL REFERENCES Pilots(Id)

	CONSTRAINT PK_AircraftPilots PRIMARY KEY (AircraftId, PilotId)
)

CREATE TABLE Airports
(
	Id INT PRIMARY KEY IDENTITY,
	AirportName VARCHAR(70) UNIQUE NOT NULL,
	Country VARCHAR(100) UNIQUE NOT NULL
)

CREATE TABLE FlightDestinations
(
	Id INT PRIMARY KEY IDENTITY,
	AirportId INT NOT NULL REFERENCES Airports(Id),
	[Start] DATETIME NOT NULL,
	AircraftId INT NOT NULL REFERENCES Aircraft(Id),
	PassengerId INT NOT NULL REFERENCES Passengers(Id),
	TicketPrice DECIMAL(18,2) NOT NULL DEFAULT(15)
)

INSERT INTO Passengers (FullName, Email)
	VALUES
('Krystal Cuckson',	'KrystalCuckson@gmail.com'),
('Susy Borrel',	'SusyBorrel@gmail.com'),
('Saxon Veldman',	'SaxonVeldman@gmail.com'),
('Lenore Romera',	'LenoreRomera@gmail.com'),
('Enrichetta Jeremiah',	'EnrichettaJeremiah@gmail.com'),
('Delaney Stove',	'DelaneyStove@gmail.com'),
('Ilaire Tomaszewicz',	'IlaireTomaszewicz@gmail.com'),
('Genna Jaquet',	'GennaJaquet@gmail.com'),
('Carlotta Dykas',	'CarlottaDykas@gmail.com'),
('Viki Oneal',	'VikiOneal@gmail.com'),
('Anthe Larne',	'AntheLarne@gmail.com')

UPDATE Aircraft
	SET Condition = 'A'
		WHERE (Condition IN ('C', 'B')) AND (FlightHours IS NULL OR FlightHours <= 100) AND ([Year] >= 2013)

DELETE FROM Passengers
	WHERE LEN(FullName) <= 10

SELECT Manufacturer, Model, FlightHours, Condition FROM Aircraft
	ORDER BY FlightHours DESC

SELECT FirstName, LastName, Manufacturer, Model, FlightHours
	FROM Pilots AS p
	JOIN PilotsAircraft AS pa ON pa.PilotId = p.Id
	JOIN Aircraft AS a ON a.Id = pa.AircraftId
	WHERE FlightHours IS NOT NULL AND FlightHours < 304
	ORDER BY FlightHours DESC, FirstName ASC
	
SELECT TOP 20 fd.Id AS DestinationId, fd.[Start], p.FullName, AirportName, fd.TicketPrice
	FROM FlightDestinations AS fd
	JOIN Airports AS a ON a.Id = fd.AirportId
	JOIN Passengers AS p ON p.Id = fd.PassengerId
	WHERE DATEPART(DAY, fd.[Start]) % 2 = 0
	ORDER BY TicketPrice DESC, AirportName ASC

SELECT a.Id, Manufacturer, FlightHours, COUNT(fd.Id) AS FlightDestinationsCount, ROUND(AVG(TicketPrice), 2) AS AvgPrice
	FROM Aircraft AS a
	JOIN FlightDestinations AS fd ON fd.AircraftId = a.Id
	GROUP BY a.Id, a.Manufacturer, a.FlightHours
	HAVING COUNT(fd.Id) >= 2
	ORDER BY FlightDestinationsCount DESC, a.Id ASC

	SELECT a.Id, a.Manufacturer, a.FlightHours, COUNT(*) AS FlightDestinationsCount, ROUND(AVG(TicketPrice), 2) AS AvgPrice
	FROM Aircraft a
	JOIN FlightDestinations fd ON fd.AircraftId = a.Id
	GROUP BY a.Id, a.Manufacturer, a.FlightHours
	HAVING COUNT(*) >= 2
	ORDER BY FlightDestinationsCount DESC, a.Id


SELECT p.FullName, COUNT(*) AS CountOfAircraft, SUM(TicketPrice) AS TotalPayed
	FROM Passengers AS p
	JOIN FlightDestinations AS fd ON fd.PassengerId = p.Id
	JOIN Aircraft AS a ON a.Id = fd.AircraftId
	WHERE CHARINDEX('a', FullName) = 2
	GROUP BY p.FullName
	HAVING COUNT(*) > 1
	ORDER BY FullName

SELECT AirportName, [Start] AS DayTime, TicketPrice, FullName, Manufacturer, Model 
	FROM FlightDestinations AS fd 
	JOIN Airports AS a ON a.Id = fd.AirportId
	JOIN Passengers AS p ON p.Id = fd.PassengerId
	JOIN Aircraft AS ac ON ac.Id = fd.AircraftId
	WHERE DATEPART(HOUR, [Start]) BETWEEN 6 AND 20 AND TicketPrice > 2500
	ORDER BY Model ASC

CREATE FUNCTION udf_FlightDestinationsByEmail(@email VARCHAR(30))
RETURNS INT
AS
BEGIN
	DECLARE @Result INT = (SELECT COUNT(*) FROM FlightDestinations AS fd
										JOIN Passengers AS p ON p.Id = fd.PassengerId
										WHERE Email = @email)
	RETURN @Result
END

CREATE PROCEDURE usp_SearchByAirportName(@airportName VARCHAR(70))
AS
BEGIN
	SELECT AirportName, FullName, 
	CASE
		WHEN TicketPrice < 400 THEN 'Low'
		WHEN TicketPrice BETWEEN 401 AND 1500 THEN 'Medium'
		ELSE 'High'
		END AS LevelOfTicketPrice
	, Manufacturer, Condition, TypeName	
				FROM Airports AS a 
				JOIN FlightDestinations AS fd ON a.Id = fd.AirportId
				JOIN Passengers AS p ON p.Id = fd.PassengerId
				JOIN Aircraft AS ac ON ac.Id = fd.AircraftId
				JOIN AircraftTypes AS at ON at.Id = ac.TypeId
				WHERE AirportName = @airportName
				ORDER BY Manufacturer, FullName
END

















