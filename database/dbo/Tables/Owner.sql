﻿CREATE TABLE [dbo].[Owner]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Name] VARCHAR(256) NOT NULL, 
    [Address] VARCHAR(256) NULL
)
