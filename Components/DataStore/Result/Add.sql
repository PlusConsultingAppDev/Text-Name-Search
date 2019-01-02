DECLARE @Identifier UNIQUEIDENTIFIER;
SET @Identifier = NEWID();

INSERT INTO [search].[Results]
	([Identifier]
	,[SearchIdentifier]
	,[ArticleIdentifier]
	,[SearchText]
	,[Occurrences]
	,[Created]
	,[CreatedBy])
VALUES
   (@Identifier,
    @SearchIdentifier,
	@ArticleIdentifier,
	@SearchText,
	@Occurrences,
	GETDATE(),
	@CreatedBy);

SELECT @Identifier