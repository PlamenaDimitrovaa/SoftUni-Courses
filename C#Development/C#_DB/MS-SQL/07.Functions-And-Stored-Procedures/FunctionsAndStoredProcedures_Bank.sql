--CREATE PROC usp_GetHoldersFullName
--AS
--BEGIN
--	SELECT FirstName + ' ' + LastName AS FullName FROM dbo.AccountHolders
--END

--CREATE PROC usp_GetHoldersWithBalanceHigherThan 
--@Number INT 
--AS
--BEGIN
--	SELECT FirstName, LastName FROM dbo.AccountHolders AS ah
--	JOIN dbo.Accounts AS a ON a.AccountHolderId = ah.Id
--	GROUP BY FirstName, LastName
--	HAVING SUM(Balance) > @Number
--	ORDER BY FirstName, LastName
--END

--CREATE FUNCTION ufn_CalculateFutureValue 
--(@Sum DECIMAL(18,2), @YearlyInterestRate FLOAT, @NumberOfYears INT)
--RETURNS DECIMAL(18,2)
--AS 
--BEGIN
--	RETURN @Sum * POWER((1 + @YearlyInterestRate), @NumberOfYears)
--END

--EXEC ufn_CalculateFutureValue 1000, 0.1, 5

--CREATE PROC usp_CalculateFutureValueForAccount 
--(@AccountId INT, @InterestRate DECIMAL(18,2))
--AS
--BEGIN
--	SELECT a.Id, FirstName, LastName, Balance AS CurrentBalance, dbo.ufn_CalculateFutureValue(Balance, @InterestRate, 5) AS [Balance in 5 years]
--	FROM dbo.AccountHolders AS ah
--	JOIN dbo.Accounts AS a ON ah.Id = a.AccountHolderID
--	WHERE a.Id = @AccountId
--END

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