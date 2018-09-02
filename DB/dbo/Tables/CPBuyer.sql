CREATE TABLE [dbo].[CPBuyer]
(
    [CarPurchaseID]     BIGINT NOT NULL,
    [AccountID] BIGINT NOT NULL,
    CONSTRAINT [FK_CPBuyer_Account] FOREIGN KEY ([AccountID]) REFERENCES [dbo].[Account] ([Id]),
    CONSTRAINT [FK_CPBuyer_CarPurchase] FOREIGN KEY ([CarPurchaseID]) REFERENCES [dbo].[CarPurchase] ([Id]), 
    CONSTRAINT [PK_CPBuyer] PRIMARY KEY ([CarPurchaseID], [AccountID])
)
