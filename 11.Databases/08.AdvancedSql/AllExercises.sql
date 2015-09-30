--01.find the names and salaries of the employees that take the minimal salary in the company.
SELECT FirstName + ' ' + LastName AS [Full Name],Salary
FROM Employees 
WHERE Salary =(SELECT MIN(SALARY) FROM Employees)

--02.find the names and salaries of the employees that have a salary 
--that is up to 10% higher than the minimal salary for the company.
SELECT FirstName + ' ' + LastName AS [Full Name],Salary
FROM Employees 
WHERE Salary <=1.1*(SELECT MIN(SALARY) FROM Employees)

--03.find the full name, salary and department of 
--the employees that take the minimal salary in their department.
SELECT e.FirstName + ' ' + e.LastName AS [Full Name],e.Salary,d.Name
FROM Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE e.Salary=(SELECT MIN(Salary) FROM Employees eTemp
   WHERE eTemp.DepartmentID = d.DepartmentID)

--04.find the average salary in the department #1.
SELECT e.DepartmentID,AVG(Salary) as [Average Salary]
FROM Employees e 
	JOIN Departments d ON e.DepartmentID=d.DepartmentID
	WHERE d.DepartmentID = 1
GROUP BY e.DepartmentID

--05.find the average salary in the "Sales" department.
SELECT d.Name,AVG(Salary) as [Average Salary]
FROM Employees e 
	JOIN Departments d ON e.DepartmentID=d.DepartmentID
	WHERE d.Name = 'Sales'
GROUP BY d.Name

--06.find the number of employees in the "Sales" department.
SELECT COUNT(*)
FROM Employees e
JOIN Departments d ON e.DepartmentID=d.DepartmentID
WHERE d.Name='Sales'

--07.find the number of all employees that have manager.
SELECT COUNT(*)
FROM Employees e
WHERE E.ManagerID IS NOT NULL

--08.find the number of all employees that have no manager.
SELECT COUNT(*)
FROM Employees e
WHERE E.ManagerID IS NULL

--09.find all departments and the average salary for each of them.
SELECT d.Name,ROUND(AVG(e.Salary),2) AS [Average Salary]
FROM Employees e
JOIN Departments d ON e.DepartmentID=d.DepartmentID
GROUP BY D.Name

--10.find the count of all employees in each department and for each town.
SELECT t.Name AS Town,d.Name AS Department,COUNT(EmployeeID) AS Employees
FROM Employees e
JOIN Departments d ON e.DepartmentID=d.DepartmentID
JOIN Addresses a ON e.AddressID = a.AddressID
JOIN Towns t ON t.TownID = a.TownID
GROUP BY t.Name,d.Name

--11.find all managers that have exactly 5 employees.
SELECT m.FirstName+' ' +m.LastName AS [Manager Name],COUNT(e.EmployeeID) AS [Employees]
FROM Employees e
	JOIN Employees m ON m.EmployeeID=e.ManagerID
GROUP BY m.FirstName+' ' +m.LastName
HAVING COUNT(e.EmployeeID) = 5

--12.find all employees along with their managers.
SELECT e.FirstName+' ' +e.LastName AS [Employee Name],
ISNULL(m.FirstName + ' ' + m .LastName,'No manager') AS [Manager Name]
FROM Employees e
	LEFT JOIN Employees m ON m.EmployeeID=e.ManagerID

--13.find the names of all employees whose last name is exactly 5 characters long. 
SELECT FirstName, LastName
FROM Employees 
WHERE LEN(LastName)=3

--14.display the current date and time in the following format 
--"day.month.year hour:minutes:seconds:milliseconds".
SELECT CONVERT(NVARCHAR(50),GETDATE(),104) + ' ' + CONVERT(NVARCHAR(50),GETDATE(),114) AS [DateTime]

--15.Write a SQL statement to create a table Users
CREATE TABLE Users (
UserID int IDENTITY,
Username nvarchar(100) NOT NULL,
Password varchar(100) NOT NULL,
LastLogin datetime,
CONSTRAINT PK_Users PRIMARY KEY(UserID),
CONSTRAINT UK_Username UNIQUE(Username),
CONSTRAINT CK_Password CHECK (LEN(Password)>=5))

--16.Write a SQL statement to create a view that displays
-- the users from the Users table that have been in the system today.
INSERT INTO Users (Username, Password,LastLogin)
VALUES ('Batman','Peshterata01',GETDATE()),('Superman','outofearth',GETDATE())
GO
CREATE VIEW [First 10 Persons] AS
SELECT Username FROM Users
WHERE CONVERT(NVARCHAR(20),LastLogin,104) = CONVERT(NVARCHAR(20),GETDATE(),104)
GO


