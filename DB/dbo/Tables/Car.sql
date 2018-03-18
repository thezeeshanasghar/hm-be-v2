CREATE TABLE [dbo].[Car] (
    [Id]                       BIGINT          IDENTITY (1, 1) NOT NULL,
    [Name]                     NVARCHAR (50)   NOT NULL,
    [EngineNumber]             NVARCHAR (50)   NULL,
    [ModelNumber]              NVARCHAR (50)   NULL,
    [RegistrationNumber]       NVARCHAR (50)   NOT NULL,
    [ChasisNumber]				NVARCHAR (50)   NOT NULL,
    [Color]                    NVARCHAR (50)   NULL,
    [Maker]                    NVARCHAR (50)   NULL,
    [Token]                    NVARCHAR (50)   NULL,
    [ComputerizedNoPlate]      BIT             CONSTRAINT [DF_Car_ComputerizedNoPlate] DEFAULT ((0)) NOT NULL,
    [NoOfPapers]               INT             NULL,
    [PurchasePrice]            DECIMAL (19, 4) NULL,
    [PurchaseDate]             DATE            NULL,
    [Image1] NVARCHAR(150) NULL, 
    [Image2] NVARCHAR(150) NULL, 
    CONSTRAINT [PK_Car] PRIMARY KEY ([Id])
);

