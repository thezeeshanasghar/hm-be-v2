CREATE TABLE [dbo].[CarAccount]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [CarID] BIGINT NOT NULL, 
    [OwnerOneAccountID] BIGINT NOT NULL, 
    [OwnerTwoAccountID] BIGINT NULL, 
    CONSTRAINT [FK_CarDeal_Car] FOREIGN KEY ([CarID]) REFERENCES [Car]([ID]) ,
	CONSTRAINT [FK_CarDeal_Account1] FOREIGN KEY ([OwnerOneAccountID]) REFERENCES [Account]([ID]) ,
	CONSTRAINT [FK_CarDeal_Account2] FOREIGN KEY ([OwnerTwoAccountID]) REFERENCES [Account]([ID]) 
)
