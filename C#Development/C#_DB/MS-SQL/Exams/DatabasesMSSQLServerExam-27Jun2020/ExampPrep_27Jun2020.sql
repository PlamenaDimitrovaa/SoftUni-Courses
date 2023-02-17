CREATE DATABASE WMS
USE WMS

CREATE TABLE Clients
(
	ClientId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Phone CHAR(12) NOT NULL CHECK(LEN(Phone) = 12)
)

CREATE TABLE Mechanics
(
	MechanicId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	[Address] VARCHAR(255) NOT NULL
)

CREATE TABLE Models
(
	ModelId INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) UNIQUE NOT NULL,
)

CREATE TABLE Jobs
(
	JobId INT PRIMARY KEY IDENTITY,
	ModelId INT NOT NULL REFERENCES Models(ModelId),
	[Status] VARCHAR(11) NOT NULL DEFAULT('Pending') CHECK([Status] IN ('Pending', 'In Progress', 'Finished')),
	ClientId INT NOT NULL REFERENCES Clients(ClientId),
	MechanicId INT REFERENCES Mechanics(MechanicId),
	IssueDate DATE NOT NULL,
	FinishDate DATE 
)

CREATE TABLE Orders 
(
	OrderId INT PRIMARY KEY IDENTITY,
	JobId INT NOT NULL REFERENCES Jobs(JobId),
	IssueDate DATE,
	Delivered BIT DEFAULT(0)
)

