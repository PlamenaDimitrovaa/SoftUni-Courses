--CREATE DATABASE Zoo

--USE Zoo

--CREATE TABLE Owners
--(
--	Id INT PRIMARY KEY IDENTITY,
--	Name VARCHAR(50) NOT NULL,
--	PhoneNumber VARCHAR(15) NOT NULL,
--	Address VARCHAR(50)
--)

--CREATE TABLE AnimalTypes
--(
--	Id INT PRIMARY KEY IDENTITY,
--	AnimalType VARCHAR(30) NOT NULL,
--)

--CREATE TABLE Cages
--(
--	Id INT PRIMARY KEY IDENTITY,
--	AnimalTypeId INT NOT NULL REFERENCES AnimalTypes(Id)
--)

--CREATE TABLE Animals
--(
--	Id INT PRIMARY KEY IDENTITY,
--	Name VARCHAR(30) NOT NULL,
--	BirthDate DATE NOT NULL,
--	OwnerId INT REFERENCES Owners(Id),
--	AnimalTypeId INT NOT NULL REFERENCES AnimalTypes(Id)
--)

--CREATE TABLE AnimalsCages
--(
--	CageId INT NOT NULL REFERENCES Cages(Id),
--	AnimalId INT NOT NULL REFERENCES Animals(Id)

--	CONSTRAINT PK_AnimalCage PRIMARY KEY (CageId, AnimalId)
--)

--CREATE TABLE VolunteersDepartments
--(
--	Id INT PRIMARY KEY IDENTITY,
--	DepartmentName VARCHAR(30) NOT NULL
--)

--CREATE TABLE Volunteers
--(
--	Id INT PRIMARY KEY IDENTITY,
--	Name VARCHAR(50) NOT NULL,
--	PhoneNumber VARCHAR(15) NOT NULL,
--	Address VARCHAR(50),
--	AnimalId INT REFERENCES Animals(Id),
--	DepartmentId INT NOT NULL REFERENCES VolunteersDepartments(Id)
--)

--INSERT INTO Volunteers (Name, PhoneNumber, Address, AnimalId, DepartmentId) VALUES
--('Anita Kostova',	'0896365412',	'Sofia, 5 Rosa str.', 15, 1),
--('Dimitur Stoev',	'0877564223',	null,	42,	4),
--('Kalina Evtimova',	'0896321112',	'Silistra, 21 Breza str.',	9, 7),
--('Stoyan Tomov',	'0898564100',	'Montana, 1 Bor str.', 18,	8),
--('Boryana Mileva',	'0888112233',	null, 31, 5)

--INSERT INTO Animals (Name, BirthDate, OwnerId, AnimalTypeId) VALUES
--('Giraffe',	'2018-09-21', 21, 1),
--('Harpy Eagle',	'2015-04-17', 15, 3),
--('Hamadryas Baboon', '2017-11-02', null, 1),
--('Tuatara',	'2021-06-30', 2, 4)

--UPDATE Animals
--	SET OwnerId = 4
--		WHERE OwnerId IS NULL

--DELETE FROM Volunteers WHERE DepartmentId = 2
--DELETE FROM VolunteersDepartments WHERE Id = 2

--SELECT Name, PhoneNumber, Address, AnimalId, DepartmentId
--		FROM Volunteers
--		ORDER BY Name, AnimalId, DepartmentId

--SELECT a.Name, at.AnimalType, FORMAT(a.BirthDate, 'dd.MM.yyyy')
--		FROM Animals a
--		JOIN AnimalTypes at ON a.AnimalTypeId = at.Id
--		ORDER BY a.Name

--SELECT TOP(5) o.Name AS Owner, COUNT(*) AS CountOfAnimals
--		FROM Animals a
--		JOIN Owners o ON o.Id = a.OwnerId
--		GROUP BY o.Name
--		ORDER BY CountOfAnimals DESC, Owner ASC

--SELECT o.Name + '-' + a.Name AS OwnersAnimals, o.PhoneNumber, ac.CageId
--		FROM Owners o
--		JOIN Animals a ON o.Id = a.OwnerId
--		JOIN AnimalTypes at ON a.AnimalTypeId = at.Id
--		JOIN AnimalsCages ac ON a.Id = ac.AnimalId
--		WHERE AnimalType = 'Mammals'
--		ORDER BY o.Name, a.Name DESC

--SELECT Name, PhoneNumber,  
--		CASE
--			WHEN LEFT(SUBSTRING(Address, 8, LEN(Address) - 7), 1) = ',' THEN SUBSTRING(Address, 9, LEN(Address) - 7)
--			ELSE SUBSTRING(Address, 8, LEN(Address))
--	    END AS Address
--		FROM Volunteers v
--		JOIN VolunteersDepartments vd ON v.DepartmentId = vd.Id
--		WHERE DepartmentName = 'Education program assistant' AND Address LIKE '%Sofia%'
--		ORDER BY Name

--SELECT Name, DATEPART(YEAR, BirthDate) AS BirthYear, AnimalType
--		FROM Animals a
--		JOIN AnimalTypes at ON at.Id = a.AnimalTypeId
--		WHERE OwnerId IS NULL AND DATEDIFF(YEAR, BirthDate, '01/01/2022') < 5 AND AnimalType != 'Birds'
--		ORDER BY Name

--CREATE FUNCTION udf_GetVolunteersCountFromADepartment (@VolunteersDepartment VARCHAR(MAX))
--RETURNS INT
--AS
--BEGIN
--	DECLARE @Result INT = (SELECT COUNT(*)
--			FROM Volunteers v
--			JOIN VolunteersDepartments vd ON v.DepartmentId = vd.Id
--			WHERE DepartmentName = @VolunteersDepartment
--			GROUP BY DepartmentName)

--		RETURN @Result
--END

--CREATE PROC usp_AnimalsWithOwnersOrNot(@AnimalName VARCHAR(MAX))
--AS
--BEGIN
--	SELECT a.Name, ISNULL(o.Name, 'For adoption') AS OwnersName
--	FROM Animals a
--	LEFT JOIN Owners o ON o.Id = a.OwnerId
--	WHERE a.Name = @AnimalName
--END