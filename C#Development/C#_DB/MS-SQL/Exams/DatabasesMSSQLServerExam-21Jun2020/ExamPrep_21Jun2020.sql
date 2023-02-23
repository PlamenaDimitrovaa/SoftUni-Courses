CREATE DATABASE TripService
USE TripService

CREATE TABLE Cities
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(20) NOT NULL,
	CountryCode VARCHAR(2) NOT NULL
)

CREATE TABLE Hotels
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(30) NOT NULL,
	CityId INT NOT NULL REFERENCES Cities(Id),
	EmployeeCount INT NOT NULL,
	BaseRate DECIMAL(18, 2)
)

CREATE TABLE Rooms
(
	Id INT PRIMARY KEY IDENTITY,
	Price DECIMAL(18, 2) NOT NULL,
	Type NVARCHAR(20) NOT NULL,
	Beds INT NOT NULL,
	HotelId INT NOT NULL REFERENCES Hotels(Id)
)

CREATE TABLE Trips
(
	Id INT PRIMARY KEY IDENTITY,
	RoomId INT NOT NULL REFERENCES Rooms(Id),
	BookDate DATE NOT NULL,
	ArrivalDate DATE NOT NULL,
	ReturnDate DATE NOT NULL,
	CancelDate DATE,

	 CHECK (BookDate < ArrivalDate),
	 CHECK(ArrivalDate < ReturnDate)
)

CREATE TABLE Accounts
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(20),
	LastName NVARCHAR(50) NOT NULL,
	CityId INT NOT NULL REFERENCES Cities(Id),
	BirthDate DATE NOT NULL,
	Email VARCHAR(100) NOT NULL UNIQUE
)

CREATE TABLE AccountsTrips
(
	AccountId INT NOT NULL REFERENCES Accounts(Id),
	TripId INT NOT NULL REFERENCES Trips(Id),
	Luggage INT NOT NULL CHECK(Luggage >= 0)

	CONSTRAINT PK_AccountTrips PRIMARY KEY (AccountId, TripId)
)

INSERT INTO Accounts (FirstName, MiddleName, LastName, CityId, BirthDate, Email)
VALUES
('John',	'Smith',	'Smith',	34,	'1975-07-21',	'j_smith@gmail.com'),
('Gosho',	NULL,	'Petrov',	11,	'1978-05-16',	'g_petrov@gmail.com'),
('Ivan',	'Petrovich',	'Pavlov',	59,	'1849-09-26',	'i_pavlov@softuni.bg'),
('Friedrich',	'Wilhelm',	'Nietzsche',	2,	'1844-10-15',	'f_nietzsche@softuni.bg')

INSERT INTO Trips (RoomId, BookDate, ArrivalDate, ReturnDate, CancelDate)
VALUES
(101,	'2015-04-12',	'2015-04-14',	'2015-04-20',	'2015-02-02'),
(102,	'2015-07-07',	'2015-07-15',	'2015-07-22',	'2015-04-29'),
(103,	'2013-07-17',	'2013-07-23',	'2013-07-24',	NULL),
(104,	'2012-03-17',	'2012-03-31',	'2012-04-01',	'2012-01-10'),
(109,	'2017-08-07',	'2017-08-28',	'2017-08-29',	NULL)

UPDATE Rooms
	SET Price *= 1.14
		WHERE HotelId IN (5, 7, 9)

DELETE FROM AccountsTrips 
	WHERE AccountId = 47
DELETE FROM Accounts
	WHERE Id = 47

SELECT FirstName, LastName, FORMAT(BirthDate, 'MM-dd-yyyy'), c.Name AS Hometown, Email
	FROM Accounts AS a 
	JOIN Cities AS c ON c.Id = a.CityId
	WHERE LEFT(Email, 1) = 'e' 
	ORDER BY c.Name

SELECT c.Name, COUNT(h.Name) AS Hotels 
	FROM Cities AS c
	JOIN Hotels AS h ON c.Id = h.CityId
	GROUP BY c.Name
	ORDER BY Hotels DESC, c.Name

