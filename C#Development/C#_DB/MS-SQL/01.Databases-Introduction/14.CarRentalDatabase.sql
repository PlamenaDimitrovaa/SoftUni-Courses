CREATE DATABASE CarRental

USE CarRental

CREATE TABLE Categories
(
    Id INT PRIMARY KEY,
	CategoryName VARCHAR(20) NOT NULL,
	DailyRate INT,
	WeeklyRate INT,
	MonthlyRate INT,
	WeekendRate INT
)

INSERT INTO Categories VALUES 
(1, 'Sport', 5, 10, 15, 20),
(2, 'Family', 5, 10, 15, 20),
(3, 'Fun', 5, 10, 15, 20)

CREATE TABLE Cars
(
    Id INT PRIMARY KEY,
	PlateNumber VARCHAR(10) NOT NULL,
	Manufacturer VARCHAR(20) NOT NULL,
	Model VARCHAR(20) NOT NULL,
	CarYear INT NOT NULL,
	CategoryId INT NOT NULL,
	Doors INT NOT NULL,
	Picture VARCHAR(MAX),
	Condition VARCHAR(20),
	Available BIT NOT NULL
)

INSERT INTO Cars VALUES 
(1, '0123456789', 'Audi', 'A3', 1999, 3, 4, '', 'In bad condition', 1),
(2, '0123456789', 'BMW', 'E46', 2006, 8, 4, '', 'In good condition', 0),
(3, '0123456789', 'Mercedes', '220', 2008, 7, 2, '', 'In normal condition', 1)

CREATE TABLE Employees
(
    Id INT PRIMARY KEY,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	Title VARCHAR(20) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Employees VALUES
(1, 'Peter', 'Petrov', 'Cleaner', NULL),
(2, 'George', 'Georgiev', 'Driver', 'Some notes'),
(3, 'Anna', 'Petrova', 'Master', NULL)

CREATE TABLE Customers
(
    Id INT PRIMARY KEY,
	DriverLicenseNumber VARCHAR(10) NOT NULL,
	FullName VARCHAR(50) NOT NULL, 
	[Address] VARCHAR(20),
	City VARCHAR(20),
	ZIPCode VARCHAR(10) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Customers VALUES
(1, 'E1849MP', 'Anna Petrova', NULL, 'Plovdiv', '1849', NULL),
(2, 'SA1880MP', 'Peter Petrov', NULL, 'Sofia', '1880', NULL),
(3, 'E2580MP', 'George Smith', NULL, 'Velingrad', '4902', NULL)

CREATE TABLE RentalOrders
(
    Id INT PRIMARY KEY,
	EmployeeId INT NOT NULL,
	CustomerId INT NOT NULL,
	CarId INT NOT NULL,
	TankLevel INT NOT NULL,
	KilometrageStart DECIMAL(15,2),
	KilometrageEnd DECIMAL(15,2),
	TotalKilometrage DECIMAL(15,2),
	StartDate DATETIME,
	EndDate DATETIME,
	TotalDays INT,
	RateApplied INT,
	TaxRate DECIMAL(15,2), 
	OrderStatus VARCHAR(20) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO RentalOrders VALUES
(1, 15, 3, 8, 6, 15000, 16000, 1000, '5/8/2002', '6/8/2002', 30, 10, 300.20, 'Available', NULL),
(2, 15, 3, 8, 6, 20000, 22000, 2000, '5/8/2018', '8/8/2018', 90, 10, 80.20, 'In action', NULL),
(3, 15, 3, 8, 6, 19000, 31000, 22000, '5/8/2022', '5/16/2022', 8, 10, 30.20, 'Busy', NULL)