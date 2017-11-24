﻿CREATE TABLE [dbo].[Transaction]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
	[Number] NVARCHAR(50) NOT NULL, 
    [Date] DATE NOT NULL DEFAULT GetDate(), 
    [Amount] DECIMAL(19, 4) NOT NULL, 
	[Description] NVARCHAR(100) NOT NULL,
    [AccountID] BIGINT NOT NULL, 
    CONSTRAINT [FK_Transaction_Account] FOREIGN KEY ([AccountID]) REFERENCES [Account]([ID]) 
)
