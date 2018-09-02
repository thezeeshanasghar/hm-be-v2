CREATE TABLE [dbo].[CPSeller]
(
    [CarPurchaseID]     BIGINT NOT NULL,
    [AccountID] BIGINT NOT NULL,
    CONSTRAINT [FK_CPSeller_Account] FOREIGN KEY ([AccountID]) REFERENCES [dbo].[Account] ([Id]),
    CONSTRAINT [FK_CPSeller_CarPurchase] FOREIGN KEY ([CarPurchaseID]) REFERENCES [dbo].[CarPurchase] ([Id]), 
    CONSTRAINT [PK_CPSeller] PRIMARY KEY ([CarPurchaseID], [AccountID])

)
