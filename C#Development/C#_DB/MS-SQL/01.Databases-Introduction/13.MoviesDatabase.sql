CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors
(
    Id INT PRIMARY KEY,
	DirectorName VARCHAR(20) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Directors VALUES
(1, 'John', NULL),
(2, 'Sara', NULL),
(3, 'Peter', NULL),
(4, 'George', NULL),
(5, 'Anna', NULL)

CREATE TABLE Genres
(
    Id INT PRIMARY KEY,
    GenreName VARCHAR(20) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Genres VALUES
(1, 'MALE', NULL),
(2, 'FEMALE', NULL),
(3, 'MALE', NULL),
(4, 'FEMALE', 'SOME NOTES'),
(5, 'MALE', NULL)

CREATE TABLE Categories
(
    Id INT PRIMARY KEY,
	CategoryName VARCHAR(20) NOT NULL, 
	Notes VARCHAR(MAX)
)

INSERT INTO Categories VALUES
(1, 'Action', NULL),
(2, 'Horror', 'A Horror Movie'),
(3, 'Fiction', NULL),
(4, 'Romance', NULL),
(5, 'Science', NULL)

CREATE TABLE Movies
(
    Id INT PRIMARY KEY,
    Title VARCHAR(20) NOT NULL, 
	DirectorId INT NOT NULL, 
	CopyrightYear DATETIME,
	[Length] DECIMAL(15,2),
	GenreId INT NOT NULL, 
	CategoryId INT NOT NULL, 
	Rating INT, 
	Notes VARCHAR(MAX)
)

INSERT INTO Movies VALUES
(1, 'Home Alone', 5, '5/8/1990', 2.15, 3, 5, 10, NULL),
(2, 'San Andreas', 4, '5/8/2000', 3.20, 2, 6, 10, 'Some description'),
(3, 'The shark', 3, '5/8/1990', 2.15, 1, 8, 2, NULL),
(4, 'The dog', 2, '5/8/1990', 2.15, 4, 9, 3, NULL),
(5, 'The lost city', 1, '5/8/1990', 2.15, 3, 7, 10, 'Some notes')
