USE [HM1]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

GO
INSERT [dbo].[Account] ([Id], [Number], [Name], [MobileNumber], [CNIC], [Address], [Created], [Balance], [Image]) VALUES (1, N'HM-00', N'HM', N'00000000000', N'611010000', N'Lahore', CAST(N'0001-01-01' AS Date), CAST(0.0000 AS Decimal(19, 4)), N'UploadFile/636725221604745462pak.png')
GO
INSERT [dbo].[Account] ([Id], [Number], [Name], [MobileNumber], [CNIC], [Address], [Created], [Balance], [Image]) VALUES (2, N'HM-02', N'Noman', N'2222222222222222222', N'6111101122222222222', N'G-123', CAST(N'0001-01-01' AS Date), CAST(0.0000 AS Decimal(19, 4)), N'UploadFile/636725233529854261Pakistan.png')
GO
INSERT [dbo].[Account] ([Id], [Number], [Name], [MobileNumber], [CNIC], [Address], [Created], [Balance], [Image]) VALUES (3, N'HM-03', N'Zeeshan', N'111111111111', N'611101111111111', N'G-14, Islamabad, Pakistan, Asia, World', CAST(N'0001-01-01' AS Date), CAST(0.0000 AS Decimal(19, 4)), N'UploadFile/636725221604745462pak.png')
GO
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Car] ON 

GO
INSERT [dbo].[Car] ([Id], [Name], [EngineNumber], [ModelNumber], [RegistrationNumber], [ChasisNumber], [Color], [Maker], [Token], [ComputerizedNoPlate], [NoOfPapers], [PurchasePrice], [PurchaseDate], [Image1], [Image2], [ReceiptNumber]) 
VALUES (1, N'Bravo', N'E123', N'2016', N'R123', N'C123', N'Black', N'Suzuki', N'PAID', 1, 1, CAST(100.0000 AS Decimal(19, 4)), CAST(N'2018-09-13' AS Date), N'UploadFile/636725225670542664-tick.png', NULL, N'Page 101')
GO
SET IDENTITY_INSERT [dbo].[Car] OFF
GO
INSERT [dbo].[AccountCar] ([CarID], [AccountID]) VALUES (1, 3)
GO
