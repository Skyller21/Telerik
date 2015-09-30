

--04.find all information about all departments 
SELECT * 
FROM Departments

--05.find all department names
SELECT Name AS [Department Name]
FROM Departments

--06.find the salary of each employee
SELECT FirstName + ' ' + LastName AS [Full Name], Salary
FROM Employees

--07.full name of each employee
SELECT FirstName + ' ' + LastName AS [Full Name]
FROM Employees

--08.find the email addresses of each employee
SELECT FirstName + '.' + LastName + '@telerik.com' AS [Full Email Addresses]
FROM Employees

--09.find all different employee salaries
SELECT DISTINCT (Salary) AS [Distinct Salaries]
FROM Employees 
ORDER BY Salary

--10.find all information about the employees whose job title is “Sales Representative“.
SELECT *
FROM Employees e
WHERE e.JobTitle LIKE 'Sales%'

--11.find the names of all employees whose first name starts with "SA"
SELECT FirstName + ' ' + LastName AS [Full Name]
FROM Employees
WHERE FirstName LIKE 'SA%'
ORDER BY FirstName

--12.find the names of all employees whose lASt name contains "ei"
SELECT FirstName + ' ' + LastName AS [Full Name]
FROM Employees
WHERE LAStName LIKE '%ei%'
ORDER BY FirstName

--13.find the salary of all employees whose salary is in the range [20000…30000].
SELECT FirstName + ' ' + LastName AS [Full Name], Salary
FROM Employees
WHERE Salary>=20000 AND Salary<=30000
ORDER BY Salary

--14.find the names of all employees whose salary is 25000, 14000, 12500 or 23600.
SELECT FirstName + ' ' + LastName AS [Full Name], Salary
FROM Employees
WHERE Salary IN(12500,14000,23600,25000)
ORDER BY Salary

--15.find all employees that do not have manager
SELECT FirstName + ' ' + LastName AS [Full Name], 
ISNULL(CAST(ManagerID AS char(10)),'no manager') AS Manager
FROM Employees 
WHERE ManagerID IS NULL

--16.to find all employees that have salary more than 50000. Order them in decreASing order by salary.
SELECT FirstName + ' ' + LastName AS [Full Name], Salary
FROM Employees 
WHERE Salary>=50000
ORDER BY Salary DESC

--17.find the top 5 best paid employees
SELECT FirstName + ' ' + LastName AS [Full Name], Salary
FROM (SELECT TOP 5 Salary, FirstName, LAStName FROM Employees) es
ORDER BY Salary DESC

--another way 
SELECT TOP 5 FirstName + ' ' + LastName AS [Full Name], Salary
FROM
(SELECT * FROM Employees ) es 
ORDER BY Salary DESC

--18.find all employees along with their address.
SELECT e.FirstName + ' ' +e.LastName AS [Full Name], a.AddressText, a.TownID
FROM Employees e
	JOIN Addresses a 
		ON e.AddressID=a.AddressID

--19.find all employees and their address.
SELECT e.FirstName + ' ' +e.LastName AS [Full Name], a.AddressText, a.TownID
FROM Employees e,Addresses a 
WHERE e.AddressID=a.AddressID

--20.find all employees along with their manager.
SELECT e.FirstName + ' ' +e.LastName AS [Employee Full Name],m.FirstName + ' ' +m.LAStName AS [Manager Full Name]
FROM Employees e
	JOIN Employees m 
		ON e.ManagerID=m.EmployeeID

--21.find all employees, along with their manager and their address.
SELECT e.FirstName + ' ' +e.LastName AS [Employee Full Name],
	   m.FirstName + ' ' +m.LastName AS [Manager Full Name],
	   a.AddressText,a.TownID
FROM Employees e
	JOIN Employees m 
		ON e.ManagerID=m.EmployeeID
	JOIN Addresses a 
		ON e.AddressID=a.AddressID
ORDER BY e.FirstName

--22.find all departments and all town names AS a single list.
SELECT Name
FROM Departments
UNION
SELECT Name
FROM Towns

--23.find all the employees and the manager for each of them 
--along with the employees that do not have manager. 
SELECT e.FirstName + ' ' + e.LastName AS [Full Name],
ISNULL(m.FirstName + ' ' + m.LastName,N'øåô÷å') AS [Manager Name]
	FROM Employees e
		LEFT JOIN Employees m ON e.ManagerID = m.EmployeeID

--24.find the names of all employees from the departments
-- "Sales" and "Finance" whose hire year is between 1995 and 2005.
SELECT e.FirstName + ' ' + e.LastName AS [Full Name], d.Name AS [Department], e.HireDate
FROM Employees e 
	JOIN Departments d 
		ON e.DepartmentID = d.DepartmentID AND (d.Name = 'Sales' OR d.Name = 'Finance')
WHERE (CONVERT(datetime,e.HireDate,102) >= '1995' AND CONVERT(datetime,e.HireDate,102)<='2005')

SELECT E.FirstName + ' ' + e.LastName AS [Full Name], d.Name AS [Department], e.HireDate
FROM Employees e 
  JOIN Departments d
    ON d.DepartmentID=e.DepartmentID AND d.Name IN ('Sales','Finance')
WHERE e.HireDate BETWEEN '1995-1-1' AND '2005-1-1'

