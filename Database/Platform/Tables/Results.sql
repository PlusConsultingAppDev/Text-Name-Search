CREATE TABLE [search].[Results]
(
    [Identifier] UNIQUEIDENTIFIER NOT NULL, 
    [SearchIdentifier] UNIQUEIDENTIFIER NOT NULL,
	[ArticleIdentifier] UNIQUEIDENTIFIER NOT NULL,
	[SearchText] NVARCHAR(100) NOT NULL,
	[Occurrences] INT NOT NULL, 
	[Created] [DATETIME2] NOT NULL DEFAULT getutcdate(),
    [CreatedBy] [INT] NOT NULL, 
	[Modified] [DATETIME2] NULL,
    [ModifiedBy] [INT] NULL, 
    CONSTRAINT [PK_ResultsIdentifier] PRIMARY KEY CLUSTERED ([Identifier] ASC) on [search],
	CONSTRAINT [FK_Results_Article] FOREIGN KEY ([ArticleIdentifier]) REFERENCES [search].[Articles]([Identifier]), 
	CONSTRAINT [FK_Results_Search] FOREIGN KEY ([SearchIdentifier]) REFERENCES [search].[Search]([Identifier]), 
);