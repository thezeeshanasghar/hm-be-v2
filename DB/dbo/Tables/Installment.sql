CREATE TABLE [dbo].[Installment]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [CarPurchaseID] BIGINT NOT NULL, 
    [Amount] DECIMAL(19, 4) NOT NULL, 
    [NextDueDate] DATE NOT NULL, 
    [InstallmentDate] DATE NOT NULL
	
)
