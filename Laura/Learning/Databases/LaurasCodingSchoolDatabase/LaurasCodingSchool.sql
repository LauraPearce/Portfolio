USE master
GO

CREATE DATABASE LaurasCodingSchool
GO

USE LaurasCodingSchool

CREATE TABLE Teacher 
(
    TeacherID int IDENTITY(1,1) PRIMARY KEY,
    FirstName nvarchar(50),
    Surname nvarchar(50),
	  Title nvarchar(10) NULL,
);
GO

CREATE TABLE Student 
(
    StudentID int IDENTITY(1,1) PRIMARY KEY,
    FirstName nvarchar(50),
    Surname nvarchar(50),
	Title nvarchar(10) NULL,
	EmergencyContactName nvarchar(50) NULL,
	EmergencyContactNumber nvarchar(11) NULL
);
GO

CREATE TABLE Department
(
	  DepartmentID int IDENTITY(1,1) PRIMARY KEY,
    Subject nvarchar(50),
    HeadOfDepartment int FOREIGN KEY REFERENCES Teacher(TeacherID)
);
GO

CREATE TABLE DepartmentTeacher
(
    DepartmentTeacherID int IDENTITY(1,1) PRIMARY KEY,
    TeacherID int FOREIGN KEY REFERENCES Teacher(TeacherID),
    DepartmentID int FOREIGN KEY REFERENCES Department(DepartmentID)
);
GO

CREATE TABLE Course 
(
    CourseID int IDENTITY(1,1) PRIMARY KEY,
    ContentDescription nvarchar(MAX),
    Prerequisites nvarchar(MAX),
	  DepartmentID int FOREIGN KEY REFERENCES Department(DepartmentID)
);
GO

CREATE TABLE Class 
(
    ClassID int IDENTITY(1,1) PRIMARY KEY,
	TeacherID int FOREIGN KEY REFERENCES Teacher(TeacherID),
    CourseID int FOREIGN KEY REFERENCES Course(CourseID),
    Day nvarchar(25),
	  Time nvarchar(25)
);
GO

CREATE TABLE StudentClass
(
    StudentClassID int IDENTITY(1,1) PRIMARY KEY,
    StudentID int FOREIGN KEY REFERENCES Student(StudentID),
    ClassID int FOREIGN KEY REFERENCES Class(ClassID)
);
GO

INSERT INTO Teacher
VALUES
	('Louise', 'Wilson', 'Ms'),
	('Henry', 'Matthews', 'Mr'),
	('Wilma', 'Flintstone', 'Mrs'), 
	('Agatha', 'Wentstone', 'Miss'),
    ('Steve', 'Jeeves', 'Mr')
GO

--SELECT *
--FROM Teacher

INSERT INTO Department
VALUES 
	('Coding', 2),
    ('Master Of Technology', 3),
	('History of Programming', 4),
	('App Design', 5)
GO

--SELECT *
--FROM Department

INSERT INTO Student
VALUES
	('Emmanuel', 'Trigger', 'Mr', 'Mummy Trigger', '07786563695'),
	('Laurence', 'McClare', 'Mr', 'Daddy McClare', '01923453269'),
	('Sally', 'Samuels', 'Mrs', 'Husband Samuels', '01935256964')
GO

--SELECT *
--FROM Student



INSERT INTO Course
VALUES 
	('Learn the basics of coding in languages C# and Java', 'Must have GCSE in Computing at Grade 5 or above', 1),
    ('Learn more advanced C# coding and application', 'Must have basic competence in C#', 1),
	('Learn the history of programming, from how early computers developed into the modern day technology we use today.', 'Must have English and Maths GCSE at Grade 5 or above.', 2),
	('Discover the basics of app design including visual display and coding logic.', 'Must have 5 GCSE passes.', 3)
GO

--SELECT *
--FROM Course	

INSERT INTO Class
VALUES
	(1, 1, 'Monday', 'Afternoon'),
	(1, 3, 'Wednesday', 'Morning'), 
	(1, 1, 'Friday', 'Morning'), 
	(2, 2, 'Thursday', 'Afternoon'),
	(2, 2, 'Friday', 'Afternoon'),
	(3, 3, 'Monday', 'Morning'), 
	(3, 3, 'Wednesday', 'Morning'),
	(3, 3, 'Wednesday', 'Afternoon'),
	(3, 3, 'Friday', 'Morning'),
	(4, 1, 'Wednesday', 'Morning')
