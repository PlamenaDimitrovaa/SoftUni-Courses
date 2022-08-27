--01. Find Names of All Employees by First Name:
--SELECT FirstName, LastName FROM Employees
--    WHERE FirstName LIKE 'SA%'

--02. Find Names of All Employees by Last Name:
--SELECT FirstName, LastName FROM Employees
--    WHERE LastName LIKE '%ei%'

--03. Find First Names of All Employess:
--SELECT FirstName FROM Employees 
--    WHERE DepartmentID IN (3, 10) AND YEAR(HireDate) BETWEEN 1995 AND 2005

--04. Find All Employees Except Engineers:
--SELECT FirstName, LastName FROM Employees
--    WHERE JobTitle NOT LIKE '%engineer%'

--05. Find Towns with Name Length:
--SELECT Name FROM Towns
--    WHERE LEN(Name) = 5 OR LEN(Name) = 6
--	ORDER BY Name ASC

--06. Find Towns Starting With:
--SELECT TownID, Name FROM Towns
--    WHERE LEFT(Name, 1) = 'M' OR LEFT(Name, 1) = 'K' OR LEFT(Name, 1) = 'B' OR LEFT(Name, 1) = 'E'
--	ORDER BY Name ASC

--07. Find Towns Not Starting With:
--SELECT TownID, Name FROM Towns
--    WHERE LEFT(Name, 1) != 'R' AND LEFT(Name, 1) != 'B' AND LEFT(Name, 1) != 'D'
--	ORDER BY Name ASC

--08. Create View Employees Hired After:
--CREATE VIEW V_EmployeesHiredAfter2000 AS
--SELECT FirstName, LastName FROM Employees
--    WHERE YEAR(HireDate) > 2000

--09. Length of Last Name:
--SELECT FirstName, LastName FROM Employees 
--    WHERE LEN(LastName) = 5

--10. Rank Employees by Salary:
--SELECT EmployeeID, FirstName, LastName, Salary,
--    DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS Rank
--	FROM Employees
--    WHERE Salary BETWEEN 10000 AND 50000
--	ORDER BY Salary DESC

--11. Find All Employees with Rank 2:
--SELECT *
--FROM (
--       SELECT EmployeeID,
--              FirstName,
--              LastName,
--              Salary,
--              DENSE_RANK() over (partition by Salary ORDER BY EmployeeID) AS Rank
--       FROM Employees
--       WHERE Salary BETWEEN 10000 AND 50000) AS MyTable
--WHERE Rank = 2
--ORDER BY Salary DESC

--12. Countries Holding 'A':
--SELECT CountryName AS [Country Name],
--       IsoCode AS [ISO Code]
--FROM Countries
--WHERE CountryName LIKE '%a%a%a%'
--ORDER BY IsoCode

--13. Mix of Peak and River Names:
--SELECT Peaks.PeakName,
--       Rivers.RiverName,
--       LOWER(CONCAT(LEFT(Peaks.PeakName, LEN(Peaks.PeakName)-1), Rivers.RiverName)) AS Mix
--FROM Peaks,
--     Rivers
--WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
--ORDER BY Mix

--14. Games From 2011 and 2012 Year:
--SELECT TOP (50) Name,
--    FORMAT(CAST(Start AS DATE), 'yyyy-MM-dd') AS [Start]
--FROM Games
--WHERE DATEPART(YEAR, Start) BETWEEN 2011 AND 2012
--ORDER BY Start, Name

--15. User Email Providers:
