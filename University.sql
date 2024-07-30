
create database University_Database


CREATE TABLE Teachers (
    TeacherID INT PRIMARY KEY not null,
    FirstName VARCHAR(50) not null,
    LastName VARCHAR(50) not null,
	DateOfBirth DATE not null,
	Phone varchar(12) not null,
	gender varchar(6) not null,
	Email varchar(20) not null,
	address varchar(50)  not null,
    Department VARCHAR(50) not null,
);

CREATE TABLE Students (
    StudentID INT PRIMARY KEY  not null,
    FirstName VARCHAR(50) not null,
    LastName VARCHAR(50) not null,
    DateOfBirth DATE not null,
	Phone varchar(12) not null,
	gender varchar(6) not null,
	Email varchar(20) not null,
	address varchar(50) not null,
    Major VARCHAR(50) not null,
    GPA FLOAT  not null
);


CREATE TABLE Courses (
    CourseID INT PRIMARY KEY  not null,
    CourseName VARCHAR(50)  not null,
    Credits INT  not null,
    TeacherID INT,
    FOREIGN KEY (TeacherID) REFERENCES Teachers(TeacherID)
);


CREATE TABLE Enrollment (
    EnrollmentID INT PRIMARY KEY  not null,
    StudentID INT,
    CourseID INT,
	TeacherID INT,
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
	FOREIGN KEY (TeacherID) REFERENCES Teachers(TeacherID),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);


CREATE TABLE Fees (
    FeeID INT PRIMARY KEY not null,
    StudentID INT,
    CourseID INT,
    Amount DECIMAL(10, 2),
    PaymentDate DATE,
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);


ALTER TABLE Students
ADD SchoolName NVARCHAR(200) NOT NULL,
    Duration NVARCHAR(100) NOT NULL;



select * from Teachers



select * from Students


UPDATE Fees
SET Amount = 200
where FeeID = 2


select FirstName, LastName from Students
where StudentID = 3


alter proc stStudent_details(
@StudentID as int)
as
begin
select Students.FirstName, Students.LastName, Students.Major, Students.GPA, Courses.CourseName, Fees.Amount 
From Students inner join Fees 
on Students.StudentID = Fees.StudentID inner join  Courses 
on Courses.CourseID = Fees.CourseID
where Students.StudentID = @StudentID;
end;


exec stStudent_details 3


create view vStudent_View
As
select Students.FirstName, Students.LastName, Students.Major, Students.GPA, Courses.CourseName, Fees.Amount 
From Students inner join Fees 
on Students.StudentID = Fees.StudentID inner join  Courses 
on Courses.CourseID = Fees.CourseID;

select * from vStudent_View

drop index insearch
on Courses

create index insearch
on Courses(CourseName)


backup database University_Database
to disk = 'D:\Programmingfor4\forthYear\database\CollageManagement\University_database.bak'