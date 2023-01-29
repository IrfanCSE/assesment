-- Create a new database called 'Prime'
-- Connect to the 'master' database to run this snippet
USE master
GO
-- Create the new database if it does not exist already
IF NOT EXISTS (
    SELECT [name]
        FROM sys.databases
        WHERE [name] = N'Prime'
)
CREATE DATABASE Prime
GO

-- DROP SCHEMA dbo;

CREATE SCHEMA dbo;
-- Prime.dbo.Student definition

-- Drop table

-- DROP TABLE Prime.dbo.Student;

CREATE TABLE Prime.dbo.Student (
	Id uniqueidentifier DEFAULT newid() NOT NULL,
	Name varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Roll varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	IsActive bit DEFAULT 1 NOT NULL,
	CONSTRAINT PK__Student__3214EC0771481C55 PRIMARY KEY (Id)
);


-- Prime.dbo.[User] definition

-- Drop table

-- DROP TABLE Prime.dbo.[User];

CREATE TABLE Prime.dbo.[User] (
	Id uniqueidentifier DEFAULT newid() NOT NULL,
	Name varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Password varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	IsActive bit DEFAULT 1 NOT NULL,
	CONSTRAINT PK__User__3214EC072A744F1F PRIMARY KEY (Id)
);


-- Prime.dbo.StudentsSubject definition

-- Drop table

-- DROP TABLE Prime.dbo.StudentsSubject;

CREATE TABLE Prime.dbo.StudentsSubject (
	Id uniqueidentifier DEFAULT newid() NOT NULL,
	StudentId uniqueidentifier NOT NULL,
	DepartmentId int NOT NULL,
	SubjectId int NOT NULL,
	Credit decimal(18,0) NOT NULL,
	IsActive bit DEFAULT 1 NOT NULL,
	CONSTRAINT PK__Students__3214EC0785E42940 PRIMARY KEY (Id),
	CONSTRAINT FK__StudentsS__Stude__534D60F1 FOREIGN KEY (StudentId) REFERENCES Prime.dbo.Student(Id)
);


-- Insert Dummy Data

-- Insert rows into table 'TableName' in schema '[dbo]'
INSERT INTO [dbo].[User]
( -- Columns to insert data into
 [Name], [Password], [IsActive]
)
VALUES
(
 'admin','admin@123',1
)

INSERT INTO [dbo].[Student]
( -- Columns to insert data into
 [Name], [Roll], [IsActive]
)
VALUES
(
 'Irfan','100',1
)

DECLARE @id UNIQUEIDENTIFIER
set @id = SCOPE_IDENTITY()

INSERT INTO [dbo].[TableName]
( -- Columns to insert data into
 StudentId,DepartmentId,SubjectId,Credit,IsActive
)
VALUES
( -- First row: values for the columns in the list above
 @id, 1,2,3,1
),
( -- Second row: values for the columns in the list above
 @id, 1,1,3,1
)

go
