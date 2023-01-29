SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
EXECUTE [dbo].[PostStudentWithSubject]

*/
CREATE PROCEDURE [dbo].[PostStudentWithSubject]
    @studentName VARCHAR(100),
    @studentRoll VARCHAR(50),
    @subjectInfo VARCHAR(max),
    @msg VARCHAR(100) OUT
AS

DECLARE
 @ErrorMessage  NVARCHAR(4000),@ErrorSeverity INT,@ErrorState INT;

BEGIN TRY
BEGIN TRANSACTION 

DECLARE @StudentId UNIQUEIDENTIFIER
DECLARE @subject TABLE(departmentId int,subjectId int,credit decimal)

INSERT INTO @subject (departmentId,subjectId,credit)
SELECT * FROM OpenJson(@subjectInfo) WITH (
    departmentId VARCHAR(50) '$.DepartmentId',
    subjectId VARCHAR(50) '$.SubjectId',
    credit decimal '$.Credit'
)

-- FETCH Student Information
If NOT EXISTS(SELECT top 1 Id FROM dbo.Student WHERE Name=@studentName And Roll=@studentRoll AND IsActive=1)
BEGIN
    INSERT INTO dbo.Student(Name,Roll,IsActive)
    SELECT @studentName,@studentRoll,1
END

SELECT @StudentId=Id FROM dbo.Student WHERE Name=@studentName And Roll=@studentRoll AND IsActive=1

INSERT INTO dbo.StudentsSubject(StudentId,DepartmentId,SubjectId,Credit,IsActive)
SELECT @StudentId,departmentId,subjectId,credit,1 FROM @subject

COMMIT

 set @msg= 'success'

END TRY  
BEGIN CATCH  
    ROLLBACK

    SELECT
    @ErrorMessage = ERROR_MESSAGE(),
    @ErrorSeverity = ERROR_SEVERITY(),
    @ErrorState = ERROR_STATE();

    -- return the error inside the CATCH block
    set @msg= 'failed'
    RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
END CATCH
GO
