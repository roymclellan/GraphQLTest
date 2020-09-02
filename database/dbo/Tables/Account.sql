CREATE TABLE [dbo].[Account]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TypeId] INT NOT NULL, 
    [Description] VARCHAR(256) NOT NULL, 
    [OwnerId] INT NOT NULL
)
