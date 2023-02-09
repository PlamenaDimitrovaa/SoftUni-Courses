--CREATE PROC usp_EmployeesWithSalaryAbove35000 AS
--BEGIN
--SELECT FirstName, LastName FROM Employees WHERE Salary > 35000
--END

--EXEC usp_EmployeesWithSalaryAbove35000


--CREATE PROC usp_GetEmployeesSalaryAboveNumber
--@Number DECIMAL(18,4)
--AS
--BEGIN
--	SELECT FirstName, LastName FROM Employees WHERE Salary > @Number
--END

--EXEC usp_GetEmployeesSalaryAboveNumber 48100

--CREATE PROC usp_GetTownsStartingWith 
--	@String NVARCHAR(10)
--AS
--BEGIN
--	SELECT [Name] FROM Towns WHERE LEFT([Name], LEN(@String)) = @String
--END

--EXEC usp_GetTownsStartingWith 'b'

--CREATE PROC usp_GetEmployeesFromTown 
--@TownName NVARCHAR(10)
--AS
--BEGIN
--	SELECT FirstName, LastName FROM Employees AS e
--	JOIN Addresses AS a ON a.AddressID = e.AddressID
--	JOIN Towns AS t ON t.TownID = a.TownID 
--	WHERE t.[Name] = @TownName
--END

--EXEC usp_GetEmployeesFromTown 'Sofia'

--CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4)) 
--RETURNS NVARCHAR(10)
--AS
--BEGIN
--	DECLARE @salaryLevel NVARCHAR(10) = 'Average'
--		IF(@salary < 30000)
--			BEGIN
--				SET @salaryLevel = 'Low'
--			END
--		ELSE IF (@salary > 50000)
--			BEGIN
--				SET @salaryLevel = 'High'
--			END
--			RETURN @salaryLevel
--END

--SELECT Salary, dbo.ufn_GetSalaryLevel(Salary) AS [Salary Level] 
--FROM Employees

--CREATE PROC usp_EmployeesBySalaryLevel 
--@LevelOfSalary NVARCHAR(10)
--AS 
--BEGIN 
--	SELECT FirstName, LastName FROM Employees 
--	WHERE dbo.ufn_GetSalaryLevel(Salary) = @LevelOfSalary
--END

--EXEC usp_EmployeesBySalaryLevel 'High'

	--CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(10), @word NVARCHAR(10)) 
	--RETURNS BIT
	--AS
	--BEGIN
	--	DECLARE @currentIndex int = 1;
	--	WHILE(@currentIndex <= LEN(@word))
	--	BEGIN
	--		DECLARE @currentLetter varchar(1) = SUBSTRING(@word, @currentIndex, 1);
	--		IF(CHARINDEX(@currentLetter, @setOfLetters)) = 0
	--			BEGIN
	--				RETURN 0;
	--			END
	--		SET @currentIndex += 1;
	--	END
	--		RETURN 1;
	--END

--CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)
--AS
--BEGIN
--	DECLARE @empIDsToBeDeleted TABLE
--	(
--		Id int
--	)

--	INSERT INTO @empIDsToBeDeleted
--	SELECT e.EmployeeID
--	FROM Employees AS e
--	WHERE e.DepartmentID = @departmentId

--	ALTER TABLE Departments
--	ALTER COLUMN ManagerID int NULL

--	DELETE FROM EmployeesProjects
--	WHERE EmployeeID IN (SELECT Id FROM @empIDsToBeDeleted)

--	UPDATE Employees
--	SET ManagerID = NULL
--	WHERE ManagerID IN (SELECT Id FROM @empIDsToBeDeleted)

--	UPDATE Departments
--	SET ManagerID = NULL
--	WHERE ManagerID IN (SELECT Id FROM @empIDsToBeDeleted)

--	DELETE FROM Employees
--	WHERE EmployeeID IN (SELECT Id FROM @empIDsToBeDeleted)

--	DELETE FROM Departments
--	WHERE DepartmentID = @departmentId 

--	SELECT COUNT(*) AS [Employees Count] FROM Employees AS e
--	JOIN Departments AS d
--	ON d.DepartmentID = e.DepartmentID
--	WHERE e.DepartmentID = @departmentId
--END

