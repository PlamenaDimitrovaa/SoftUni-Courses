
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


--06. University Database:

--09. *Peaks in Rila:
--SELECT m.MountainRange, p.PeakName, p.Elevation 
--    FROM Peaks AS p
--	JOIN Mountains AS m ON p.MountainId = m.Id
--	WHERE MountainRange = 'Rila'
--	ORDER BY p.Elevation DESC