GO

--SELECT *
--FROM Class

INSERT INTO DepartmentTeacher
VALUES
	(4, 1),
	(1, 1),
	(2, 2),
	(3, 3),
	(5, 1), 
	(5, 2), 
	(5, 3), 
	(5, 4)
GO

--SELECT *
--FROM DepartmentTeacher

INSERT INTO StudentClass
VALUES
	(1, 1),
	(1, 2),
	(2, 3), 
	(2, 2),
	(2, 9),
	(3, 6),
	(3, 5)
GO
	
--SELECT *
--FROM StudentClass

CREATE VIEW HeadOfDepartments
AS
(
	SELECT 
		d.Subject,
		t.Title + ' ' + t.FirstName + ' ' + t.Surname AS HeadOfDepartment
	FROM Department AS d
	JOIN Teacher AS t on t.TeacherID = d.HeadOfDepartment
)
GO

--SELECT *
--FROM HeadOfDepartments

CREATE VIEW CoursesInDepartment
AS
(
	SELECT 
		CourseID, 
		ContentDescription, 
		Subject 
	FROM Department AS d
	JOIN Course AS C ON c.DepartmentID = d.DepartmentID
)
GO

--SELECT *
--FROM CoursesInDepartment

CREATE VIEW ClassesPerCourse
AS
SELECT ClassID, Day, Time, CourseID
FROM Class
GO

--SELECT *
--FROM ClassesPerCourse

CREATE VIEW NumberOfClassesPerTeacher
AS
(
	SELECT 
		t.TeacherID, 
		Title, 
		FirstName, 
		Surname, 
		COUNT(CourseID) AS NumberOfClasses
	FROM Teacher AS t
	JOIN Class AS c ON c.TeacherID = t.TeacherID
	GROUP BY t.TeacherID, Title, FirstName, Surname
)
GO

--SELECT *
--FROM NumberOfClassesPerTeacher

CREATE VIEW NumberOfStudentsPerClass
AS
(
	SELECT 
		COUNT(StudentID) AS NumberOfStudents, 
		ClassID
	FROM StudentClass
	GROUP BY ClassID
)
GO

--SELECT *
--FROM NumberOfStudentsPerClass


CREATE VIEW NumberOfStudentsTaughtByADepartment
AS
(
	SELECT COUNT(StudentID) AS NumberOfStudents, d.DepartmentID, d.Subject
	FROM StudentClass AS sc
	JOIN Class AS cl ON cl.ClassID = sc.ClassID
	JOIN Course AS co ON co.CourseID = cl.CourseID
	JOIN Department	AS d ON d.DepartmentID = co.DepartmentID
	GROUP BY d.DepartmentID, d.Subject
)
GO

--SELECT *
--FROM NumberOfStudentsTaughtByADepartment

CREATE VIEW ClassesTaughtByTeachers
AS
(
	SELECT ClassID, Title, FirstName, Surname, TeacherID
	FROM 
	(    
		SELECT cl.ClassID, Title, FirstName, Surname, t.TeacherID
		FROM Class AS cl
		JOIN Teacher AS t ON t.TeacherID = cl.TeacherID
	) AS TeacherClasses
)
GO

CREATE VIEW ClassesAttendedByStudents
AS
(
	SELECT ClassID, Title, FirstName, Surname, StudentID
	FROM 
	(    
		SELECT sc.ClassID, Title, FirstName, Surname, s.StudentID
		FROM StudentClass AS sc
		JOIN Student AS s ON s.StudentID = sc.StudentID
	) AS ClassesStudentIsEnrolledIn
)
GO
-- =============================================
-- Author:		Laura Pearce
-- Create date: 08.08.2022
-- Description:	Checks if teacher can teach a class
-- =============================================
CREATE PROCEDURE [dbo].[UpdateTeacherForClassWithDepartmentCheck] 
	-- Add the parameters for the stored procedure here
	@TeacherID int, 
	@ClassID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @canTeach bit = 0
	SET @canTeach = 
	(
		SELECT 
			COUNT(t.TeacherID) AS NumberOfTeacherIDs
		FROM Teacher AS t
		JOIN DepartmentTeacher AS dt ON dt.TeacherID = t.TeacherID
		JOIN Department AS d ON d.DepartmentID = dt.DepartmentID
		JOIN Course AS c ON c.DepartmentID = d.DepartmentID
		JOIN Class AS cl ON cl.CourseID = c.CourseID
		WHERE cl.ClassID = @ClassID
		AND t.TeacherID = @TeacherID
	) 

	IF @canTeach = 1 
	BEGIN
		UPDATE Class 
		SET TeacherID = @TeacherID	
		WHERE ClassID = @ClassID

		-- 0 indicates success
		SELECT 0
	END
	ELSE
	BEGIN 
		-- non 0 indicates failure
		SELECT 1
	END