--17.Write a SQL statement to create a table Groups
CREATE TABLE Groups (
GroupID int IDENTITY,
Name nvarchar(50) NOT NULL, 
CONSTRAINT UK_Name UNIQUE (Name),
CONSTRAINT PK_Groups PRIMARY KEY (GroupID))

--18.Write a SQL statement to add a column GroupID to the table Users.
ALTER TABLE Users
ADD GroupID int

ALTER TABLE Users
ADD CONSTRAINT FK_Users_Groups_GroupID
FOREIGN KEY (GroupID)
REFERENCES Groups(GroupID)

--19.Write SQL statements to insert several records in the Users and Groups tables.
INSERT INTO Groups (Name)
VALUES ('Group C'),('Group D')
INSERT INTO Users (Username,Password,LastLogin,GroupID)
VALUES ('Goshe01','wowwow',NULL,5),('Peshe220','biatch1',GETDATE(),2)

--20.Write SQL statements to update some of the records in the Users and Groups tables.
UPDATE Users
SET Username='Goshe01', GroupID=2
WHERE Username='Peshou';

UPDATE Users
SET GroupID=2
WHERE GroupID IS NULL;

UPDATE TOP(1) Groups
SET Name='Changed group';

--21.delete some of the records from the Users and Groups tables.
DELETE FROM Users 
WHERE Username = 'Goshe01'
DELETE FROM Groups 
WHERE Name = 'GroupD'

--22.insert in the Users table the names of all employees from the Employees table.
INSERT INTO Users (Username,Password)
SELECT FirstName+LastName,LOWER(FirstName+LastName) FROM Employees

--23.changes the password to NULL for all users that have not been in the system since 10.03.2010.
UPDATE Users
SET LastLogin = ('2010/03/09')
WHERE LastLogin IS NULL

ALTER TABLE Users ALTER COLUMN Password VARCHAR(100) NULL

UPDATE Users
SET Password = NULL
WHERE LastLogin<='2010/03/10'

--24.deletes all users without passwords (NULL password).
DELETE FROM Users
WHERE Password IS NULL

--25.display the average employee salary by department and job title.
SELECT d.Name,e.JobTitle, ROUND(AVG(e.Salary),2) as [Average Salary] FROM Employees e
JOIN Departments d ON e.DepartmentID=d.DepartmentID
GROUP BY d.Name, e.JobTitle

--26.display the minimal employee salary by department and job title 
--along with the name of some of the employees that take it.
SELECT d.Name AS Department, e.JobTitle AS [Job Title]
, MIN(e.FirstName+e.LastName) AS Name
, MIN(e.Salary) AS [Minimal Salary]
FROM Employees e
JOIN Departments d ON d.DepartmentID = e.DepartmentID
GROUP BY d.Name,e.JobTitle
ORDER BY d.Name

--27.display the town where maximal number of employees work.
SELECT TOP 1 t.Name, COUNT(e.EmployeeID) AS [Number of employees]
FROM Employees e
JOIN Addresses a ON e.AddressID = a.AddressID
JOIN Towns t ON t.TownID = a.TownID
GROUP BY t.Name
ORDER BY [Number of employees] DESC

--Second way... we cannot use alias in having clause because it is before the select clause
SELECT MAX(P.NUM) AS MAXIMUM,P.NAME_P 
FROM(
	SELECT T.Name AS NAME_P,COUNT(EmployeeID) AS NUM
	FROM Employees e
		JOIN Addresses a ON e.AddressID = a.AddressID
		JOIN Towns t ON t.TownID = a.TownID
		GROUP BY T.Name ) P
GROUP BY P.NAME_P
HAVING MAX(P.NUM)=
	(SELECT MAX(S.NUM) 
		FROM  (
			SELECT T.Name AS NAMEP,COUNT(EmployeeID) AS NUM
				FROM Employees e
					JOIN Addresses a ON e.AddressID = a.AddressID
					JOIN Towns t ON t.TownID = a.TownID
						GROUP BY T.Name ) S)




--28.display the number of managers from each town.
SELECT t.Name, COUNT(DISTINCT e.ManagerID )
FROM Employees e
	JOIN Employees m 
		ON e.ManagerID = m.EmployeeID
	JOIN Addresses a 
		ON a.AddressID = m.AddressID
	JOIN Towns t 
		ON t.TownID = a.TownID
