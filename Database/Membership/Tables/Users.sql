﻿CREATE TABLE [membership].[Users]
(
    [Id] INT NOT NULL IDENTITY(1,1), 
    [UserName] NVARCHAR(100) NOT NULL,
	[FirstName] NVARCHAR(100) NOT NULL,
    [LastName] NVARCHAR(100) NOT NULL,
	[Email] [Email] NOT NULL,
	[PasswordHash] [PWD] NOT NULL,
	[OrganizationIdentifier] UNIQUEIDENTIFIER NULL,
	[Created] [DATETIME2] DEFAULT getutcdate(),
    [CreatedBy] [INT],
	[Modified] [DATETIME2] NULL,
    [ModifiedBy] [INT] NULL, 
    CONSTRAINT [PK_UserIdentifier] PRIMARY KEY CLUSTERED ([Id] ASC) on [membership],
	CONSTRAINT [FK_User_Organization] FOREIGN KEY ([OrganizationIdentifier]) REFERENCES [membership].[Organization]([Identifier]), 
);

GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_Email] ON [membership].[Users]([Email]);

GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_userName] ON [membership].[Users]([UserName]);