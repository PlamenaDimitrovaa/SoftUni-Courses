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
--CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)
--AS

--DECLARE @empIDsToBeDeleted TABLE
--(
--Id int
--)

--INSERT INTO @empIDsToBeDeleted
--SELECT e.EmployeeID
--FROM Employees AS e
--WHERE e.DepartmentID = @departmentId

--ALTER TABLE Departments
--ALTER COLUMN ManagerID int NULL

--DELETE FROM EmployeesProjects
--WHERE EmployeeID IN (SELECT Id FROM @empIDsToBeDeleted)

--UPDATE Employees
--SET ManagerID = NULL
--WHERE ManagerID IN (SELECT Id FROM @empIDsToBeDeleted)

--UPDATE Departments
--SET ManagerID = NULL
--WHERE ManagerID IN (SELECT Id FROM @empIDsToBeDeleted)

--DELETE FROM Employees
--WHERE EmployeeID IN (SELECT Id FROM @empIDsToBeDeleted)

--DELETE FROM Departments
--WHERE DepartmentID = @departmentId 

--SELECT COUNT(*) AS [Employees Count] FROM Employees AS e
--JOIN Departments AS d
--ON d.DepartmentID = e.DepartmentID
--WHERE e.DepartmentID = @departmentId

--09. Find Full Name:
--CREATE PROC usp_GetHoldersFullName 
--AS
--BEGIN
--	SELECT FirstName + ' ' + LastName AS [Full Name]
--	FROM AccountHolders
--END

--10. People with Balance Higher Than:
--CREATE PROC usp_GetHoldersWithBalanceHigherThan (@money DECIMAL(15, 2))
--AS
--	SELECT FirstName, LastName
--	FROM AccountHolders ah
--	JOIN Accounts a ON ah.Id = a.AccountHolderId
--	GROUP BY FirstName, LastName
--	HAVING SUM(Balance) > @money
--	ORDER BY FirstName, LastName

--11. Future Value Function:
--CREATE FUNCTION ufn_CalculateFutureValue (@InitialSum DECIMAL(18,2), @YearlyInterestRate FLOAT, @NumberOfYears INT)
--RETURNS DECIMAL(18,4)
--AS
--BEGIN
--    DECLARE @Result DECIMAL(18,4)
--	SET @Result = @InitialSum * POWER((1 + @YearlyInterestRate), @NumberOfYears)
--	RETURN @Result
--END 

--EXEC ufn_CalculateFutureValue 1000, 0.1, 5

--12. Calculating Interest:
--CREATE PROC	usp_CalculateFutureValueForAccount(@AccountId INT, @InterestRate DECIMAL(18,2))
--AS
--BEGIN
--	SELECT a.Id AS [Account Id],
--		FirstName AS [First Name], 
--		LastName AS [Last Name],
--		Balance AS [Current Balance],
--		dbo.ufn_CalculateFutureValue(Balance, @InterestRate, 5) AS [Balance in 5 years]
--	FROM Accounts a
--	JOIN AccountHolders ah ON ah.Id = a.AccountHolderId
--	WHERE a.Id = @AccountId
--END

--13. *Cash in User Games Odd Rows:
--CREATE FUNCTION ufn_CashInUsersGames(@gameName VARCHAR(MAX))
--RETURNS @returnedTable TABLE (SumCash MONEY)
--AS
--BEGIN
--	DECLARE @result MONEY

--	SET @result = (SELECT SUM(ug.Cash) AS Cash
--	FROM (SELECT Cash, GameId, ROW_NUMBER() OVER (ORDER BY Cash DESC) AS RowNumber
--		FROM UsersGames
--		WHERE GameId = (SELECT Id FROM Games WHERE Name = @gameName)) AS ug
--	WHERE ug.RowNumber % 2 != 0)

--	INSERT INTO @returnedTable SELECT @result
--	RETURN
--END