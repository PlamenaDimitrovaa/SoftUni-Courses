CREATE DATABASE Bakery
USE Bakery

CREATE TABLE Countries
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Customers
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(25) NOT NULL,
	LastName NVARCHAR(25) NOT NULL,
	Gender CHAR(1) NOT NULL CHECK(Gender IN ('M', 'F')),
	Age INT NOT NULL,
	PhoneNumber VARCHAR(10) NOT NULL CHECK(LEN(PhoneNumber) = 10),
	CountryId INT NOT NULL REFERENCES Countries(Id)
)

CREATE TABLE Products
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) UNIQUE NOT NULL,
	[Description] NVARCHAR(250) NOT NULL,
	Recipe NVARCHAR(MAX) NOT NULL,
	Price DECIMAL(19,4) NOT NULL CHECK(Price > 0)
)

CREATE TABLE Feedbacks
(
	Id INT PRIMARY KEY IDENTITY,
	[Description] NVARCHAR(255) NOT NULL,
	Rate DECIMAL(18,2) NOT NULL CHECK (Rate BETWEEN 0 AND 10),
	ProductId INT NOT NULL REFERENCES Products(Id),
	CustomerId INT NOT NULL REFERENCES Customers(Id)
)

CREATE TABLE Distributors
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) NOT NULL UNIQUE,
	AddressText NVARCHAR(30) NOT NULL,
	Summary NVARCHAR(200) NOT NULL,
	CountryId INT NOT NULL REFERENCES Countries(Id)
)

CREATE TABLE Ingredients 
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	[Description] NVARCHAR(200) NOT NULL,
	OriginCountryId INT NOT NULL REFERENCES Countries(Id),
	DistributorId INT NOT NULL REFERENCES Distributors(Id)
)

CREATE TABLE ProductsIngredients
(
	ProductId INT NOT NULL REFERENCES Products(Id),
	IngredientId INT NOT NULL REFERENCES Ingredients(Id)
	
	CONSTRAINT PK_ProductIngredient PRIMARY KEY(ProductId, IngredientId)
)

INSERT INTO Distributors ([Name], CountryId, AddressText, Summary)
VALUES
('Deloitte & Touche',	2,	'6 Arch St #9757',	'Customizable neutral traveling'),
('Congress Title',	13,	'58 Hancock St',	'Customer loyalty'),
('Kitchen People',	1,	'3 E 31st St #77',	'Triple-buffered stable delivery'),
('General Color Co Inc',	21,	'6185 Bohn St #72',	'Focus group'),
('Beck Corporation',	23,	'21 E 64th Ave',	'Quality-focused 4th generation hardware')

INSERT INTO Customers (FirstName, LastName, Age, Gender, PhoneNumber, CountryId)
VALUES
('Francoise',	'Rautenstrauch',	15,	'M',	'0195698399',	5),
('Kendra',	'Loud',	22,	'F',	'0063631526',	11),
('Lourdes',	'Bauswell',	50,	'M',	'0139037043',	8),
('Hannah',	'Edmison',	18,	'F',	'0043343686',	1),
('Tom',	'Loeza',	31,	'M',	'0144876096',	23),
('Queenie',	'Kramarczyk',	30,	'F',	'0064215793',	29),
('Hiu',	'Portaro',	25,	'M',	'0068277755',	16),
('Josefa',	'Opitz',	43,	'F',	'0197887645',	17)

UPDATE Ingredients
	SET DistributorId = 35
		WHERE Id IN (3, 23, 26)

UPDATE Ingredients
	SET OriginCountryId = 14
		WHERE OriginCountryId = 8

DELETE FROM Feedbacks
	WHERE CustomerId = 14 OR ProductId = 5

SELECT Name, Price, Description FROM Products
	ORDER BY Price DESC, Name

SELECT ProductId, Rate, Description, CustomerId, Age, Gender
	FROM Feedbacks AS f
	LEFT JOIN Customers AS c ON c.Id = f.CustomerId
	WHERE Rate < 5.0
	ORDER BY ProductId DESC, Rate

SELECT CONCAT(FirstName, ' ', LastName) AS CustomerName, PhoneNumber, Gender
	FROM Customers AS c
	LEFT JOIN Feedbacks AS f ON f.CustomerId = c.Id
	WHERE f.Id IS NULL
	ORDER BY c.Id

SELECT FirstName, Age, PhoneNumber
	FROM Customers
	WHERE (Age >= 21 AND CHARINDEX('an', FirstName) <> 0) 
		OR (RIGHT(PhoneNumber, 2) = '38' AND CountryId <> 31)
		ORDER BY FirstName, Age DESC

SELECT r.DistributorName, r.IngredientName, r.ProductName, r.AverageRate AS AverageRate 
FROM (SELECT d.[Name] AS DistributorName, i.[Name] AS IngredientName, p.[Name] AS ProductName, AVG(Rate) AS AverageRate
	FROM Distributors AS d
	JOIN Ingredients AS i ON i.DistributorId = d.Id
	JOIN ProductsIngredients AS pi ON pi.IngredientId = i.Id
	JOIN Products AS p ON p.Id = pi.ProductId
	JOIN Feedbacks AS f ON f.ProductId = p.Id
	GROUP BY d.[Name], i.[Name], p.[Name]) AS r
	WHERE AverageRate BETWEEN 5 AND 8
	ORDER BY DistributorName ASC, IngredientName ASC, ProductName ASC

SELECT r.CountryName, r.DisributorName  
FROM (SELECT c.[Name] AS CountryName, d.[Name] AS DisributorName,
			DENSE_RANK() OVER (PARTITION BY c.[Name] ORDER BY COUNT(i.Id) DESC) AS [Rank]
		FROM Countries c
		JOIN Distributors d ON c.Id = d.CountryId
		LEFT JOIN Ingredients i ON d.Id = i.DistributorId
		GROUP BY c.[Name], d.[Name]) AS r
WHERE r.[Rank] = 1
ORDER BY r.CountryName, r.DisributorName

CREATE VIEW v_UserWithCountries AS
	SELECT FirstName + ' ' + LastName AS CustomerName, Age, Gender, cn.[Name] 
		FROM Customers AS c 
		JOIN Countries AS cn ON cn.Id = c.CountryId

CREATE TRIGGER tr_DeleteRelations
ON Products INSTEAD OF DELETE
AS
	DECLARE @productId INT = (SELECT Id FROM deleted);

	DELETE FROM Feedbacks
		WHERE ProductId = @productId;

	DELETE FROM ProductsIngredients
		WHERE ProductId = @productId

	DELETE FROM Products WHERE Id = @productId