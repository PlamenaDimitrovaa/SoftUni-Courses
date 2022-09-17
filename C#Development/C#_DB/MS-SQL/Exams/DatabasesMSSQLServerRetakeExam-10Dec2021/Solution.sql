--CREATE TABLE Passengers
--(
--	Id INT PRIMARY KEY IDENTITY,
--	FullName VARCHAR(100) UNIQUE NOT NULL,
--	Email VARCHAR(50) UNIQUE NOT NULL
--)

--CREATE TABLE Pilots
--(
--	Id INT PRIMARY KEY IDENTITY,
--	FirstName VARCHAR(30) UNIQUE NOT NULL,
--	LastName VARCHAR(30) UNIQUE NOT NULL,
--	Age TINYINT CHECK(Age BETWEEN 21 AND 62) NOT NULL,
--	Rating FLOAT CHECK(Rating BETWEEN 0.0 AND 10.0)
--)

--CREATE TABLE AircraftTypes
--(
--	Id INT PRIMARY KEY IDENTITY,
--	TypeName VARCHAR(30) UNIQUE NOT NULL
--)

--CREATE TABLE Aircraft
--(
--	Id INT PRIMARY KEY IDENTITY,
--	Manufacturer VARCHAR(25) NOT NULL,
--	Model VARCHAR(30) NOT NULL,
--	[Year] INT NOT NULL,
--	FlightHours INT,
--	Condition CHAR(1) NOT NULL,
--	TypeId INT NOT NULL REFERENCES AircraftTypes(Id)
--)

--CREATE TABLE PilotsAircraft
--(
--	AircraftId INT NOT NULL REFERENCES Aircraft(Id),
--	PilotId INT NOT NULL REFERENCES Pilots(Id)

--	CONSTRAINT PK_PilotsAircraft PRIMARY KEY(AircraftId, PilotId)
--)

--CREATE TABLE Airports
--(
--	Id INT PRIMARY KEY IDENTITY,
--	AirportName VARCHAR(70) UNIQUE NOT NULL,
--	Country VARCHAR(100) UNIQUE NOT NULL
--)

--CREATE TABLE FlightDestinations
--(
--	Id INT PRIMARY KEY IDENTITY,
--	AirportId INT NOT NULL REFERENCES Airports(Id),
--	Start DATETIME NOT NULL,
--	AircraftId INT NOT NULL REFERENCES Aircraft(Id),
--	PassengerId INT NOT NULL REFERENCES Passengers(Id),
--	TicketPrice DECIMAL(18,2) NOT NULL DEFAULT 15
--)

--SELECT * FROM Pilots 
--	WHERE Id BETWEEN 5 AND 15

--INSERT INTO Passengers (FullName, Email) VALUES
--('Krystal Cuckson', 'KrystalCuckson@gmail.com'),
--('Susy Borrel', 'SusyBorrel@gmail.com'),
--('Saxon Veldman', 'SaxonVeldman@gmail.com'),
--('Lenore Romera', 'LenoreRomera@gmail.com'),
--('Enrichetta Jeremiah', 'EnrichettaJeremiah@gmail.com'),
--('Delaney Stove', 'DelaneyStove@gmail.com'),
--('Ilaire Tomaszewicz', 'IlaireTomaszewicz@gmail.com'),
--('Genna Jaquet', 'GennaJaquet@gmail.com'),
--('Carlotta Dykas', 'CarlottaDykas@gmail.com'),
--('Viki Oneal', 'VikiOneal@gmail.com'),
--('Anthe Larne', 'AntheLarne@gmail.com')

--UPDATE Aircraft 
--	SET Condition = 'A'
--	WHERE (Condition IN ('C', 'B')) AND (FlightHours IS NULL OR FlightHours <= 100) AND ([Year] >= 2013)

--DELETE FROM Passengers
--		WHERE LEN(FullName) <= 10

--SELECT Manufacturer, Model, FlightHours, Condition
--		FROM Aircraft
--		ORDER BY FlightHours DESC

--SELECT p.FirstName, p.LastName, a.Manufacturer, a.Model, a.FlightHours
--		FROM PilotsAircraft pa
--		JOIN Aircraft a ON pa.AircraftId = a.Id
--		JOIN Pilots p ON pa.PilotId = p.Id
--		WHERE FlightHours IS NOT NULL AND FlightHours < 304
--		ORDER BY FlightHours DESC, p.FirstName

--SELECT TOP(20) fd.Id AS DestinationId, fd.[Start], p.FullName, a.AirportName, fd.TicketPrice
--		FROM FlightDestinations fd
--		JOIN Passengers p ON p.Id = fd.PassengerId
--		JOIN Airports a ON fd.AirportId = a.Id
--		WHERE DATEPART(DAY, fd.[Start]) % 2 = 0
--		ORDER BY fd.TicketPrice DESC, a.AirportName

--SELECT a.Id, a.Manufacturer, a.FlightHours, COUNT(*) AS FlightDestinationsCount, ROUND(AVG(TicketPrice), 2) AS AvgPrice
--	FROM Aircraft a
--	JOIN FlightDestinations fd ON fd.AircraftId = a.Id
--	GROUP BY a.Id, a.Manufacturer, a.FlightHours
--	HAVING COUNT(*) >= 2
--	ORDER BY FlightDestinationsCount DESC, a.Id

--SELECT p.FullName, COUNT(*) AS CountOfAircraft, SUM(TicketPrice) AS TotalPayed
--	FROM Passengers p
--	JOIN FlightDestinations fd ON fd.PassengerId = p.Id
--	JOIN Aircraft a ON fd.AircraftId = a.Id
--	WHERE CHARINDEX('a', FullName) = 2
--	GROUP BY FullName
--	HAVING COUNT(*) > 1
--	ORDER BY FullName

--SELECT a.AirportName, fd.[Start] AS DayTime, fd.TicketPrice, p.FullName, ac.Manufacturer, ac.Model
--	FROM FlightDestinations fd
--	JOIN Airports a ON a.Id = fd.AirportId
--	JOIN Passengers p ON fd.PassengerId = p.Id
--	JOIN Aircraft ac ON ac.Id = fd.AircraftId
--	WHERE DATEPART(HOUR, [Start]) BETWEEN 6 AND 20 AND TicketPrice > 2500
--	ORDER BY ac.Model

--CREATE FUNCTION udf_FlightDestinationsByEmail(@email VARCHAR(MAX))
--RETURNS INT
--AS
--BEGIN
--	RETURN (SELECT COUNT(*) 
--		FROM Passengers p 
--		JOIN FlightDestinations fd ON fd.PassengerId = p.Id
--		WHERE p.Email = @email)
--END

--CREATE PROC usp_SearchByAirportName(@airportName VARCHAR(70))
--AS
--BEGIN
--	SELECT a.AirportName, p.FullName,
--		CASE
--			WHEN TicketPrice < 400 THEN 'Low'
--			WHEN TicketPrice BETWEEN 401 AND 1500 THEN 'Medium'
--			ELSE 'High'
--		END AS LevelOfTickerPrice, ac.Manufacturer, ac.Condition, act.TypeName
--		FROM FlightDestinations fd
--		JOIN Airports a ON a.Id = fd.AirportId
--		JOIN Passengers p ON fd.PassengerId = p.Id
--		JOIN Aircraft ac ON fd.AircraftId = ac.Id
--		JOIN AircraftTypes act ON ac.TypeId = act.Id
--		WHERE AirportName = @airportName
--		ORDER BY Manufacturer, FullName
--END