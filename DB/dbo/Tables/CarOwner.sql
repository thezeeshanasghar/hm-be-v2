CREATE TABLE [dbo].[CarOwner] (
    [CarID]     BIGINT NOT NULL,
    [AccountID] BIGINT NOT NULL,
    CONSTRAINT [FK_CarOwner_Account] FOREIGN KEY ([AccountID]) REFERENCES [dbo].[Account] ([Id]),
    CONSTRAINT [FK_CarOwner_Car] FOREIGN KEY ([CarID]) REFERENCES [dbo].[Car] ([Id])
);


