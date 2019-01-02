DECLARE @SourceTypes TABLE (
	[Id] INT NOT NULL,
    [Name] NVARCHAR(100) NOT NULL,
	[URI] NVARCHAR(MAX) NOT NULL,
	[Created] [DATETIME2] NOT NULL DEFAULT getutcdate(),
    [CreatedBy] [INT] NOT NULL,
	[Modified] [DATETIME2] NULL,
    [ModifiedBy] [INT] NULL
);

 
INSERT INTO 
	@SourceTypes ([Id], [Name] ,[URI], [CreatedBy]) 
VALUES
	(1, 'GitHub Project Repo', 'https://github.com/PlusConsultingAppDev/Text-Name-Search', 1),
	(2, 'New York Times', 'https://https://www.nytimes.com', 1)

 
-- Merge Statement Used to ensure list of items maintained in the table variable are persisted into the database
MERGE search.SourceType AS t
USING @SourceTypes as s
	on 	(t.[Id] = s.[Id])
WHEN NOT MATCHED BY TARGET
    THEN INSERT ([Name], [URI], [CreatedBy])
        VALUES (s.[Name], s.[URI], s.[CreatedBy])
WHEN MATCHED
    THEN UPDATE SET 
		t.[Name] = s.[Name], 
		t.[URI] = s.[URI]
WHEN NOT MATCHED BY SOURCE 
    THEN DELETE;
