CREATE DATABASE Hotel

USE Hotel

CREATE TABLE Employees
(
    Id INT PRIMARY KEY,
	FirstName VARCHAR(90) NOT NULL,
	LastName VARCHAR(90) NOT NULL,
	Title VARCHAR(50) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Employees (Id, FirstName, LastName, Title, Notes) VALUES
(1, 'Gosho', 'Goshev', 'CEO', NULL),
(2, 'Pl', 'Pl', 'CFO', 'random note'),
(3, 'Vais', 'Dim', 'CTO', NULL)

CREATE TABLE Customers
(
    AccountNumber INT PRIMARY KEY,
	FirstName VARCHAR(90) NOT NULL,
	LastName VARCHAR(90) NOT NULL,
	PhoneNumber CHAR(10) NOT NULL,
	EmergencyName VARCHAR(90) NOT NULL,
	EmergencyNumber CHAR(10) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Customers VALUES
(120, 'Pipi', 'Loa', '0123456789', 'T', '0123456789', NULL),
(121, 'Pesho', 'Loa', '0123456789', 'T', '0123456789', NULL),
(122, 'Gosho', 'Loa', '0123456789', 'T', '0123456789', NULL)

CREATE TABLE RoomStatus
(
    RoomStatus VARCHAR(20) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO RoomStatus VALUES
('Cleaning', NULL),
('Free', NULL),
('Busy', NULL)

CREATE TABLE RoomTypes
(
    RoomType VARCHAR(20) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO RoomTypes VALUES
('Apartment', NULL),
('Maison', NULL),
('One Bedroom', NULL)

CREATE TABLE BedTypes
(
    BedType VARCHAR(20) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO BedTypes VALUES
('Single', NULL),
('Double', NULL),
('Child bed', NULL)

CREATE TABLE Rooms
(
    RoomNumber INT PRIMARY KEY,
	RoomType VARCHAR(20) NOT NULL,
	BedType VARCHAR(20) NOT NULL,
	Rate INT,
	RoomStatus VARCHAR(20) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Rooms VALUES
(120, 'Apartment', 'Double', 10, 'Free', NULL),
(121, 'Maison', 'Child bed', 5, 'Cleaning', NULL),
(122, 'One Bedroom', 'Single', 3, 'Busy', NULL)

CREATE TABLE Payments 
(
    Id INT PRIMARY KEY,
	EmployeeId INT NOT NULL,
	PaymentDate DATETIME NOT NULL,
	AccountNumber INT NOT NULL,
	FirstDateOccupied DATETIME NOT NULL,
	LastDateOccupied DATETIME NOT NULL,
	TotalDays INT NOT NULL,
	AmountCharged DECIMAL(15,2),
	TaxRate INT,
	TaxAmount INT,
	PaymentTotal DECIMAL(15,2),
	Notes VARCHAR(MAX)
)

INSERT INTO Payments VALUES 
(1, 1, GETDATE(), 120, '5/5/2012', '5/8/2012', 3, 450.23, NULL, NULL, 450.23, NULL),
(2, 1, GETDATE(), 121, '5/9/2012', '5/12/2012', 3, 650.00, NULL, NULL, 650.00, NULL),
(3, 1, GETDATE(), 123, '3/17/2012', '3/20/2012', 3, 215.02, NULL, NULL, 215.02, NULL)

CREATE TABLE Occupancies
(
    Id INT PRIMARY KEY,
	EmployeeId INT NOT NULL,
	DateOccupied DATETIME NOT NULL,
	AccountNumber INT NOT NULL,
	RoomNumber INT NOT NULL,
	RateApplied INT,
	PhoneCharge DECIMAL(15,2),
	Notes VARCHAR(MAX)
)

INSERT INTO Occupancies VALUES
(1, 120, GETDATE(), 120, 120, 10, 5, NULL),
(2, 121, GETDATE(), 121, 125, 8, 3, NULL),
(3, 123, GETDATE(), 123, 128, 7, 6, NULL)