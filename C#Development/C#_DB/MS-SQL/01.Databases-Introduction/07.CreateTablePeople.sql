CREATE TABLE People
(
    Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARCHAR(MAX),
	Height DECIMAL(15,2),
	[Weight] DECIMAL(15,2),
	Gender VARCHAR(2) NOT NULL,
	Birthdate DATETIME NOT NULL,
	Biography NVARCHAR(MAX),
)

SET IDENTITY_INSERT People ON

INSERT INTO People 
(Id, [Name], Picture, Height, [Weight], Gender, Birthdate, Biography) 
VALUES
(1, 'Cirto', 'https://www.wired.com/story/stay-in-the-moment-take-a-picture/', 1.60, 45.00, 'm', '5/10/2003', NULL),
(2, 'fcnsnvgs', 'https://www.wired.com/story/stay-in-the-moment-take-a-picture/', 1.69, 58.00, 'f', '3/11/2001', NULL),
(3, 'Civbevbfdrto', 'https://www.wired.com/story/stay-in-the-moment-take-a-picture/', 1.80, 80.00, 'm', '1/3/2000', 'SOME BIOGRAPHY'),
(4, 'Cvdvdirto', 'https://www.wired.com/story/stay-in-the-moment-take-a-picture/', 1.90, 100.00, 'f', '8/6/1992', NULL),
(5, 'Cidvdfvdrto', 'https://www.wired.com/story/stay-in-the-moment-take-a-picture/', 1.50, 45.00, 'm', '7/5/2006', NULL)

SET IDENTITY_INSERT People OFF

SELECT * FROM People
