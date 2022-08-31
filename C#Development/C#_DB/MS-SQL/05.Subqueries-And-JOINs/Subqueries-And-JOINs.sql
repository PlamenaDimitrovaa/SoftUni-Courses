--01. Employee Address:
--SELECT TOP(5) EmployeeID AS [EmployeeId], JobTitle, a.AddressID AS [AddressId], a.AddressText 
--    FROM Employees e
--	JOIN Addresses a ON a.AddressID = e.AddressID
--	ORDER BY a.AddressID ASC

--02. Addresses with Towns:
 --SELECT TOP(50) e.FirstName, e.LastName, t.Name, a.AddressText 
 --    FROM Employees e
	-- LEFT JOIN Addresses a ON a.AddressID = e.AddressID
	-- LEFT JOIN Towns t ON a.TownID = t.TownID
	-- ORDER BY e.FirstName, e.LastName

--03. Sales Employees:
--SELECT e.EmployeeID, e.FirstName, e.LastName, d.Name AS DepartmentName
--    FROM Employees e
--	JOIN Departments d ON d.DepartmentID = e.DepartmentID
--	WHERE d.Name = 'Sales'
--	ORDER BY e.EmployeeID ASC

--04. Employee Departments:
--SELECT TOP(5) e.EmployeeID, e.FirstName, e.Salary, d.Name AS DepartmentName 
--    FROM Employees e
--	JOIN Departments d ON e.DepartmentID = d.DepartmentID
--	WHERE e.Salary > 15000
--	ORDER BY e.DepartmentID

--05. Employees Without Projects:
--SELECT TOP(3) e.EmployeeID, e.FirstName 
--    FROM Employees e
--    FULL JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID
--    WHERE ep.EmployeeID IS NULL
--    ORDER BY e.EmployeeID

--06. Employees Hired After:
--SELECT FirstName, LastName, HireDate, d.Name AS DeptName
--    FROM Employees e
--	JOIN Departments d ON e.DepartmentID = d.DepartmentID
--	WHERE e.HireDate > '1999-1-1' AND
--	(d.Name = 'Sales' OR d.Name = 'Finance')
--	ORDER BY HireDate

--07. Employees With Project:
--SELECT TOP(5) e.EmployeeID, e.FirstName, p.Name AS ProjectName
--    FROM Employees e
--	JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID
--	JOIN Projects p ON p.ProjectID = ep.ProjectID
--	WHERE p.StartDate > '2002-08-13' AND p.EndDate IS NULL
--	ORDER BY e.EmployeeID

--08. Employee 24:
--SELECT e.EmployeeID, FirstName,
--  CASE 
--   WHEN p.StartDate > '01/01/2005' THEN NULL
--   ELSE p.NAME
--  END 
--  FROM Employees e
--INNER JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
--INNER JOIN Projects p ON ep.ProjectID = p.ProjectID
--WHERE e.EmployeeID = 24

--09. Employee Manager:
--SELECT e.EmployeeID, e.FirstName, m.EmployeeID AS ManagerID, m.FirstName AS ManagerName
--    FROM Employees AS e
--        JOIN Employees AS m
--            ON m.EmployeeID = e.ManagerID
--        WHERE e.ManagerID IN (3,7) 
--    ORDER BY e.EmployeeID

--10. Employees Summary:
--SELECT TOP(50) e.EmployeeID, e.FirstName + ' ' + e.LastName AS [EmployeeName], em.FirstName + ' ' + em.LastName AS [ManagerName], d.Name AS DepartmentName 
--    FROM Employees e
--	LEFT JOIN Employees em ON e.ManagerID = em.EmployeeID
--	LEFT JOIN Departments d ON e.DepartmentID = d.DepartmentID
--	ORDER BY e.EmployeeID

--11. Min Average Salary:
--SELECT TOP(1) AVG(Salary) AS MinAverageSalary FROM Employees
--    GROUP BY DepartmentID
--	ORDER BY MinAverageSalary

--12. Highest Peaks in Bulgaria:
--SELECT mc.CountryCode ,m.MountainRange, p.PeakName, p.Elevation
--	FROM Mountains AS m
--	JOIN Peaks AS p ON m.Id = p.MountainId
--	JOIN MountainsCountries AS mc ON m.Id = mc.MountainId
--	WHERE p.Elevation > 2835
--	    AND mc.CountryCode = 'BG'
--	ORDER BY Elevation DESC

--13. Count Mountain Ranges:
--SELECT mc.CountryCode, COUNT(MountainRange) AS MountainRanges
--    FROM Mountains m
--	JOIN MountainsCountries mc ON m.Id = mc.MountainId 
--	WHERE CountryCode IN ('US', 'RU', 'BG')
--	GROUP BY mc.CountryCode

--14. Countries With or Without Rivers:
--SELECT TOP(5) CountryName, RiverName
--    FROM Countries c
--	LEFT JOIN CountriesRivers cr ON cr.CountryCode = c.CountryCode
--	LEFT JOIN Rivers r ON cr.RiverId = r.Id
--	WHERE c.ContinentCode = 'AF'
--	ORDER BY c.CountryName

--15. Continents and Currencies:
--SELECT rankedCurrencies.ContinentCode, rankedCurrencies.CurrencyCode, rankedCurrencies.Count
--FROM (SELECT c.ContinentCode, c.CurrencyCode, COUNT(c.CurrencyCode) AS [Count], DENSE_RANK() OVER (PARTITION BY c.ContinentCode ORDER BY COUNT(c.CurrencyCode) DESC) AS [rank] 
--FROM Countries AS c
--GROUP BY c.ContinentCode, c.CurrencyCode) AS rankedCurrencies
--WHERE rankedCurrencies.rank = 1 and rankedCurrencies.Count > 1

--16. Countries Without any Mountains:
--SELECT COUNT(c.CountryCode) AS CountryCode
--	FROM Countries c
--	LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
--	WHERE mc.MountainId IS NULL

--17. Highest Peak and Longest River by Country:
--SELECT TOP(5) c.CountryName, MAX(p.Elevation) AS HighestPeakElevation, MAX(r.Length) AS LongestRiverLength
--	FROM Countries c
--	LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
--	LEFT JOIN Peaks p ON p.MountainId = mc.MountainId
--	LEFT JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
--	LEFT JOIN Rivers r ON cr.RiverId = r.Id
--	GROUP BY c.CountryName
--	ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, c.CountryName

--18. Highest Peak Name and Elevation by Country:
--SELECT TOP (5) WITH TIES c.CountryName, ISNULL(p.PeakName, '(no highest peak)') AS 'HighestPeakName', ISNULL(MAX(p.Elevation), 0) AS 'HighestPeakElevation', ISNULL(m.MountainRange, '(no mountain)')
--	FROM Countries c
--	LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
--	LEFT JOIN Mountains m ON mc.MountainId = m.Id
--	LEFT JOIN Peaks p ON m.Id = p.MountainId
--	GROUP BY c.CountryName, p.PeakName, m.MountainRange
--	ORDER BY c.CountryName, p.PeakName