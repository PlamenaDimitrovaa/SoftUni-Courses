CREATE DATABASE Bitbucket

USE Bitbucket

CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(30) NOT NULL,
	Email VARCHAR(50) NOT NULL
)

CREATE TABLE Repositories
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE RepositoriesContributors
(
	RepositoryId INT NOT NULL REFERENCES Repositories(Id),
	ContributorId INT NOT NULL REFERENCES Users(Id)

	CONSTRAINT PK_RepositoryContributor PRIMARY KEY (RepositoryId, ContributorId)
)

CREATE TABLE Issues
(
	Id INT PRIMARY KEY IDENTITY,
	Title VARCHAR(255) NOT NULL,
	IssueStatus VARCHAR(6) NOT NULL,
	RepositoryId INT NOT NULL REFERENCES Repositories(Id),
	AssigneeId INT NOT NULL REFERENCES Users(Id)
)

CREATE TABLE Commits
(
	Id INT PRIMARY KEY IDENTITY,
	[Message] VARCHAR(255) NOT NULL,
	IssueId INT REFERENCES Issues(Id),
	RepositoryId INT NOT NULL REFERENCES Repositories(Id),
	ContributorId INT NOT NULL REFERENCES Users(Id)
)

CREATE TABLE Files
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL,
	Size DECIMAL(18,2) NOT NULL,
	ParentId INT REFERENCES Files(Id),
	CommitId INT NOT NULL REFERENCES Commits(Id)
)

INSERT INTO Files ([Name], Size, ParentId, CommitId) 
	VALUES
('Trade.idk',	2598.0,	1,	1),
('menu.net',	9238.31,	2,	2),
('Administrate.soshy',	1246.93,	3,	3),
('Controller.php',	7353.15,	4,	4),
('Find.java',	9957.86,	5,	5),
('Controller.json',	14034.87,	3,	6),
('Operate.xix',	7662.92,	7,	7)

INSERT INTO Issues (Title, IssueStatus, RepositoryId, AssigneeId)
	VALUES
('Critical Problem with HomeController.cs file',	'open',	1,	4),
('Typo fix in Judge.html',	'open',	4,	3),
('Implement documentation for UsersService.cs',	'closed',	8,	2),
('Unreachable code in Index.cs',	'open',	9,	8)

UPDATE Issues 
	SET IssueStatus = 'closed'
		WHERE AssigneeId = 6

DELETE FROM RepositoriesContributors
	WHERE RepositoryId = 3
DELETE FROM Issues
	WHERE RepositoryId = 3
DELETE FROM Files
	WHERE CommitId = 36
DELETE FROM Commits
	WHERE RepositoryId = 3
DELETE FROM Repositories
	WHERE [Name] = 'Softuni-Teamwork'

SELECT Id, Message, RepositoryId, ContributorId FROM Commits
ORDER BY Id ASC, Message ASC, RepositoryId ASC, ContributorId ASC

SELECT Id, Name, Size FROM Files
	WHERE Size > 1000 AND Name LIKE '%html%'
	ORDER BY Size DESC, Id ASC, Name ASC

SELECT i.Id, Username + ' : ' +  Title AS IssueAssignee FROM Issues AS i
	JOIN Users AS u ON i.AssigneeId = u.Id
	ORDER BY i.Id DESC, IssueAssignee ASC 

SELECT Id, Name, CONCAT(Size, 'KB') AS Size FROM Files
	WHERE Id NOT IN (SELECT ParentId FROM Files WHERE ParentId IS NOT NULL)
	ORDER BY Id ASC, Name ASC, Size DESC

SELECT TOP 5 r.Id, r.Name, COUNT(c.RepositoryId) AS Commits FROM Commits AS c
    JOIN Repositories AS r ON r.Id = c.RepositoryId
	JOIN RepositoriesContributors AS rc ON rc.RepositoryId = r.Id
	GROUP BY r.Id, [Name]
	ORDER BY Commits DESC, r.Id ASC, r.Name

SELECT Username, AVG(f.Size) AS AVERAGE FROM Users AS u
	JOIN Commits AS c ON u.Id = c.ContributorId
	JOIN Files AS f ON f.CommitId = c.Id
	GROUP BY Username
	ORDER BY AVERAGE DESC, Username ASC


CREATE FUNCTION udf_AllUserCommits(@username VARCHAR(30))
RETURNS INT
AS
BEGIN
	DECLARE @Result INT = (SELECT COUNT(c.Id) FROM Users AS u 
												JOIN Commits AS c ON c.ContributorId = u.Id
													WHERE Username = @username)
	RETURN @Result
END



CREATE PROCEDURE usp_SearchForFiles(@fileExtension VARCHAR(10))
AS
BEGIN 
	SELECT Id, Name, CONCAT(Size, 'KB') FROM Files
			WHERE Name LIKE '%.' + @fileExtension
				ORDER BY Id, Name, Size DESC
END