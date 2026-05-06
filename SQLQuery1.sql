CREATE TABLE [dbo].[Students] (
    [StudentNo]     BIGINT             NOT NULL,  
    [LastName]      VARCHAR(50)     NOT NULL,
    [FirstName]     VARCHAR(50)     NOT NULL,
    [MiddleName]    VARCHAR(50)     NULL,
    [Gender]        VARCHAR(10)     NOT NULL,
    [ContactNumber] VARCHAR(15)     NOT NULL,
    [EmailAddress]  VARCHAR(100)    NOT NULL,
    [GuardianName]  VARCHAR(100)    NOT NULL,
    [GuardianContactNumber] VARCHAR(15) NULL,
    [GuardianEmail] VARCHAR(100)    NULL,
    [ProgramID]     INT             NOT NULL,  
    [YearLevel]     INT             NOT NULL,  
    [PaymentTerm]   VARCHAR(50)     NOT NULL,  
    PRIMARY KEY ([StudentNo]),
    FOREIGN KEY ([ProgramID]) REFERENCES [dbo].[Programs]([ProgramID])
);
