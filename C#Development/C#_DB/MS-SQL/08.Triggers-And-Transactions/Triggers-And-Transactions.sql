--14. Create Table Logs:
--CREATE TABLE Logs
--(
--	LogId INT PRIMARY KEY IDENTITY,
--	AccountId INT FOREIGN KEY REFERENCES Accounts(Id),
--	OldSum DECIMAL(15,2),
--	NewSum DECIMAL(15,2)
--)

--CREATE TRIGGER tr_InsertAccountInto ON Accounts 
--	FOR UPDATE
--	AS
--	DECLARE @newSum DECIMAL(15, 2) = (SELECT Balance FROM inserted)
--	DECLARE @oldSum DECIMAL(15, 2) = (SELECT Balance FROM deleted) 	
--	DECLARE @accountId INT = (SELECT Id FROM inserted)
	
--	INSERT INTO Logs (AccountId, NewSum, OldSum) VALUES
--	(@accountId, @newSum, @oldSum)

--UPDATE Accounts
--SET Balance += 10
--WHERE Id = 1

--15. Create Table Emails:
--CREATE TABLE NotificationEmails
--(
--	Id INT PRIMARY KEY IDENTITY,
--	Recipient INT FOREIGN KEY REFERENCES Accounts(Id),
--	Subject VARCHAR(MAX),
--	Body VARCHAR(MAX)
--)

--CREATE TRIGGER tr_LogEmail ON Logs 
--	FOR INSERT
--	AS
--	DECLARE @accountId INT = (SELECT TOP(1) AccountId FROM inserted)
--	DECLARE @oldSum DECIMAL(15,2) = (SELECT TOP(1) OldSum FROM inserted)
--	DECLARE @newSum DECIMAL(15,2) = (SELECT TOP(1) NewSum FROM inserted)

--	INSERT INTO NotificationEmails (Recipient, Subject, Body) VALUES
--	(
--		@accountId, 
--		'Balance change for account: ' + CAST(@accountId AS VARCHAR(20)),
--		'On ' + CONVERT(VARCHAR(30), GETDATE(), 103) + ' your balance was changed from ' + CAST(@oldSum AS VARCHAR(20)) + ' to ' +  CAST(@newSum AS VARCHAR(20))
--	)

--	UPDATE Accounts 
--	SET Balance += 100
--	WHERE Id = 1

--16. Deposit Money:
--CREATE PROC usp_DepositMoney @accountId INT, @moneyAmount DECIMAL(15,4)
--AS
--BEGIN TRANSACTION
--DECLARE @account INT = (SELECT Id FROM Accounts WHERE Id = @accountId)
--IF (@account IS NULL)
--BEGIN
--    ROLLBACK
--	RAISERROR('Invalid account id!', 16, 1)
--	RETURN
--END

--IF (@moneyAmount < 0)
--BEGIN
-- ROLLBACK
--	RAISERROR('Negative amount!', 16, 1)
--	RETURN
--END

--UPDATE Accounts 
--SET Balance  += @moneyAmount
--WHERE Id = @accountId
--COMMIT

--17. Withdraw Money Procedure:
--CREATE PROC usp_WithdrawMoney @accountId INT, @moneyAmount DECIMAL(15,4)
--AS
--BEGIN TRANSACTION
--DECLARE @account INT = (SELECT Id FROM Accounts WHERE Id = @accountId)
--DECLARE @accountBalance DECIMAL(15,4) = (SELECT Balance FROM Accounts WHERE Id = @accountId)
--IF (@account IS NULL)
--BEGIN
--    ROLLBACK
--	RAISERROR('Invalid account id!', 16, 1)
--	RETURN
--END

--IF (@accountbalance - @moneyAmount < 0)
--BEGIN
-- ROLLBACK
--	RAISERROR('Insufficient funds!', 16, 1)
--	RETURN
--END

--UPDATE Accounts 
--SET Balance  -= @moneyAmount
--WHERE Id = @accountId
--COMMIT

