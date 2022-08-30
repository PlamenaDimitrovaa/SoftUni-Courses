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
	