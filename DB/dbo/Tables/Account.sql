CREATE TABLE [dbo].[Account]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Number] NVARCHAR(50) NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    [MobileNumber] NVARCHAR(50) NOT NULL, 
    [CNIC] NVARCHAR(50) NOT NULL, 
    [Address] NVARCHAR(MAX) NOT NULL, 
    [Created] DATETIME2(0) NOT NULL DEFAULT GetDate() , 
    [Balance] DECIMAL(19, 4) NOT NULL DEFAULT 0.00, 
    [Image] NVARCHAR(150) NULL, 
    [Updated] DATETIME2(0) NULL DEFAULT GetDate(), 
    CONSTRAINT [CK_Account_Number_Unique] UNIQUE ([Number])
)