--18. Money Transfer:
--CREATE PROC usp_TransferMoney (@senderId INT, @receiverId INT, @amount DECIMAL(15, 4))
--AS
--BEGIN TRANSACTION
--EXEC usp_WithdrawMoney @senderId, @amount
--EXEC usp_DepositMoney @receiverId, @amount
--COMMIT

--20. *Massive Shopping:
--DECLARE @userGameId INT = (SELECT Id FROM UsersGames WHERE UserId = 9 AND GameId = 87)
--DECLARE @stamatCash DECIMAL(15, 2) = (SELECT Cash FROM UsersGames WHERE Id = @userGameId)
--DECLARE @itemsPrice DECIMAL(15, 2) = (SELECT SUM(Price) AS TotalPrice FROM Items WHERE MinLevel BETWEEN 11 AND 12)

--IF(@stamatCash >= @itemsPrice)
--BEGIN
--	BEGIN TRANSACTION
--		UPDATE UsersGames
--		SET Cash -= @itemsPrice
--		WHERE Id = @userGameId

--		INSERT INTO UserGameItems (ItemId, UserGameId)
--		SELECT Id, @userGameId FROM Items WHERE MinLevel BETWEEN 11 AND 12
--	COMMIT
--END

--SET @stamatCash = (SELECT Cash FROM UsersGames WHERE Id = @userGameId)
--SET @itemsPrice = (SELECT SUM(Price) AS TotalPrice FROM Items WHERE MinLevel BETWEEN 19 AND 21)

--IF(@stamatCash >= @itemsPrice)
--BEGIN
--	BEGIN TRANSACTION
--		UPDATE UsersGames
--		SET Cash -= @itemsPrice
--		WHERE Id = @userGameId

--		INSERT INTO UserGameItems (ItemId, UserGameId)
--		SELECT Id, @userGameId FROM Items WHERE MinLevel BETWEEN 19 AND 21
--	COMMIT
--END

--SELECT i.Name
--    FROM Users AS u
--	JOIN UsersGames ug ON ug.UserId = u.Id
--	JOIN Games g ON g.Id = ug.GameId
--	JOIN UserGameItems ugi ON ugi.UserGameId = ug.Id
--	JOIN Items i ON i.Id = ugi.ItemId
--WHERE u.Username = 'Stamat' AND g.Name = 'Safflower'
--ORDER BY i.Name

--21. Employees with Three Projects:
--CREATE PROC usp_AssignProject(@employeeId INT, @projectId INT)
--AS
--BEGIN TRANSACTION
--DECLARE @employee INT = (SELECT EmployeeID From Employees WHERE EmployeeID = @employeeId)
--DECLARE @project INT = (SELECT ProjectID From Projects WHERE ProjectID = @projectId)

--IF(@employee IS NULL OR @project IS NULL)
--BEGIN 
--	ROLLBACK	
--	RAISERROR('Invalid employee or project ID!', 16, 1)
--	RETURN
--END

--DECLARE @employeeProjects INT = (SELECT COUNT(*) FROM EmployeesProjects WHERE EmployeeID = @employeeId)
--IF(@employeeProjects >= 3)
--BEGIN
--	ROLLBACK
--	RAISERROR('The employee has too many projects!', 16, 2)
--	RETURN
--END

--INSERT INTO EmployeesProjects (EmployeeID, ProjectID) VALUES (@employeeId, @projectId)
--COMMIT

--22. Delete Employees:
--CREATE TABLE Deleted_Employees
--(
--	EmployeeID INT PRIMARY KEY,
--	FirstName VARCHAR(30),
--	LastName VARCHAR(30),
--	MiddleName VARCHAR(30),
--	JobTitle VARCHAR(30),
--	DepartmentID INT,
--	Salary DECIMAL(15,2)
--)

--CREATE TRIGGER tr_DeletedEmployees ON Employees FOR DELETE
--AS
--INSERT INTO Deleted_Employees (FirstName, LastName, MiddleName, JobTitle, DepartmentID, Salary)
--SELECT FirstName, LastName, MiddleName, JobTitle, DepartmentID, Salary FROM deleted