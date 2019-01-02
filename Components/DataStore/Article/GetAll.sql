SELECT 
	 [Identifier]
    ,[Name]
    ,[SourceType]
    ,[Content]
    ,[IsDeleted]
    ,[Created]
    ,[CreatedBy]
    ,[Modified]
    ,[ModifiedBy]
FROM 
	[search].[Articles]
WHERE 
	IsDeleted = 0;