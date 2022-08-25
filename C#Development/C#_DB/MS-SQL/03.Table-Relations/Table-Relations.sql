
--01. One-To-One Relationship: 
--CREATE TABLE Passports
--(
--    PassportID INT PRIMARY KEY,
--	PassportNumber CHAR(8)
--)

--CREATE TABLE Persons
--(
--    PersonID INT IDENTITY PRIMARY KEY,
--	FirstName NVARCHAR(50) NOT NULL,
--	Salary DECIMAL(15,2),
--	PassportID INT UNIQUE FOREIGN KEY REFERENCES Passports(PassportID)
--)

--02. One-To-Many Relationship:
--CREATE TABLE Manufacturers
--(
--    ManufacturerID INT PRIMARY KEY,
--	Name VARCHAR(50) NOT NULL,
--	EstablishedOn DATETIME
--)

--CREATE TABLE Models
--(
--    ModelID INT PRIMARY KEY,
--	Name VARCHAR(50) NOT NULL,
--	ManufacturerID INT NOT NULL FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
--)

--03. Many-To-Many Relationship:
--CREATE TABLE Students 
--(
--    StudentID INT IDENTITY PRIMARY KEY,
--	Name VARCHAR(30) NOT NULL
--)

--CREATE TABLE Exams
--(
--    ExamID INT IDENTITY PRIMARY KEY,
--	Name VARCHAR(30) NOT NULL
--)

--CREATE TABLE StudentsExams 
--(
--  StudentID INT,
--	ExamID INT,
--	CONSTRAINT PK_StudentsExams
--	PRIMARY KEY(StudentID, ExamID),
--	CONSTRAINT FK_StudentsExams_Students
--	FOREIGN KEY(StudentID)
--	REFERENCES Students(StudentID),
--	CONSTRAINT FK_StudentsExams_Exams
--	FOREIGN KEY(ExamID)
--	REFERENCES Exams(ExamID)
--)

--04. Self-Referencing:
--CREATE TABLE Teachers
--(
--    TeacherID INT PRIMARY KEY IDENTITY(101,1),
--	Name VARCHAR(30) NOT NULL,
--	ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
--)


--05. Online Store Database:
--CREATE TABLE Cities
--(
--    CityID INT PRIMARY KEY IDENTITY,
--	Name VARCHAR(50) NOT NULL
--)

--CREATE TABLE Customers
--(
--    CustomerID INT PRIMARY KEY IDENTITY,
--	Name VARCHAR(40) NOT NULL,
--	Birthday DATE,
--	CityID INT FOREIGN KEY REFERENCES Cities(CityID)
--)

--CREATE TABLE Orders
--(
--    OrderID INT PRIMARY KEY IDENTITY,
--	CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID)
--)

--CREATE TABLE ItemTypes
--(
--    ItemTypeID INT PRIMARY KEY IDENTITY,
--	Name VARCHAR(50) NOT NULL
--)

--CREATE TABLE Items
--(
--    ItemID INT PRIMARY KEY IDENTITY,
--	Name VARCHAR(50) NOT NULL,
--	ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID)
--)

--CREATE TABLE OrderItems
--(
--    OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
--	ItemID INT FOREIGN KEY REFERENCES Items(ItemID),
--	CONSTRAINT PK_OrderItem PRIMARY KEY (OrderID, ItemID)
--)

--06. University Database:
--CREATE DATABASE Majors
--Use Majors
--CREATE TABLE Majors 
--(
--    MajorID INT PRIMARY KEY IDENTITY,
--	Name VARCHAR(50) NOT NULL
--)

--CREATE TABLE Students
--(
--    StudentID INT PRIMARY KEY IDENTITY,
--	StudentNumber INT NOT NULL,
--	StudentName VARCHAR(50) NOT NULL,
--	MajorID INT FOREIGN KEY REFERENCES Majors(MajorID)
--)

--CREATE TABLE Subjects
--(
--    SubjectID INT PRIMARY KEY IDENTITY,
--	SubjectName VARCHAR(50) NOT NULL
--)

--CREATE TABLE Agenda
--(
--    StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
--	SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID),
--	CONSTRAINT PK_StudentSubject PRIMARY KEY(StudentID, SubjectID)
--)

--CREATE TABLE Payments
--(
--    PaymentID INT PRIMARY KEY IDENTITY,
--	PaymentDate DATE,
--	PaymentAmount DECIMAL(15,2),
--	StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
--)

--09. *Peaks in Rila:
--SELECT m.MountainRange, p.PeakName, p.Elevation 
--    FROM Peaks AS p
--	JOIN Mountains AS m ON p.MountainId = m.Id
--	WHERE MountainRange = 'Rila'
--	ORDER BY p.Elevation DESC