CREATE TABLE [dbo].[CarPurchase] (
    [Id]         BIGINT          NOT NULL IDENTITY,
    [CarID]      BIGINT          NOT NULL,
    [DealDate]   DATE            NOT NULL,
    [Price]      DECIMAL (19, 4) NOT NULL,
    [BuyerCom]   DECIMAL (19, 4) NOT NULL,
    [SellerCom]  DECIMAL (19, 4) NOT NULL,
    [Description] NVARCHAR(200) NULL, 
    [DealType] NVARCHAR(50) NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CarPurchase_Car] FOREIGN KEY ([CarID]) REFERENCES [dbo].[Car] ([Id]),
);


