CREATE DATABASE SoftUni

USE SoftUni

CREATE TABLE Towns
(
    Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(20) NOT NULL
)

SET IDENTITY_INSERT Towns ON

INSERT INTO Towns (Id, [Name]) 
VALUES
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna'),
(4, 'Burgas')

SET IDENTITY_INSERT Towns OFF

CREATE TABLE Addresses
(
    Id INT PRIMARY KEY IDENTITY,
	AddressText VARCHAR(50),
	TownId INT NOT NULL
)

CREATE TABLE Departments
(
    Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(20) NOT NULL
)

SET IDENTITY_INSERT Departments ON

INSERT INTO Departments (Id, [Name])
VALUES
(1, 'Engineering'),
(2, 'Sales'),
(3, 'Marketing'),
(4, 'Software Development'),
(5, 'Quality Assurance')

SET IDENTITY_INSERT Departments OFF

CREATE TABLE Employees
(
    Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(20) NOT NULL,
	MiddleName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	JobTitle VARCHAR(20) NOT NULL,
	DepartmentId VARCHAR(50) NOT NULL,
	HireDate VARCHAR(50) NOT NULL,
	Salary DECIMAL(15,2),
	AddressId INT NOT NULL
)

SET IDENTITY_INSERT Employees ON

INSERT INTO Employees (Id, FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary, AddressId)
VALUES
(1, 'Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 'Software Development', '01/02/2013', 3500.00, 1),
(2, 'Petar', 'Petrov', 'Petrov', 'Senior Engineer', 'Engineering', '02/03/2004', 4000.00, 2),
(3, 'Maria', 'Petrova', 'Ivanova', 'Intern', 'Quality Assurance', '28/08/2016', 525.25, 3),
(4, 'Georgi', 'Teziev', 'Ivanov', 'CEO', 'Sales', '09/12/2007', 3000.00, 4),
(5, 'Peter', 'Pan', 'Pan', 'Intern', 'Marketing', '28/08/2016', 599.88, 5)

SET IDENTITY_INSERT Employees OFF

--19.Basic Select All Fields:
--SELECT * FROM Towns
--SELECT * FROM Departments
--SELECT * FROM Employees

--20.Basic Select All Fields and Order Them:
--SELECT * FROM Towns
--ORDER BY [Name]
--SELECT * FROM Departments
--ORDER BY [Name]
--SELECT * FROM Employees
--ORDER BY Salary DESC

--21.Basic Select Some Fields:
SELECT [Name] FROM Towns
ORDER BY [Name]

SELECT [Name] FROM Departments
ORDER BY [Name]

SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC

--22.Increase Employees Salary:
UPDATE Employees
SET Salary *= 1.1

SELECT Salary FROM Employees

