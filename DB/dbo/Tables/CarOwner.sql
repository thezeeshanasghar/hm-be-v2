CREATE TABLE [dbo].[CarOwner]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [CarID] BIGINT NOT NULL, 
    [AccountID] BIGINT NOT NULL, 
    CONSTRAINT [FK_CarDeal_Car] FOREIGN KEY ([CarID]) REFERENCES [Car]([Id]) ,
	CONSTRAINT [FK_CarDeal_Account1] FOREIGN KEY ([AccountID]) REFERENCES [Account]([Id])
)
