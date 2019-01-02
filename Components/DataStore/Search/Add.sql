DECLARE @Identifier UNIQUEIDENTIFIER;
SET @Identifier = NEWID();

INSERT INTO [search].[Search]
	([Identifier]
    ,[FirstName]
    ,[LastName]
    ,[MiddleName]
    ,[Created]
    ,[CreatedBy])
VALUES
   (@Identifier,
    @FirstName,
	@LastName,
	@MiddleName,
	GETDATE(),
	@CreatedBy);

SELECT @Identifier

