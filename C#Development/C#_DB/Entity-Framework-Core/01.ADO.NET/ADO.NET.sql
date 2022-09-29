--CREATE DATABASE MinionsDB

--USE MinionsDB

--CREATE TABLE Countries(Id INT PRIMARY KEY,[Name] VARCHAR(50))

--INSERT INTO Countries (Id, Name) VALUES (1, 'Bulgaria'), (2, 'Norway'), (3, 'Cyrpus'), (4, 'Greece'), (5, 'UK')

--CREATE TABLE Towns(Id INT PRIMARY KEY,[Name] VARCHAR(50),CountryCode INT REFERENCES Countries(Id))

--INSERT INTO Towns (Id, Name, CountryCode) VALUES (1, 'Sofia', 1), (2, 'Oslo', 2), (3, 'Larnaca', 3), (4, 'Athens', 4), (5, 'London', 5)

--CREATE TABLE Minions(Id INT PRIMARY KEY,[Name] VARCHAR(50),Age INT,TownId INT REFERENCES Towns(Id))

--INSERT INTO Minions (Id, Name, Age, TownId) VALUES (1, 'Plamena', 20, 1), (2, 'Vais', 1, 2), (3, 'Oreo', 3, 3), (4, 'Bobi', 22, 4), (5, 'Pl', 25, 5)

--CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY,[Name] VARCHAR(50))

--INSERT INTO EvilnessFactors (Id, Name) VALUES (1, 'super good'), (2, 'good'), (3, 'bad'), (4, 'evil'), (5, 'super evil')

--CREATE TABLE Villains(Id INT PRIMARY KEY,[Name] VARCHAR(50),EvilnessFactorId INT REFERENCES EvilnessFactors(Id))

--INSERT INTO Villains (Id, Name, EvilnessFactorId) VALUES (1, 'Gru', 4), (2, 'Oreo', 1), (3, 'Vais', 3), (4, 'Bo', 5), (5, 'Pl', 2)

--CREATE TABLE MinionsVillains(MinionId INT REFERENCES Minions(Id),VillainId INT REFERENCES Villains(Id) CONSTRAINT PK_MinionsVillains PRIMARY KEY(MinionId, VillainId))

--INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (1, 1), (2, 2), (3, 3), (4, 4), (5, 5)

--SELECT * FROM Countries

--SELECT Name, COUNT(mv.MinionId)
--	FROM Villains v 
--	JOIN MinionsVillains mv ON mv.VillainId = v.Id
--		GROUP BY v.Id, v.Name