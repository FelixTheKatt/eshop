SET IDENTITY_INSERT [dbo].[Products] ON
INSERT INTO [dbo].[Products] ([ProductId], [Name], [Weight], [type], [Price], [Alias], [Statut], [Description], [Image]) VALUES (2, N'TimesCaps', 1, N'Dream', 2000000, N't-01', N'prototype', N'capsule du temps')
INSERT INTO [dbo].[Products] ([ProductId], [Name], [Weight], [type], [Price], [Alias], [Statut], [Description], [Image]) VALUES (3, N'HorseCaps', 1, N'Strenght', 50, N'h-01', N'Full', N'Galoper')
INSERT INTO [dbo].[Products] ([ProductId], [Name], [Weight], [type], [Price], [Alias], [Statut], [Description], [Image]) VALUES (4, N'PowerCaps', 1, N'Strenght', 150, N'0xP', N'Full', N'POWERRR')
SET IDENTITY_INSERT [dbo].[Products] OFF