SELECT AccountId, a.FirstName + ' ' + a.LastName AS FullName
	, MAX(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS LongestTrip
	, MIN(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS ShortestTrip 
		FROM AccountsTrips AS at 
		JOIN Accounts AS a ON at.AccountId = a.Id
		JOIN Trips AS t ON t.Id = at.TripId
		WHERE a.MiddleName IS NULL AND t.CancelDate IS NULL
		GROUP BY AccountId, FirstName, LastName
		ORDER BY LongestTrip DESC, ShortestTrip 

SELECT TOP 10 c.Id, c.Name AS City, CountryCode, COUNT(*) AS Accounts
	FROM Cities AS c
	JOIN Accounts AS a ON a.CityId = c.Id
	GROUP BY c.Id, c.Name, c.CountryCode
	ORDER BY Accounts DESC

SELECT AccountId, Email, c.Name AS City, COUNT(*) AS Trips
	FROM AccountsTrips AS at 
	JOIN Accounts AS a ON at.AccountId = a.Id
	JOIN Cities AS c ON c.Id = a.CityId
	JOIN Trips AS t ON t.Id = at.TripId
	JOIN Rooms AS r ON r.Id = t.RoomId
	JOIN Hotels AS h ON h.Id = r.HotelId
	JOIN Cities AS ct ON ct.Id = h.CityId
	WHERE ct.Id = c.Id
	GROUP BY AccountId, Email, c.Name
	ORDER BY Trips DESC, AccountId

SELECT TripId AS Id, 
		FirstName + ' ' + ISNULL(MiddleName + ' ', '') + LastName AS [Full Name],
		ac.Name AS [From], 
		hc.Name AS [To],
		CASE 
			WHEN CancelDate IS NULL THEN CONVERT(NVARCHAR(MAX), DATEDIFF(DAY, ArrivalDate, ReturnDate)) + ' days'
			ELSE 'Canceled' END
			AS Duration
	FROM AccountsTrips at
	JOIN Accounts a ON at.AccountId = a.Id 
	JOIN Cities AS ac ON a.CityId = ac.Id
	JOIN Trips AS t ON t.Id = at.TripId
	JOIN Rooms AS r ON t.RoomId = r.Id
	JOIN Hotels AS h ON h.Id = r.HotelId
	JOIN Cities AS hc ON h.CityId = hc.Id
	ORDER BY [Full Name], TripId

CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS VARCHAR(MAX)
AS
BEGIN
	DECLARE @RoomInfo VARCHAR(MAX) = (SELECT TOP(1) 'Room ' + CONVERT(VARCHAR, r.Id) + ': ' + r.Type + 
		' (' + CONVERT(VARCHAR, r.Beds) + ' beds) - $' + CONVERT(VARCHAR, (BaseRate + Price) * @People)
		FROM Rooms r
		JOIN Hotels h ON h.Id = r.HotelId
		WHERE Beds >= @People AND HotelId = @HotelId AND
				NOT EXISTS (SELECT * FROM Trips t WHERE t.RoomId = r.Id
													AND CancelDate IS NULL
													AND @Date BETWEEN ArrivalDate AND ReturnDate)
		ORDER BY (BaseRate + Price) * @People DESC)

		IF(@RoomInfo IS NULL)
			RETURN 'No rooms available'
		RETURN @RoomInfo
END

CREATE PROCEDURE usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
	DECLARE @TripHotelId INT = (SELECT r.HotelId FROM Trips t
									JOIN Rooms r ON t.RoomId = r.Id
									WHERE t.Id = @TripId)
	DECLARE @TargetRoomHotelId INT = (SELECT HotelId FROM Rooms WHERE Id = @TargetRoomId)

	IF(@TripHotelId != @TargetRoomHotelId)
		THROW 50001, 'Target room is in another hotel!', 1

	DECLARE @TripAccounts INT = (SELECT COUNT(*) FROM AccountsTrips WHERE TripId = @TripId)
	DECLARE @TargetRoomBeds INT = (SELECT Beds FROM Rooms WHERE Id = @TargetRoomId)

	IF(@TripAccounts > @TargetRoomBeds)
		THROW 50002, 'Not enough beds in target room!', 1

	UPDATE Trips
		SET RoomId = @TargetRoomId 
			WHERE Id = @TripId