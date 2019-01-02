CREATE TABLE [search].[Articles]
(
    [Identifier] UNIQUEIDENTIFIER NOT NULL, 
    [Name] NVARCHAR(100) NOT NULL, 
    [SourceType] INT NOT NULL, 
	[Content] TEXT NOT NULL,
	[IsDeleted] BIT NOT NULL,
	[Created] [DATETIME2] NOT NULL DEFAULT getutcdate(),
    [CreatedBy] [INT] NOT NULL, 
	[Modified] [DATETIME2] NULL,
    [ModifiedBy] [INT] NULL, 
    CONSTRAINT [PK_ItemIdentifier] PRIMARY KEY CLUSTERED ([Identifier] ASC) on [search],
	CONSTRAINT [FK_Items_SourceType] FOREIGN KEY ([SourceType]) REFERENCES [search].[SourceType]([Id]), 
);

GO

CREATE UNIQUE NONCLUSTERED INDEX [UIX_search_item_name]
    ON [search].[Articles]([Name] ASC)
    ON [search];

GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_Items_lookup] ON [search].[Articles]([Identifier]) 
INCLUDE ([Name], [SourceType])
WHERE IsDeleted = 0;