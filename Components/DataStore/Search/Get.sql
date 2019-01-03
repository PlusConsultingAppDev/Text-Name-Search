SELECT TOP 1
	[Identifier]
   ,[FirstName]
   ,[LastName]
   ,[MiddleName]
   ,[Created]
   ,[CreatedBy]
   ,[Modified]
   ,[ModifiedBy]
FROM 
	[search].[Search]
WHERE
 Identifier = @SearchIdentifier