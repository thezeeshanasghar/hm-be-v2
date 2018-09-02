CREATE TABLE [dbo].[CPWitness]
(
    [CarPurchaseID]     BIGINT NOT NULL,
    [WitnessID] BIGINT NOT NULL,
    CONSTRAINT [FK_CPWitness_Witness] FOREIGN KEY ([WitnessID]) REFERENCES [dbo].[Witness] ([Id]),
    CONSTRAINT [FK_CPWitness_CarPurchase] FOREIGN KEY ([CarPurchaseID]) REFERENCES [dbo].[CarPurchase] ([Id]), 
    CONSTRAINT [PK_CPWitness] PRIMARY KEY ([CarPurchaseID], [WitnessID])
)
