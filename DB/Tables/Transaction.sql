CREATE TABLE [dbo].[Transaction]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
	[Number] NVARCHAR(50) NOT NULL, 
    [Date] DATETIME NOT NULL, 
    [Amount] DECIMAL(19, 4) NOT NULL, 
    [AccountID] BIGINT NOT NULL, 
    CONSTRAINT [FK_Transaction_Account] FOREIGN KEY ([AccountID]) REFERENCES [Account]([ID]) 
)
