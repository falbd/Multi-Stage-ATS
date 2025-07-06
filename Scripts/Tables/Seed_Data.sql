    -- Seed Stages
INSERT INTO Stages (Name, Description) VALUES
('Applied', 'Candidate has applied'),
('Screening', 'Initial screening in progress'),
('Interview', 'Candidate interview stage'),
('Offer', 'Offer extended to candidate'),
('Hired', 'Candidate successfully hired');
GO

-- Seed Applicants
INSERT INTO Applicants (FullName, Email) VALUES
('Alice Johnson', 'alice.johnson@example.com'),
('Bob Smith', 'bob.smith@example.com'),
('Charlie Lee', 'charlie.lee@example.com'),
('David Brown', 'david.brown@example.com'),
('Eva Green', 'eva.green@example.com');
GO

-- Seed Applications
INSERT INTO Applications (ApplicantId, StageId, Notes) VALUES
(1, 1, 'Applied via LinkedIn'),
(2, 2, 'Screening completed via phone'),
(3, 1, 'Applied via company careers page'),
(4, 3, 'Technical interview scheduled'),
(5, 4, 'Offer extended, awaiting acceptance');
GO

SELECT * FROM Applicants;
SELECT * FROM Stages;
SELECT * FROM Applications;

-- Verification Queries:

-- Verify all applicants
SELECT * FROM Applicants;

-- Verify all stages
SELECT * FROM Stages;

-- Verify all applications
SELECT * FROM Applications;

-- Test stored procedure
EXEC GetApplicationsByStage @StageId = 1;

-- Move an application
EXEC MoveApplicationToNextStage @ApplicationId = 1, @NewStageId = 2;

-- Get application details
EXEC GetApplicationDetails @ApplicationId = 1;


DROP TABLE Applications;
DROP TABLE Applicants;
DROP TABLE Stages;

SELECT * FROM sys.procedures;

EXEC GetApplicationsByStage @StageId = 1;

ALTER TABLE Applications
ADD CONSTRAINT DF_Applications_AppliedOn DEFAULT GETDATE() FOR AppliedOn;

SELECT name FROM sys.tables;

SELECT * FROM __EFMigrationsHistory;

DELETE FROM __EFMigrationsHistory WHERE MigrationId = '20250703103955_InitialCreate';
   