GROUP BY T.Name

--29a.create table WorkHours to store work reports for each employee.
CREATE TABLE WorkHours (
WorkHoursID INT IDENTITY,
WorkDate DATETIME,
Task NVARCHAR(100),
Comments NVARCHAR(100),
EmployeeID INT,
WorkHours INT,
CONSTRAINT PK_WorkHoursID PRIMARY KEY(WorkHoursID) ,
CONSTRAINT FK_WorkHours_Employees_EmployeeID FOREIGN KEY(EmployeeID) REFERENCES Employees(EmployeeID)
)


--29b.Issue few SQL statements to insert, update and delete of some data in the table.
INSERT INTO WorkHours
			(WorkDate,Task,Comments,EmployeeID,WorkHours)
		VALUES
			(GETDATE(), 'task 1', 'comment 1', 3, 8),
			(GETDATE(), 'task 2', 'comment 2', 10, 8),
			(GETDATE(), 'task 3', 'comment 3', 50, 7)

--29c.Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.

CREATE TABLE WorkHoursLogs(
	WorkHoursLogsID INT IDENTITY,
	LogCommand NVARCHAR(10),
	OldWorkHoursID INT,
	NewWorkHoursID INT,
	OldWorkDate DATETIME,
	NewWorkDate DATETIME,
	OldTask NVARCHAR(100),
	NewTask NVARCHAR(100),
	OldComments NVARCHAR(100),
	NewComments NVARCHAR(100),
	OldEmployeeID INT,
	NewEmployeeID INT,
	OldWorkHours INT,
	NewWorkHours INT,
	CONSTRAINT PK_WorkHoursLogsID PRIMARY KEY(WorkHoursLogsID) ,
	CONSTRAINT FK_WorkHours_Employees_OldEmployeeID FOREIGN KEY(OldEmployeeID) REFERENCES Employees(EmployeeID),
	CONSTRAINT FK_WorkHours_Employees_NewEmployeeID FOREIGN KEY(NewEmployeeID) REFERENCES Employees(EmployeeID))
GO

CREATE TRIGGER Tr_WorkHoursUpdate 
ON WorkHours
FOR UPDATE
AS
SET NOCOUNT ON
INSERT INTO WorkHoursLogs
SELECT 
	'UPDATED',
	d.WorkHoursID,
	i.WorkHoursID,
	d.WorkDate,
	i.WorkDate,
	d.Task,
	i.Task,
	d.Comments,
	i.Comments,
	d.EmployeeID,
	i.EmployeeID,
	d.WorkHours,
	i.WorkHours
FROM INSERTED i, DELETED d
GO


CREATE TRIGGER Tr_WorkHoursDelete 
ON WorkHours
FOR DELETE
AS
SET NOCOUNT ON
INSERT INTO WorkHoursLogs
SELECT 
	'DELETED',
	d.WorkHoursID,
	NULL,
	d.WorkDate,
	NULL,
	d.Task,
	NULL,
	d.Comments,
	NULL,
	d.EmployeeID,
	NULL,
	d.WorkHours,
	NULL
	FROM DELETED d
GO

CREATE TRIGGER Tr_WorkHoursInsert 
ON WorkHours
FOR INSERT
AS
INSERT INTO WorkHoursLogs
SELECT 
	'INSERTED',
	NULL,
	i.WorkHoursID,
	NULL,
	i.WorkDate,
	NULL,
	i.Task,
	NULL,
	i.Comments,
	NULL,
	i.EmployeeID,
	NULL,
	i.WorkHours
	FROM INSERTED i
GO


--tests for the triggers
UPDATE WorkHours
SET Task = 'task 1 updated updated'
WHERE Task = 'task 1 updated'

INSERT INTO WorkHours(WorkDate,Task,Comments,EmployeeID,WorkHours)
VALUES(GETDATE(),'TASK INSERTED','COMMENTS ON INSERTED TASK',20,6)

DELETE FROM WorkHours
WHERE Task = 'TASK INSERTED'

--30.Start a database transaction, delete all employees from the 'Sales'
-- department along with all dependent records from the pother tables.
-- At the end rollback the transaction.
BEGIN TRAN

DELETE e  
FROM Employees e
JOIN Departments d ON d.DepartmentID = e.DepartmentID
WHERE d.Name = 'Sales'

ROLLBACK TRAN

	








			


























