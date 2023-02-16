CREATE DATABASE Service
USE Service

CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(50) NOT NULL,
	[Name] VARCHAR(50),
	Birthdate DATETIME,
	Age INT CHECK(Age BETWEEN 14 AND 110),
	Email VARCHAR(50) NOT NULL
)

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(25),
	LastName VARCHAR(25),
	Birthdate DATETIME,
	Age INT CHECK(Age BETWEEN 18 AND 110),
	DepartmentId INT REFERENCES Departments(Id)
)

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	DepartmentId INT NOT NULL REFERENCES Departments(Id)
)

CREATE TABLE Status
(
	Id INT PRIMARY KEY IDENTITY,
	[Label] VARCHAR(30) NOT NULL
)

CREATE TABLE Reports
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryId INT NOT NULL REFERENCES Categories(Id),
	StatusId INT NOT NULL REFERENCES Status(Id),
	OpenDate DATETIME NOT NULL,
	CloseDate DATETIME,
	[Description] VARCHAR(200) NOT NULL,
	UserId INT NOT NULL REFERENCES Users(Id),
	EmployeeId INT REFERENCES Employees(Id)
)

INSERT INTO Employees (FirstName, LastName, Birthdate, DepartmentId)
					VALUES
('Marlo',	'O''Malley',	'1958-9-21',	1),
('Niki',	'Stanaghan',	'1969-11-26',	4),
('Ayrton',	'Senna',	'1960-03-21',	9),
('Ronnie',	'Peterson',	'1944-02-14',	9),
('Giovanna',	'Amati',	'1959-07-20',	5)

INSERT INTO Reports (CategoryId, StatusId, OpenDate, CloseDate, Description, UserId, EmployeeId)
	VALUES
(1,	1,	'2017-04-13',	NULL,	'Stuck Road on Str.133',	6,	2),
(6,	3,	'2015-09-05',	'2015-12-06',	'Charity trail running',	3,	5),
(14,	2,	'2015-09-07',	NULL,	'Falling bricks on Str.58',	5,	2),
(4,	3,	'2017-07-03',	'2017-07-06',	'Cut off streetlight on Str.11',	1,	1)

UPDATE Reports
	SET CloseDate = GETDATE()
	WHERE CloseDate IS NULL

DELETE FROM Reports
	WHERE StatusId = 4

DELETE FROM Status
	WHERE Id = 4

SELECT [Description], FORMAT(OpenDate, 'dd-MM-yyyy')
	FROM Reports
	WHERE EmployeeId IS NULL
	ORDER BY OpenDate ASC, [Description] ASC
	
SELECT Description, [Name] AS CategoryName 
	FROM Reports AS r
	JOIN Categories AS c ON c.Id = r.CategoryId
	ORDER BY [Description], CategoryName

SELECT TOP 5 [Name] AS CategoryName, COUNT(*) AS ReportsNumber
	FROM Categories AS c
	JOIN Reports AS r ON r.CategoryId = c.Id
	GROUP BY c.[Name]
	ORDER BY ReportsNumber DESC, CategoryName

SELECT Username, c.[Name] AS CategoryName
	FROM Reports AS r
	JOIN Users AS u ON u.Id = r.UserId
	JOIN Categories AS c ON c.Id = r.CategoryId
	WHERE DATEPART(MONTH, Birthdate) = DATEPART(MONTH, OpenDate) AND 
		DATEPART(DAY, Birthdate) = DATEPART(DAY, OpenDate)
	ORDER BY Username, CategoryName
	
SELECT DISTINCT FirstName + ' ' + LastName AS FullName, COUNT(r.Id) AS UsersCount 
	FROM Employees AS e
	LEFT JOIN Reports AS r ON r.EmployeeId = e.Id
	GROUP BY FirstName + ' ' + LastName
	ORDER BY UsersCount DESC, FullName
		SELECT ISNULL(e.FirstName + ' ' + e.LastName, 'None') AS Employee,
ISNULL(d.[Name], 'None') AS Department,
c.[Name] AS Category,
	   r.[Description],
FORMAT(r.OpenDate, 'dd.MM.yyyy') AS OpenDate,
s.[Label] AS [Status],
u.[Name] AS [User]
	   FROM Reports AS r 
	   LEFT JOIN Categories AS c ON c.Id = r.CategoryId
	   LEFT JOIN [Status] AS s ON s.Id = r.StatusId
	   LEFT JOIN Employees AS e ON e.Id = r.EmployeeId
	   LEFT JOIN Users AS u ON u.Id = r.UserId
	   LEFT JOIN Departments AS d ON d.Id = e.DepartmentId
	   ORDER BY e.FirstName DESC, e.LastName DESC, d.[Name], c.[Name], r.[Description], r.OpenDate, s.[Label], u.[Name]

CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS 
BEGIN
	IF(@StartDate IS  NULL OR @EndDate IS NULL)
	RETURN 0

	RETURN DATEDIFF(HOUR, @StartDate, @EndDate)
END

CREATE PROCEDURE usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT) 
AS
BEGIN
	DECLARE @categoryDepartmentId INT = (SELECT c.DepartmentId
											FROM Reports r
											JOIN Categories c ON R.CategoryId = C.Id
											WHERE r.Id = @ReportId)

	DECLARE @employeeDepartmentId INT = (SELECT DepartmentId 
											FROM Employees
											WHERE Id = @EmployeeId)

	IF(@categoryDepartmentId = @employeeDepartmentId)
	BEGIN
		UPDATE Reports
			SET EmployeeId = @EmployeeId
			WHERE Id = @ReportId
	END
	ELSE
		THROW 50001, 'Employee doesn''t belong to the appropriate department!', 1;
END