END
GO

-- =============================================
-- Author:		Laura Pearce
-- Create date:	08.08.2022
-- Description:	Checks if teacher is already a Head of Department
-- =============================================
CREATE PROCEDURE [dbo].[UpdateHeadOfDepartmentWithCheck] 
	-- Add the parameters for the stored procedure here
	@TeacherID int, 
	@DepartmentID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @canBeAHeadOfDepartment bit = 0
	SET @canBeAHeadOfDepartment = 
	(
		SELECT COUNT(d.HeadOfDepartment)
		FROM Department AS d
		JOIN DepartmentTeacher AS dt ON dt.DepartmentID = d.DepartmentID
		JOIN Teacher AS t ON t.TeacherID = dt.TeacherID
		WHERE @TeacherID = d.HeadOfDepartment   		
	) 

	IF @canBeAHeadOfDepartment = 0
	BEGIN
		UPDATE Department 
		SET HeadOfDepartment = @TeacherID	
		WHERE DepartmentID = @DepartmentID 

		-- 0 indicates success
		SELECT 0
	END
	ELSE
	BEGIN 
		-- non 0 indicates failure
		SELECT 1
	END
END 
GO

-- =============================================
-- Author:		Laura Pearce
-- Create date:	08.08.2022
-- Description:	Checks if teacher is already teaching a lesson before updating
-- =============================================
CREATE PROCEDURE [dbo].[UpdateTeacherLessonTimeWithCheck] 
	-- Add the parameters for the stored procedure here
	@TeacherID int, 
	@ClassID int,
	@Day nvarchar(25),
	@Time nvarchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

      -- Insert statements for procedure here
	DECLARE @canTeachAtThatTime bit = 0
	SET @canTeachAtThatTime = 
	(
		SELECT 
			COUNT(ClassID)
		FROM Class
		WHERE @TeacherID = [TeacherID]
		AND	@Day = [Day]
		AND @Time = [Time]
	) 

	IF @canTeachAtThatTime = 0
	BEGIN
		UPDATE Class 
		SET [Day] = @Day, [Time] = @Time
		WHERE ClassID = @ClassID

		-- 0 indicates success
		SELECT 0
	END
	ELSE
	BEGIN 
		-- non 0 indicates failure
		SELECT 1
	END
END 
GO

-- =============================================
-- Author:		Laura Pearce
-- Create date:	08.08.2022
-- Description:	Checks if student is already in another lesson before updating
-- =============================================
CREATE PROCEDURE [dbo].[UpdateStudentLessonTimeWithCheck] 
	-- Add the parameters for the stored procedure here
	@StudentID int, 
	@ClassID int,
	@Day nvarchar(25),
	@Time nvarchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

            -- Insert statements for procedure here
	DECLARE @canTeachAtThatTime bit = 0
	SET @canTeachAtThatTime = 
	(
		SELECT COUNT(sc.ClassID)
		FROM StudentClass AS sc
		JOIN Class AS c ON c.ClassID = sc.ClassID
		WHERE [StudentID] = @studentID
		AND [Day] = @day
		AND [Time] = @time
	) 

	IF @canTeachAtThatTime = 0
	BEGIN
		UPDATE Class 
		SET [Day] = @Day, [Time] = @Time
		WHERE ClassID = @classID

		-- 0 indicates success
		SELECT 0
	END
	ELSE
	BEGIN 
		-- non 0 indicates failure
		SELECT 1
	END
END 
GO

USE master
GO