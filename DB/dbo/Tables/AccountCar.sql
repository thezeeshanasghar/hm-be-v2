CREATE TABLE [dbo].[AccountCar] (
    [CarID]     BIGINT NOT NULL,
    [AccountID] BIGINT NOT NULL,
    CONSTRAINT [FK_AccountCar_Account] FOREIGN KEY ([AccountID]) REFERENCES [dbo].[Account] ([Id]),
    CONSTRAINT [FK_AccountCar_Car] FOREIGN KEY ([CarID]) REFERENCES [dbo].[Car] ([Id]), 
    CONSTRAINT [PK_AccountCar] PRIMARY KEY ([CarID], [AccountID])
);


