CREATE TABLE [search].[Search]
(
    [Identifier] UNIQUEIDENTIFIER NOT NULL, 
	[FirstName] NVARCHAR(100) NOT NULL,
	[LastName] NVARCHAR(100) NOT NULL,
	[MiddleName] NVARCHAR(100) NOT NULL,
	[Created] [DATETIME2] NOT NULL DEFAULT getutcdate(),
    [CreatedBy] [INT] NOT NULL, 
	[Modified] [DATETIME2] NULL,
    [ModifiedBy] [INT] NULL, 
    CONSTRAINT [PK_SearchIdentifier] PRIMARY KEY CLUSTERED ([Identifier] ASC) on [search],
);