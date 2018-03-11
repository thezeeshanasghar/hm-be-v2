
SET IDENTITY_INSERT [dbo].[Account] ON 

GO
INSERT [dbo].[Account] ([Id], [Number], [Name], [MobileNumber], [CNIC], [Address], [Created], [Balance], [image]) VALUES (62, N'HM001', N'Hussain Shah', N'03003000754', N'3820131072477', N'Qazi Colony Jauharabad', CAST(N'0001-01-01' AS Date), CAST(11179392.0 AS Decimal(19, 1)), N'UploadFile/636494256212125660hussain.jpg')
GO
INSERT [dbo].[Account] ([Id], [Number], [Name], [MobileNumber], [CNIC], [Address], [Created], [Balance], [image]) VALUES (63, N'HM002', N'Malik Qasim Sohail Awan', N'03007077500', N'1111', N'Qazi Colony Jauharabad', CAST(N'0001-01-01' AS Date), CAST(1100000.0 AS Decimal(19, 1)), N'UploadFile/636494256871483779qasim awan.jpg')
GO
INSERT [dbo].[Account] ([Id], [Number], [Name], [MobileNumber], [CNIC], [Address], [Created], [Balance], [image]) VALUES (64, N'HM003', N'Sardar Zulfiqar Khan ', N'03008603005', N'1111', N'P.O Khushab', CAST(N'0001-01-01' AS Date), CAST(16813704.0 AS Decimal(19, 1)), N'UploadFile/636494257629745625zulfiqar.jpg')
GO
INSERT [dbo].[Account] ([Id], [Number], [Name], [MobileNumber], [CNIC], [Address], [Created], [Balance], [image]) VALUES (65, N'HM004', N'Malik Muhammad Akhtar Tiwana', N'03006076850', N'1111', N'Civial Line Jauharabad', CAST(N'0001-01-01' AS Date), CAST(24413686.0 AS Decimal(19, 1)), N'UploadFile/636494259288773306flowers.jfif')
GO
INSERT [dbo].[Account] ([Id], [Number], [Name], [MobileNumber], [CNIC], [Address], [Created], [Balance], [image]) VALUES (66, N'HM005', N'Syed Tanveer Haider', N'03003800214', N'1111', N'Burhan Town Jauharabad', CAST(N'0001-01-01' AS Date), CAST(2205600.0 AS Decimal(19, 1)), N'UploadFile/636494261100295577tanveer.jpg')
GO
INSERT [dbo].[Account] ([Id], [Number], [Name], [MobileNumber], [CNIC], [Address], [Created], [Balance], [image]) VALUES (67, N'HM5000', N'TEMP', N'0000', N'1111', N'Temporary', CAST(N'0001-01-01' AS Date), CAST(0.0 AS Decimal(19, 1)), N'UploadFile/no-image.png')
GO
INSERT [dbo].[Account] ([Id], [Number], [Name], [MobileNumber], [CNIC], [Address], [Created], [Balance], [image]) VALUES (68, N'HM006', N'Safdar Raza Bhatti', N'03016717477', N'1111', N'P.O Joyia Distt Khushab', CAST(N'0001-01-01' AS Date), CAST(1564247.0 AS Decimal(19, 1)), N'UploadFile/636494263890689300safdar.jpg')
GO
INSERT [dbo].[Account] ([Id], [Number], [Name], [MobileNumber], [CNIC], [Address], [Created], [Balance], [image]) VALUES (69, N'HM007', N'Imran Wagwal', N'111', N'2222', N'PO Wagwal Teh Shah Pur Distt Sargodha', CAST(N'0001-01-01' AS Date), CAST(-1777777.0 AS Decimal(19, 1)), N'UploadFile/636498442503709006flowers.jfif')
GO
INSERT [dbo].[Account] ([Id], [Number], [Name], [MobileNumber], [CNIC], [Address], [Created], [Balance], [image]) VALUES (70, N'HM008', N'Dr. Muhammad Sher', N'03006071651', N'121212', N'Sarfraz Town Khushab', CAST(N'0001-01-01' AS Date), CAST(12339510.0 AS Decimal(19, 1)), N'UploadFile/636498443146036339flowers.jfif')
GO
INSERT [dbo].[Account] ([Id], [Number], [Name], [MobileNumber], [CNIC], [Address], [Created], [Balance], [image]) VALUES (71, N'HM009', N'Sail Deen', N'12121', N'2222', N'Cival Lane Jauharabad', CAST(N'0001-01-01' AS Date), CAST(3397425.0 AS Decimal(19, 1)), N'UploadFile/no-image.png')
GO
INSERT [dbo].[Account] ([Id], [Number], [Name], [MobileNumber], [CNIC], [Address], [Created], [Balance], [image]) VALUES (72, N'HM010', N'Munawar Khan', N'0000', N'22222', N'Qazi Colony Jauharabad', CAST(N'0001-01-01' AS Date), CAST(1057000.0 AS Decimal(19, 1)), N'UploadFile/636501897101658949munawar.jpg')
GO
INSERT [dbo].[Account] ([Id], [Number], [Name], [MobileNumber], [CNIC], [Address], [Created], [Balance], [image]) VALUES (73, N'HM011', N'Hassan Khan', N'032562589741', N'121212121', N'Al Khabir Cloth House Main Bazar Jauharabad', CAST(N'0001-01-01' AS Date), CAST(0.0 AS Decimal(19, 1)), N'UploadFile/no-image.png')
GO
INSERT [dbo].[Account] ([Id], [Number], [Name], [MobileNumber], [CNIC], [Address], [Created], [Balance], [image]) VALUES (74, N'HM011', N'Hassan Khan', N'032562589741', N'121212121', N'Al Khabir Cloth House Main Bazar Jauharabad', CAST(N'0001-01-01' AS Date), CAST(0.0 AS Decimal(19, 1)), N'UploadFile/no-image.png')
GO
INSERT [dbo].[Account] ([Id], [Number], [Name], [MobileNumber], [CNIC], [Address], [Created], [Balance], [image]) VALUES (75, N'HM011', N'Hassan Khan', N'121212', N'00000', N'Al Khabir Cloth House Main Bazar Jauharabad', CAST(N'0001-01-01' AS Date), CAST(0.0 AS Decimal(19, 1)), N'UploadFile/no-image.png')
GO
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Transaction] ON 

GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (271, N'c19ecea6-fa43-8bac-52f1-7d8fd0862060', CAST(N'2017-12-21' AS Date), CAST(1200000.0 AS Decimal(19, 1)), 62, N'test etsetsetset')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (272, N'958c126d-f339-20b8-f74f-6be259881842', CAST(N'2017-12-21' AS Date), CAST(-12000.0 AS Decimal(19, 1)), 62, N'askldfkajdfkljladkjfslk')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (273, N'c928a4b0-2343-c722-eac6-891b440d89bf', CAST(N'2017-12-25' AS Date), CAST(-1188000.0 AS Decimal(19, 1)), 62, N'paid to hussain ')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (275, N'2f191c23-ed07-9612-2c8c-55c493c8a21f', CAST(N'2017-12-25' AS Date), CAST(1100000.0 AS Decimal(19, 1)), 63, N'Malik Qasim Deposited jis amount')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (276, N'b0eeb418-db30-6b58-2afd-680bf24b62b9', CAST(N'2017-12-25' AS Date), CAST(2150600.0 AS Decimal(19, 1)), 66, N'deposited amount for investment')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (277, N'492b004a-8a63-496a-57ce-d6afbc9bec4d', CAST(N'2017-12-25' AS Date), CAST(635000.0 AS Decimal(19, 1)), 62, N'deposited amount by akhtar tiwana')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (278, N'8f41573c-02d0-1ba4-57d8-32d2f40f042f', CAST(N'2017-12-25' AS Date), CAST(-2200000.0 AS Decimal(19, 1)), 64, N'paid to zulfiqar for purchase of Prado')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (279, N'deb4304d-a427-0470-c80b-2226c88a7b7c', CAST(N'2017-12-25' AS Date), CAST(-390000.0 AS Decimal(19, 1)), 65, N'paid to akhtar for XLI4105526')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (280, N'c6d7abb8-1b61-3ab4-5c30-9b6dfd4bd93b', CAST(N'2017-12-25' AS Date), CAST(-630200.0 AS Decimal(19, 1)), 68, N'paid to akhtar tiwana')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (281, N'1e46db02-3ee5-6e0a-6daf-2fd2ce4e0f5e', CAST(N'2017-12-25' AS Date), CAST(-210500.0 AS Decimal(19, 1)), 65, N'paid medical bill Iqbal Medical ')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (282, N'55252cbf-14e2-cfa3-b934-713c98b98162', CAST(N'2017-12-25' AS Date), CAST(700000.0 AS Decimal(19, 1)), 62, N'Deposited amount by Munawar')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (283, N'0b4fce8f-da7d-d0a1-a8d2-6bdf65e41b89', CAST(N'2017-12-26' AS Date), CAST(5500000.0 AS Decimal(19, 1)), 70, N'Dr Muhammad Sher deposited his amount')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (284, N'bfc41f9d-51eb-c725-b726-aacfad1611ed', CAST(N'2017-12-26' AS Date), CAST(355000.0 AS Decimal(19, 1)), 65, N'akhtar tiwana has deposited his amount')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (285, N'b693a680-dd2e-09a1-f97e-87a1cbf25a3c', CAST(N'2017-12-26' AS Date), CAST(1635000.0 AS Decimal(19, 1)), 62, N'XLI 3922 sold amount recieved')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (286, N'ed86a400-43c6-aeb9-03ba-6acc53eac837', CAST(N'2017-12-26' AS Date), CAST(798000.0 AS Decimal(19, 1)), 66, N'XLI 012 arear recieved')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (287, N'cbf3c7b0-25ea-1ad4-5d3b-b04f9b82ba84', CAST(N'2017-12-26' AS Date), CAST(497000.0 AS Decimal(19, 1)), 66, N'CJ 213 arear recieved')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (288, N'b0279fd2-86ce-b1ff-221a-816f9335caaa', CAST(N'2017-12-26' AS Date), CAST(210000.0 AS Decimal(19, 1)), 64, N'Zulfiqar khan has deposited his amount')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (289, N'ef0b5a0a-d090-c06c-4035-af22a62a6b78', CAST(N'2017-12-26' AS Date), CAST(503000.0 AS Decimal(19, 1)), 68, N'safdar has deposit his amount')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (290, N'a336c47c-b26a-1d1b-2514-04a8ee28bd3e', CAST(N'2017-12-26' AS Date), CAST(-1020000.0 AS Decimal(19, 1)), 70, N'XLI 410 purchase amount paid')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (291, N'e309b6df-87e0-9f70-fbc6-a0072927d726', CAST(N'2017-12-26' AS Date), CAST(-1002100.0 AS Decimal(19, 1)), 70, N'BA 180 arear paid')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (292, N'c93c6c65-655c-dc86-d078-cf01c2084a63', CAST(N'2017-12-26' AS Date), CAST(-1670000.0 AS Decimal(19, 1)), 69, N'LEB 9410 purchase amount paid')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (293, N'46539bcf-980a-4dbe-78a1-dc6f18bb5146', CAST(N'2017-12-26' AS Date), CAST(-1240000.0 AS Decimal(19, 1)), 66, N'XLI 399 purchase arear paid')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (294, N'3076414f-46b2-133a-ac43-fa97847e8aec', CAST(N'2017-12-26' AS Date), CAST(-1635000.0 AS Decimal(19, 1)), 65, N'ABC 310 purchase amount paid')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (295, N'89cd0c2b-962c-b54e-89ad-a3c2dba211ad', CAST(N'2017-12-26' AS Date), CAST(-240000.0 AS Decimal(19, 1)), 68, N'paid to safdar raza')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (296, N'5a508de5-bee9-04ad-53b1-4b78aa1cd177', CAST(N'2017-12-26' AS Date), CAST(-5500.0 AS Decimal(19, 1)), 70, N'Car 180 comission paid')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (297, N'70d30bf7-1d87-c1d8-eb5c-9941d200b07a', CAST(N'2017-12-26' AS Date), CAST(-735000.0 AS Decimal(19, 1)), 64, N'Paid to Zulfiqar khan')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (298, N'1b0a00e5-88cd-6b06-17c0-4e361a9007c3', CAST(N'2017-12-26' AS Date), CAST(-298500.0 AS Decimal(19, 1)), 68, N'paid to safdar raza')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (299, N'fa3a1c04-3f19-f087-3f52-93be64e7e7be', CAST(N'2017-12-30' AS Date), CAST(6040000.0 AS Decimal(19, 1)), 64, N'LZB 7 sold amount recieved')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (300, N'53b718d6-82c5-cf87-27c6-40e85905651c', CAST(N'2017-12-30' AS Date), CAST(30000.0 AS Decimal(19, 1)), 64, N'XLI 3333 sold advance recieved')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (301, N'acb6f11b-91b5-1771-169a-fa263d2e016a', CAST(N'2017-12-30' AS Date), CAST(1025000.0 AS Decimal(19, 1)), 64, N'ICT AJ 512 arear recieved by aslam gujjar')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (302, N'dfcee9d1-8c73-6e27-84a4-eff721403a29', CAST(N'2017-12-30' AS Date), CAST(25700000.0 AS Decimal(19, 1)), 65, N'Prado 366 arear recieved')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (303, N'23bebe10-fa02-a028-08b6-db83af786660', CAST(N'2017-12-30' AS Date), CAST(8578000.0 AS Decimal(19, 1)), 64, N'LEH 6420sold amount recieved')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (304, N'3650f178-dd70-5408-4a79-53b5841f3222', CAST(N'2017-12-30' AS Date), CAST(8800510.0 AS Decimal(19, 1)), 70, N'CJ 210 arear recieved')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (305, N'ae2e6a25-2470-d7bc-3a1f-df1a2eaf92d6', CAST(N'2017-12-30' AS Date), CAST(3628000.0 AS Decimal(19, 1)), 62, N'ICT RK 270 sold amount recieved')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (306, N'df1beb70-56ce-1969-dd69-c290597873b9', CAST(N'2017-12-30' AS Date), CAST(4870000.0 AS Decimal(19, 1)), 62, N'LED 777 arear recieved')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (307, N'063134e7-7912-6aa9-7d71-daeb65ab3f35', CAST(N'2017-12-30' AS Date), CAST(799000.0 AS Decimal(19, 1)), 64, N'XLI 3333 arear recieved')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (308, N'fd1d58fd-ad43-1b0b-df7c-d989f4565ce6', CAST(N'2017-12-30' AS Date), CAST(666666.0 AS Decimal(19, 1)), 65, N'ACA 375 arear recieved')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (309, N'ed8e5b1e-6fa6-734a-01f5-682ca64b30e9', CAST(N'2017-12-30' AS Date), CAST(1598000.0 AS Decimal(19, 1)), 71, N'LWA 9175 sold amount recieved')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (310, N'680cbdc1-39ae-6674-3ced-46ac9c696264', CAST(N'2017-12-30' AS Date), CAST(7230.0 AS Decimal(19, 1)), 64, N'XLI 3333 token amount recieved')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (311, N'11b2bbb8-059f-d7ef-39cf-33949d21baae', CAST(N'2017-12-30' AS Date), CAST(93130.0 AS Decimal(19, 1)), 62, N'LED 777 token amount recieved')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (312, N'792e2818-1041-7cc5-d9c4-07f072defeed', CAST(N'2017-12-30' AS Date), CAST(3333260.0 AS Decimal(19, 1)), 64, N'LEH 6420arear recieved')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (313, N'41ac46d4-59aa-16d3-b648-befa37321524', CAST(N'2017-12-30' AS Date), CAST(-102300.0 AS Decimal(19, 1)), 64, N'LZB 7 paid to Comissioner ')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (314, N'0b835ddf-19b8-3eaf-104d-db443e127dc1', CAST(N'2017-12-30' AS Date), CAST(-99103.0 AS Decimal(19, 1)), 68, N'Paid to Safdar sb')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (315, N'9410183b-6acf-0172-5cc1-9662a49b0489', CAST(N'2017-12-30' AS Date), CAST(-884990.0 AS Decimal(19, 1)), 62, N'CJ 110 purchase amount paid')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (316, N'7bd1da34-d4b4-6c60-982d-b23556ccb9cc', CAST(N'2017-12-30' AS Date), CAST(-77600.0 AS Decimal(19, 1)), 64, N'GLI 33 transfer fee paid')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (317, N'3268635a-cdc3-74b8-cd0d-dea0c88bcde2', CAST(N'2017-12-30' AS Date), CAST(-280.0 AS Decimal(19, 1)), 65, N'366 excise fee paid')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (318, N'7090733b-8071-924f-a9d8-7884f92fd2d9', CAST(N'2017-12-30' AS Date), CAST(-250.0 AS Decimal(19, 1)), 64, N'XLI 3333 excise fee paid')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (319, N'fad5a2e1-5e13-b8b5-bc16-7692451b7104', CAST(N'2017-12-30' AS Date), CAST(-500.0 AS Decimal(19, 1)), 71, N'LWA 9175 petrol ')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (320, N'999f8943-f781-8cd1-dd94-c51970c2d6ec', CAST(N'2017-12-30' AS Date), CAST(-790.0 AS Decimal(19, 1)), 62, N'ICT RK 270 diesel')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (321, N'33897e5c-8e1f-9210-75de-5c3dc49a112a', CAST(N'2017-12-30' AS Date), CAST(-22100.0 AS Decimal(19, 1)), 70, N'CJ 210Painter bill paid')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (322, N'50071b1a-14e8-099c-16a1-cff847a2f24f', CAST(N'2017-12-30' AS Date), CAST(-107777.0 AS Decimal(19, 1)), 69, N'paid cash to imran wagwal')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (323, N'40d50cfe-d399-89f5-a3b1-62fad1c3b646', CAST(N'2017-12-30' AS Date), CAST(-93636.0 AS Decimal(19, 1)), 64, N'cash paid to zulfiqar khan')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (324, N'6ff26c39-7967-4925-8789-2d7f4f90fa30', CAST(N'2017-12-30' AS Date), CAST(-72200.0 AS Decimal(19, 1)), 65, N'cash paid to akhtar tiwana')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (325, N'3c3a7ea7-c456-c8f3-63f2-8e5e5efccca2', CAST(N'2017-12-30' AS Date), CAST(-133200.0 AS Decimal(19, 1)), 68, N'cash paid to safdar raza')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (326, N'ba7098ea-515f-5bf3-d6cb-ebe1b482bdcf', CAST(N'2017-12-30' AS Date), CAST(-132000.0 AS Decimal(19, 1)), 62, N'xli 2700 painter bill paid by tanveer')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (327, N'cd81273b-569c-34f5-1392-15c27f846f16', CAST(N'2017-12-30' AS Date), CAST(-1236000.0 AS Decimal(19, 1)), 72, N'ICT UE 718 purchase amount paid')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (328, N'b1977eb1-3db3-f302-2aec-d36251835aaf', CAST(N'2018-01-12' AS Date), CAST(240.0 AS Decimal(19, 1)), 71, N'deposited cash by sail deen')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (329, N'a44124be-11f0-e2c4-cf0d-38bcecc0f9b7', CAST(N'2018-01-12' AS Date), CAST(240.0 AS Decimal(19, 1)), 71, N'deposited cash by sail deen')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (330, N'289a97e1-b3b3-cf79-4f29-36d576d04afc', CAST(N'2018-01-12' AS Date), CAST(2312250.0 AS Decimal(19, 1)), 68, N'XLI 219 sold amount recieved')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (331, N'dc35c7c4-e05d-b881-6596-6d5a8e1ee35c', CAST(N'2018-01-12' AS Date), CAST(808.0 AS Decimal(19, 1)), 62, N'UG 780 sold amount recieved')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (332, N'4103ab6f-f2bb-a735-0b20-56d64b6d1ebf', CAST(N'2018-01-12' AS Date), CAST(99100.0 AS Decimal(19, 1)), 71, N'Honda 313 token recieved')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (333, N'b997422b-d120-3a9f-e78b-145c8dd62a0b', CAST(N'2018-01-12' AS Date), CAST(150000.0 AS Decimal(19, 1)), 68, N'GLI 734 sold amount recieved')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (334, N'6d9f4231-492f-d603-ea74-78a2cac6fb40', CAST(N'2018-01-12' AS Date), CAST(1700105.0 AS Decimal(19, 1)), 71, N'Prado 101 sold advance recieved')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (335, N'1ef80c6b-eff9-4246-bdd7-eff9147eff18', CAST(N'2018-01-12' AS Date), CAST(2215000.0 AS Decimal(19, 1)), 72, N'deposited cash by munawar khan')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (336, N'5f304d7f-f4f3-345e-0f6c-758dd3f5b466', CAST(N'2018-01-12' AS Date), CAST(78000.0 AS Decimal(19, 1)), 72, N'Bolan 1938 sold advance recieved')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (337, N'68d2b19a-b446-b947-a776-2f5f83f2c94d', CAST(N'2018-01-12' AS Date), CAST(635000.0 AS Decimal(19, 1)), 62, N'Plot sold amount recieved')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (338, N'973e710b-1f78-4be3-daf5-412378dc8890', CAST(N'2018-01-12' AS Date), CAST(240.0 AS Decimal(19, 1)), 71, N'deposited cash by sail deen')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (339, N'f38bf988-c66a-69d4-1d51-c72c6b55855d', CAST(N'2018-01-12' AS Date), CAST(88700.0 AS Decimal(19, 1)), 70, N'GLI sold amount recieved')
GO
INSERT [dbo].[Transaction] ([Id], [Number], [Date], [Amount], [AccountID], [Description]) VALUES (340, N'a0146ddf-516b-9be2-cc0e-b8c6a6836e7e', CAST(N'2018-01-13' AS Date), CAST(234.0 AS Decimal(19, 1)), 62, N'asdfasdfasdf')
GO
SET IDENTITY_INSERT [dbo].[Transaction] OFF
GO
