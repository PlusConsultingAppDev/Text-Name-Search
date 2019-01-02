CREATE TABLE [search].[SourceType]
(
    [Id] INT NOT NULL IDENTITY(1,1), 
    [Name] NVARCHAR(100) NOT NULL,
	[URI] NVARCHAR(MAX) NOT NULL,
	[Created] [DATETIME2] NOT NULL DEFAULT getutcdate(),
    [CreatedBy] [INT] NOT NULL,
	[Modified] [DATETIME2] NULL,
    [ModifiedBy] [INT] NULL, 
    CONSTRAINT [PK_CategoryIdentifier] PRIMARY KEY CLUSTERED ([Id] ASC) on [search]
);

GO

CREATE UNIQUE NONCLUSTERED INDEX [UIX_search_category_name]
    ON 
		[search].[SourceType]([Name] ASC)
    ON
		[search];