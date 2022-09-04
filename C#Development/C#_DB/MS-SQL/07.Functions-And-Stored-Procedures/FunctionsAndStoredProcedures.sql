--01. Employees with Salary Above 35000:
--CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000 
--AS
--BEGIN
--	SELECT FirstName AS [First Name], LastName AS [Last Name]
--		FROM Employees
--		WHERE Salary > 35000
--END

--EXEC usp_GetEmployeesSalaryAbove35000

--02. Employees with Salary Above Number:
--CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber
--    @Number DECIMAL(18,4)
--AS
--BEGIN
--	SELECT FirstName AS [First Name], LastName AS [Last Name]
--	FROM Employees
--	WHERE Salary >= @Number
--END

--EXEC usp_GetEmployeesSalaryAboveNumber 15000

--03. Town Names Starting With:
--CREATE OR ALTER PROCEDURE usp_GetTownsStartingWith
--    @searchedString NVARCHAR(50)
--AS
--BEGIN
--     DECLARE @stringCount int = LEN(@searchedString)
--	SELECT [Name] FROM Towns
--	WHERE LEFT([Name], @stringCount) = @searchedString
--END

--EXEC usp_GetTownsStartingWith 'b'

--04. Employees from Town:
--CREATE PROCEDURE usp_GetEmployeesFromTown
--    @TownName VARCHAR(50)
--AS
--BEGIN
--	SELECT FirstName AS [First Name], LastName AS [Last Name]
--	 FROM Employees e
--       JOIN Addresses a ON e.AddressID = a.AddressID
--       JOIN Towns AS t ON t.TownID = a.TownID
--      WHERE t.Name = @TownName
--END

--EXEC usp_GetEmployeesFromTown 'Sofia'

--05. Salary Level Function:
--CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
--RETURNS VARCHAR(20)
--AS
--BEGIN
--	IF @salary < 30000
--		RETURN 'Low'
--	ELSE IF @salary <= 50000
--		RETURN 'Average'
--	RETURN 'High'
--END

--SELECT Salary, dbo.ufn_GetSalaryLevel(Salary) AS [Salary Level] 
--FROM Employees

--06. Employees by Salary Level:
--CREATE PROCEDURE usp_EmployeesBySalaryLevel
--    @SalaryLevel VARCHAR(20)
--AS
--BEGIN
--	SELECT FirstName AS [First Name], LastName AS [Last Name]
--	FROM Employees
--	WHERE dbo.ufn_GetSalaryLevel(Salary) = @SalaryLevel
--END

--07. Define Function:
--CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(50), @word VARCHAR(50)) 
--RETURNS BIT
--AS
--BEGIN
--DECLARE @currentIndex int = 1;

--WHILE(@currentIndex <= LEN(@word))
--BEGIN
--	DECLARE @currentLetter varchar(1) = SUBSTRING(@word, @currentIndex, 1);
--	IF(CHARINDEX(@currentLetter, @setOfLetters)) = 0
--		BEGIN
--			RETURN 0;
--		END
--	SET @currentIndex += 1;
--END
--	RETURN 1;	
--END

--08. Delete Employees and Departments: