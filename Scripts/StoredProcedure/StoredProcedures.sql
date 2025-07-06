-- Create Application
CREATE PROCEDURE CreateApplication
    @ApplicantId INT,
    @StageId INT,
    @Notes NVARCHAR(500) = NULL
AS
BEGIN
    INSERT INTO Applications (ApplicantId, StageId, AppliedOn, Notes)
    VALUES (@ApplicantId, @StageId, GETDATE(), @Notes);

    SELECT SCOPE_IDENTITY() AS NewApplicationId;
END
GO

-- GetAllStages
CREATE PROCEDURE GetAllStages
AS
BEGIN
    SELECT Id, Name, Description FROM Stages ORDER BY Id;
END
GO

-- Get Applicant Applications
CREATE PROCEDURE GetApplicantApplications
    @ApplicantId INT
AS
BEGIN
    SELECT 
        a.Id AS ApplicationId,
        s.Name AS StageName,
        a.AppliedOn,
        a.Notes
    FROM Applications a
    INNER JOIN Stages s ON a.StageId = s.Id
    WHERE a.ApplicantId = @ApplicantId
    ORDER BY a.AppliedOn DESC;
END
GO

-- Get Applications By Stage
CREATE PROCEDURE GetApplicationsByStage
    @StageId INT
AS
BEGIN
    SELECT 
        a.Id AS ApplicationId,
        ap.FullName,
        ap.Email,
        s.Name AS StageName,
        a.AppliedOn,
        a.Notes
    FROM Applications a
    INNER JOIN Applicants ap ON a.ApplicantId = ap.Id
    INNER JOIN Stages s ON a.StageId = s.Id
    WHERE s.Id = @StageId
    ORDER BY a.AppliedOn DESC;
END
GO

-- Move Application to Next Stage
CREATE PROCEDURE MoveApplicationToNextStage
    @ApplicationId INT,
    @NewStageId INT
AS
BEGIN
    UPDATE Applications
    SET StageId = @NewStageId
    WHERE Id = @ApplicationId;
END
GO

-- Get Full Application Details
CREATE PROCEDURE GetApplicationDetails
    @ApplicationId INT
AS
BEGIN
    SELECT 
        a.Id AS ApplicationId,
        ap.FullName,
        ap.Email,
        s.Name AS StageName,
        s.Description AS StageDescription,
        a.AppliedOn,
        a.Notes
    FROM Applications a
    INNER JOIN Applicants ap ON a.ApplicantId = ap.Id
    INNER JOIN Stages s ON a.StageId = s.Id
    WHERE a.Id = @ApplicationId;
END
GO
