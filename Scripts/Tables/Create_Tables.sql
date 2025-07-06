    -- Create Applicants table
CREATE TABLE Applicants (
    Id INT PRIMARY KEY IDENTITY,
    FullName NVARCHAR(200) NOT NULL,
    Email NVARCHAR(200) NOT NULL
);


-- Create Stages table
CREATE TABLE Stages (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(500) NOT NULL
);


-- Create Applications table
CREATE TABLE Applications (
    Id INT PRIMARY KEY IDENTITY,
    ApplicantId INT NOT NULL FOREIGN KEY REFERENCES Applicants(Id),
    StageId INT NOT NULL FOREIGN KEY REFERENCES Stages(Id),
    AppliedOn DATETIME2 NOT NULL DEFAULT GETDATE(),
    Notes NVARCHAR(MAX)
);

