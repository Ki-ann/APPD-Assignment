USE [APPD_AssignmentDB]
GO
/****** Object:  Table [dbo].[Item]    Script Date: 18/1/2017 6:44:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Item](
	[ItemId] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [varchar](100) NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Order]    Script Date: 18/1/2017 6:44:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[OrderDateTime] [datetime2](7) NULL,
	[OrderedBy] [int] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 18/1/2017 6:44:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrderDetailId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NULL,
	[RentalId] [int] NULL,
	[ItemId] [int] NULL,
	[ReserveDate] [datetime2](7) NULL,
	[PickUpTimeSlot] [varchar](50) NULL,
	[Address] [varchar](100) NULL,
	[PstlCd] [int] NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[OrderDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Rental]    Script Date: 18/1/2017 6:44:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rental](
	[RentalId] [int] IDENTITY(1,1) NOT NULL,
	[RentalType] [varchar](100) NULL,
	[RentalPrice] [decimal](18, 0) NULL,
	[ItemId] [int] NULL,
 CONSTRAINT [PK_Rental] PRIMARY KEY CLUSTERED 
(
	[RentalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 18/1/2017 6:44:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](100) NULL,
	[Firstname] [varchar](50) NULL,
	[Lastname] [varchar](50) NULL,
	[CardType] [varchar](50) NULL,
	[CardNo] [varchar](12) NULL,
	[ExpMon] [date] NULL,
	[ExpYr] [date] NULL,
	[SecCd] [int] NULL,
	[BillAdd] [varchar](100) NULL,
	[PostCd] [int] NULL,
	[PhoneNo] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Item] ON 

GO
INSERT [dbo].[Item] ([ItemId], [ItemName]) VALUES (1, N'Cleaner')
GO
INSERT [dbo].[Item] ([ItemId], [ItemName]) VALUES (2, N'Package Cleaning')
GO
SET IDENTITY_INSERT [dbo].[Item] OFF
GO
SET IDENTITY_INSERT [dbo].[Rental] ON 

GO
INSERT [dbo].[Rental] ([RentalId], [RentalType], [RentalPrice], [ItemId]) VALUES (1, N'Single Cleaner', CAST(12 AS Decimal(18, 0)), 1)
GO
INSERT [dbo].[Rental] ([RentalId], [RentalType], [RentalPrice], [ItemId]) VALUES (2, N'Sweep + Mop + Polish Floor', CAST(30 AS Decimal(18, 0)), 2)
GO
INSERT [dbo].[Rental] ([RentalId], [RentalType], [RentalPrice], [ItemId]) VALUES (3, N'Washing of aircon + Fanblades', CAST(30 AS Decimal(18, 0)), 2)
GO
INSERT [dbo].[Rental] ([RentalId], [RentalType], [RentalPrice], [ItemId]) VALUES (4, N'Grime removal of floor and wall tiles', CAST(40 AS Decimal(18, 0)), 2)
GO
SET IDENTITY_INSERT [dbo].[Rental] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

GO
INSERT [dbo].[User] ([UserId], [UserName], [Firstname], [Lastname], [CardType], [CardNo], [ExpMon], [ExpYr], [SecCd], [BillAdd], [PostCd], [PhoneNo]) VALUES (1, N'Admin', N'Admin', N'Account', N'MasterCard', N'111111111111', NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [Firstname], [Lastname], [CardType], [CardNo], [ExpMon], [ExpYr], [SecCd], [BillAdd], [PostCd], [PhoneNo]) VALUES (2, N'CINDY', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [DF_Order_OrderDateTime]  DEFAULT (getdate()) FOR [OrderDateTime]
GO
