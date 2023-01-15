CREATE DATABASE Minions

USE Minions

CREATE TABLE Minions(
	Id INT PRIMARY KEY,
	[Name] NVARCHAR(20),
	Age INT,
)

CREATE TABLE Towns(
	Id INT PRIMARY KEY,
	[Name] NVARCHAR(20)
)

ALTER TABLE Minions
	ADD TownId INT

ALTER TABLE Minions
	ADD FOREIGN KEY (TownId) REFERENCES Towns(Id)

INSERT INTO Towns (Id, [Name]) VALUES 
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

INSERT INTO Minions (Id, [Name], Age, TownId) VALUES 
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward', NULL, 2)

TRUNCATE TABLE Minions

DROP TABLE Minions, Towns

CREATE TABLE People (
	Id INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(8000),
	Height DECIMAL(15,2),
	[Weight] DECIMAL(15,2),
	Gender CHAR(1) NOT NULL,
	Birthdate DATETIME2 NOT NULL,
	Biography NVARCHAR(MAX)
)

INSERT INTO People ([Name], Picture, Height, [Weight], Gender, Birthdate, Biography) VALUES
('Pesho', 8, 1.80, 60, 'm', '10-20-1998', 'Some biography'),
('Pesho1', 9, 1.70, 82, 'm', '11-20-1998', 'Some biography'),
('Pesho2', 1, 1.60, 98, 'm', '08-16-1990', 'Some biography'),
('Pesho3', 0, 1.92, 90, 'm', '10-20-1997', 'Some biography'),
('Pesho4', 3, 1.87, 80, 'm', '10-20-1993', 'Some biography')


CREATE TABLE Users
(
    Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(30) NOT NULL,
	ProfilePicture VARCHAR(MAX),
	LastLoginTime DATETIME,
	IsDeleted BIT
)

INSERT INTO Users 
(Username, [Password], ProfilePicture, LastLoginTime, isDeleted)
VALUES
('pl', 'parola', 'https://cdn.pixabay.com/photo/2015/04/23/22/00/tree-736885__480.jpg', '1/12/2021', 0),
('bo', 'paddrola', 'https://cdn.pixabay.com/photo/2015/04/23/22/00/tree-736885__480.jpg', '3/5/2021', 0),
('a', 'paroaala', 'https://cdn.pixabay.com/photo/2015/04/23/22/00/tree-736885__480.jpg', '1/12/2020', 1),
('v', 'parogbtfla', 'https://cdn.pixabay.com/photo/2015/04/23/22/00/tree-736885__480.jpg', '5/11/2021', 0),
('o', 'pardgdola', 'https://cdn.pixabay.com/photo/2015/04/23/22/00/tree-736885__480.jpg', '1/8/2021', 1)


ALTER TABLE Users
	DROP CONSTRAINT PK__Users__3214EC07D283D5D8

ALTER TABLE Users
	ADD CONSTRAINT PK_IdUsername PRIMARY KEY (Id, Username)

ALTER TABLE Users
ADD CONSTRAINT PK_Id PRIMARY KEY (Id)

ALTER TABLE Users
DROP CONSTRAINT PK_IdUsername

ALTER TABLE Users
	ADD CONSTRAINT CH_PasswordIsAtLeast5Symbols CHECK (LEN([Password]) > 5)	

ALTER TABLE Users
	ADD CONSTRAINT CH_UsernameAtLeast3Symbols CHECK (LEN(Username) > 3)

ALTER TABLE Users
	ADD CONSTRAINT DF_LastLoginTime DEFAULT GETDATE() FOR LastLoginTime