CREATE TABLE Vendors
(
	VendorId INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Parts
(
	PartId INT PRIMARY KEY IDENTITY,
	SerialNumber VARCHAR(50) UNIQUE NOT NULL,
	[Description] VARCHAR(255),
	Price DECIMAL(6, 2) NOT NULL CHECK(Price > 0),
	VendorId INT NOT NULL REFERENCES Vendors(VendorId),
	StockQty INT NOT NULL DEFAULT(0) CHECK(StockQty >= 0)
)

CREATE TABLE OrderParts
(
	OrderId INT NOT NULL REFERENCES Orders(OrderId),
	PartId INT NOT NULL REFERENCES Parts(PartId),
	Quantity INT NOT NULL DEFAULT(1) CHECK(Quantity > 0)

	CONSTRAINT PK_OrdersParts PRIMARY KEY (OrderId, PartId)
)

CREATE TABLE PartsNeeded
(
	JobId INT NOT NULL REFERENCES Jobs(JobId),
	PartId INT NOT NULL REFERENCES Parts(PartId),
	Quantity INT NOT NULL DEFAULT(1) CHECK(Quantity > 0)

	CONSTRAINT PK_JobsParts PRIMARY KEY (JobId, PartId)
)

INSERT INTO Clients (FirstName, LastName, Phone)
	VALUES
('Teri',	'Ennaco',	'570-889-5187'),
('Merlyn',	'Lawler',	'201-588-7810'),
('Georgene',	'Montezuma',	'925-615-5185'),
('Jettie',	'Mconnell',	'908-802-3564'),
('Lemuel',	'Latzke',	'631-748-6479'),
('Melodie',	'Knipp',	'805-690-1682'),
('Candida',	'Corbley',	'908-275-8357')

INSERT INTO Parts (SerialNumber, Description, Price, VendorId)
	VALUES
('WP8182119',	'Door Boot Seal',	117.86,	2),
('W10780048',	'Suspension Rod',	42.81,	1),
('W10841140',	'Silicone Adhesive', 	6.77,	4),
('WPY055980',	'High Temperature Adhesive',	13.94,	3)

UPDATE Jobs
	SET [Status] = 'In Progress', MechanicId = 3
		WHERE [Status] = 'Pending'

DELETE FROM OrderParts
	WHERE OrderId = 19

DELETE FROM Orders
	WHERE OrderId = 19

SELECT FirstName + ' ' + LastName AS Mechanic, [Status], IssueDate FROM Mechanics AS m
	JOIN Jobs AS j ON j.MechanicId = m.MechanicId
	ORDER BY m.MechanicId, IssueDate, JobId

SELECT  FirstName + ' ' + LastName AS Client, DATEDIFF(DAY, IssueDate, '04/24/2017') AS DaysGoing, [Status]
	FROM Clients AS c
	JOIN Jobs AS j ON j.ClientId = c.ClientId
	WHERE [Status] <> 'Finished'
	ORDER BY DaysGoing DESC, c.ClientId
	
SELECT FirstName + ' ' + LastName AS Mechanic, AVG(DATEDIFF(DAY, IssueDate, FinishDate)) 
	FROM Mechanics AS m
	JOIN Jobs AS j ON j.MechanicId = m.MechanicId
	GROUP BY FirstName + ' ' + LastName, m.MechanicId
	ORDER BY m.MechanicId

SELECT FirstName + ' ' + LastName AS Available 
	FROM Mechanics AS m
	LEFT JOIN Jobs AS j ON j.MechanicId = m.MechanicId
	WHERE j.JobId IS NULL OR (SELECT COUNT(JobId)
								FROM Jobs 
								WHERE Status <> 'Finished' AND MechanicId = m.MechanicId
								GROUP BY MechanicId, Status) IS NULL
	GROUP BY m.MechanicId, (FirstName + ' ' + LastName)
	ORDER BY m.MechanicId

SELECT j.JobId, ISNULL(SUM(p.Price * op.Quantity), 0) AS Total
	FROM Jobs AS j
	LEFT JOIN Orders AS o ON o.JobId = j.JobId
	LEFT JOIN OrderParts AS op ON op.OrderId = o.OrderId
	LEFT JOIN Parts AS p ON p.PartId = op.PartId
	WHERE j.[Status] = 'Finished'
	GROUP BY j.JobId
	ORDER BY Total DESC, j.JobId

SELECT p.PartId, p.Description,
		SUM(pn.Quantity) AS Required,
		SUM(p.StockQty) AS InStock, 0 AS Ordered
	FROM Jobs j
FULL JOIN Orders o ON j.JobId = o.JobId
	JOIN PartsNeeded pn ON pn.JobId = j.JobId
	JOIN Parts p ON p.PartId = pn.PartId
		WHERE j.Status != 'Finished' AND o.Delivered IS NULL
	GROUP BY p.PartId, p.Description
		HAVING SUM(p.StockQty) < SUM(pn.Quantity)

CREATE PROC usp_PlaceOrder
(
	@jobId INT,
	@serialNumber VARCHAR(50),
	@qty INT
) AS

DECLARE @status VARCHAR(10) = (SELECT Status FROM Jobs WHERE JobId = @jobId)
DECLARE @partId VARCHAR(10) = (SELECT PartId FROM Parts WHERE SerialNumber = @serialNumber)

IF(@qty <= 0)
	THROW 50012, 'Part quantity must be more than zero!', 1
ELSE IF(@status IS NULL)
	THROW 50013, 'Job not found!', 1
ELSE IF(@status = 'Finished')
	THROW 50011, 'This job is not active!', 1
ELSE IF(@partId IS NULL)
	THROW 50014, 'Part not found!', 1

DECLARE @orderId INT = (SELECT o.OrderId
						FROM Orders o
						WHERE JobId = @jobId AND IssueDate IS NULL) 

IF(@orderId IS NULL)
BEGIN
	INSERT INTO Orders (JobId, IssueDate) VALUES (@jobId, NULL)
END

    SET	@orderId = (SELECT o.OrderId FROM Orders o WHERE JobId = @jobId AND o.IssueDate IS NULL) 

	DECLARE @orderPartExists INT = (SELECT OrderId FROM OrderParts WHERE OrderId = @orderId AND PartId = @partId)

	IF(@orderPartExists IS NULL)
	BEGIN
		INSERT INTO OrderParts (OrderId, PartId, Quantity) VALUES (@orderId, @partId, @qty)
	END
ELSE
BEGIN
	UPDATE OrderParts
	SET Quantity += @qty
	WHERE OrderID = @orderId AND PartId = @partId
END

CREATE FUNCTION udf_GetCost(@jobID INT)
RETURNS DECIMAL(6,2)
AS
BEGIN 
	DECLARE @Result DECIMAL(6,2) = (SELECT SUM(op.Quantity * p.Price) AS TotalSum
		FROM Jobs AS j
		JOIN Orders AS o ON j.JobId = o.JobId
		JOIN OrderParts AS op ON op.OrderId = o.OrderId
		JOIN Parts AS p ON p.PartId = op.PartId
		WHERE j.JobId = @jobID
		GROUP BY j.JobId)

		IF(@Result IS NULL)
			SET @Result = 0
	RETURN @Result
END