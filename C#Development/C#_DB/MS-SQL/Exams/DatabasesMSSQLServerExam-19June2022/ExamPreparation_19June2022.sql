CREATE DATABASE Zoo

USE Zoo

CREATE TABLE Owners
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(15) NOT NULL,
	Address VARCHAR(50)
)

CREATE TABLE AnimalTypes
(
	Id INT PRIMARY KEY IDENTITY,
	AnimalType VARCHAR(30) NOT NULL
)

CREATE TABLE Cages
(
	Id INT PRIMARY KEY IDENTITY,
	AnimalTypeId INT NOT NULL REFERENCES AnimalTypes(Id)
)

CREATE TABLE Animals
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(30) NOT NULL,
	BirthDate DATE NOT NULL,
	OwnerId INT REFERENCES Owners(Id),
	AnimalTypeId INT NOT NULL REFERENCES AnimalTypes(Id)
)

CREATE TABLE AnimalsCages
(
	CageId INT NOT NULL REFERENCES Cages(Id),
	AnimalId INT NOT NULL REFERENCES Animals(Id)

	CONSTRAINT PK_AnimalCages PRIMARY KEY(CageId, AnimalId)
)

CREATE TABLE VolunteersDepartments
(
	Id INT PRIMARY KEY IDENTITY,
	DepartmentName VARCHAR(30) NOT NULL
)

CREATE TABLE Volunteers
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(15) NOT NULL,
	Address VARCHAR(50),
	AnimalId INT REFERENCES Animals(Id),
	DepartmentId INT NOT NULL REFERENCES VolunteersDepartments(Id)
)

INSERT INTO Volunteers (Name, PhoneNumber, Address, AnimalId, DepartmentId) 
VALUES
('Anita Kostova',	'0896365412',	'Sofia, 5 Rosa str.',	15,	1),
('Dimitur Stoev',	'0877564223',	null,	42,	4),
('Kalina Evtimova',	'0896321112',	'Silistra, 21 Breza str.',	9,	7),
('Stoyan Tomov',	'0898564100',	'Montana, 1 Bor str.',	18,	8),
('Boryana Mileva',	'0888112233',	null,	31,	5)

INSERT INTO Animals (Name, BirthDate, OwnerId, AnimalTypeId) 
VALUES
('Giraffe',	'2018-09-21',	21,	1),
('Harpy Eagle',	'2015-04-17',	15,	3),
('Hamadryas Baboon',	'2017-11-02',	null,	1),
('Tuatara',	'2021-06-30',	2,	4)

UPDATE Animals
	SET OwnerId = 4
		WHERE OwnerId IS NULL

DELETE FROM Volunteers
	WHERE DepartmentId = 2

DELETE FROM VolunteersDepartments
	WHERE DepartmentName = 'Education program assistant'

SELECT Name, PhoneNumber, Address, AnimalId, DepartmentId FROM Volunteers
	ORDER BY Name ASC, AnimalId ASC, DepartmentId ASC

SELECT Name, AnimalType, FORMAT(BirthDate, 'dd.MM.yyyy') FROM Animals AS a
	JOIN AnimalTypes AS ant ON a.AnimalTypeId = ant.Id
	ORDER BY Name 

SELECT TOP 5 o.Name, COUNT(*) AS CountOfAnimals FROM Owners AS o
	JOIN Animals AS a ON a.OwnerId = o.Id
	GROUP BY o.Name
	ORDER BY CountOfAnimals DESC, o.Name ASC

SELECT o.Name + '-' + a.Name AS OwnersAnimals, o.PhoneNumber, ac.CageId FROM Owners AS o
	JOIN Animals AS a ON a.OwnerId = o.Id
	JOIN AnimalTypes AS ant ON ant.Id = a.AnimalTypeId
	JOIN AnimalsCages AS ac ON ac.AnimalId = a.Id
	WHERE ant.AnimalType = 'Mammals'
	ORDER BY o.Name ASC, a.Name DESC

SELECT v.Name, v.PhoneNumber,
	CASE
		WHEN LEFT(SUBSTRING(Address, 8, LEN(Address) - 7), 1) = ',' THEN SUBSTRING(Address, 9, LEN(Address) - 7)
		ELSE SUBSTRING(Address, 8, LEN(Address))
	END AS Address FROM Volunteers AS v
	JOIN VolunteersDepartments AS vd ON vd.Id = v.DepartmentId
	WHERE vd.DepartmentName = 'Education program assistant' AND v.Address LIKE '%Sofia%'
	ORDER BY v.Name

SELECT a.Name, YEAR(a.BirthDate) AS BirthYear, at.AnimalType FROM Animals AS a 
	JOIN AnimalTypes AS at ON at.Id = a.AnimalTypeId
	WHERE a.OwnerId IS NULL AND at.AnimalType <> 'Birds' AND (2022 - YEAR(a.BirthDate)) < 5
	ORDER BY a.Name

CREATE FUNCTION udf_GetVolunteersCountFromADepartment (@VolunteersDepartment VARCHAR(30))
RETURNS INT 
AS
BEGIN
	DECLARE @result INT = (SELECT COUNT(*) FROM Volunteers AS v
		JOIN VolunteersDepartments AS vd ON vd.Id = v.DepartmentId
		WHERE vd.DepartmentName = @VolunteersDepartment
		GROUP BY DepartmentName)

		RETURN @result
END

CREATE PROCEDURE usp_AnimalsWithOwnersOrNot(@AnimalName VARCHAR(50))
AS 
BEGIN
	SELECT a.Name, ISNULL(o.Name, 'For adoption') FROM Animals AS a
		LEFT JOIN Owners AS o ON o.Id = a.OwnerId
		WHERE a.Name = @AnimalName
END