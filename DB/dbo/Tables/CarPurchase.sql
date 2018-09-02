CREATE TABLE [dbo].[CarPurchase] (
    [Id]         BIGINT          NOT NULL,
    [CarID]      BIGINT          NOT NULL,
    [Buyer1ID]   BIGINT          NOT NULL,
    [Buyer2ID]   BIGINT          NULL,
    [Seller1ID]  BIGINT          NOT NULL,
    [Seller2ID]  BIGINT          NULL,
    [Witness1ID] BIGINT          NULL,
    [Witness2ID] BIGINT          NULL,
    [DealDate]   DATE            NOT NULL,
    [Price]      DECIMAL (19, 4) NOT NULL,
    [BuyerCom]   DECIMAL (19, 4) NOT NULL,
    [SellerCom]  DECIMAL (19, 4) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CarPurchase_Account] FOREIGN KEY ([Buyer1ID]) REFERENCES [dbo].[Account] ([Id]),
    CONSTRAINT [FK_CarPurchase_Account1] FOREIGN KEY ([Buyer2ID]) REFERENCES [dbo].[Account] ([Id]),
    CONSTRAINT [FK_CarPurchase_Account2] FOREIGN KEY ([Seller1ID]) REFERENCES [dbo].[Account] ([Id]),
    CONSTRAINT [FK_CarPurchase_Account3] FOREIGN KEY ([Seller2ID]) REFERENCES [dbo].[Account] ([Id]),
    CONSTRAINT [FK_CarPurchase_Car] FOREIGN KEY ([CarID]) REFERENCES [dbo].[Car] ([Id]),
    CONSTRAINT [FK_CarPurchase_Witness] FOREIGN KEY ([Witness1ID]) REFERENCES [dbo].[Witness] ([Id]),
    CONSTRAINT [FK_CarPurchase_Witness1] FOREIGN KEY ([Witness2ID]) REFERENCES [dbo].[Witness] ([Id])
);


