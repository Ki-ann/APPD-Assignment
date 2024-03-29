USE [master]
GO
/****** Object:  Database [EF.CA2Assignemnt.NewDb]    Script Date: 13/2/2017 2:43:05 AM ******/
CREATE DATABASE [EF.CA2Assignemnt.NewDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EF.CA2Assignemnt.NewDb', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\EF.CA2Assignemnt.NewDb.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EF.CA2Assignemnt.NewDb_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\EF.CA2Assignemnt.NewDb_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [EF.CA2Assignemnt.NewDb] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EF.CA2Assignemnt.NewDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EF.CA2Assignemnt.NewDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EF.CA2Assignemnt.NewDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EF.CA2Assignemnt.NewDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EF.CA2Assignemnt.NewDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EF.CA2Assignemnt.NewDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [EF.CA2Assignemnt.NewDb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [EF.CA2Assignemnt.NewDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EF.CA2Assignemnt.NewDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EF.CA2Assignemnt.NewDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EF.CA2Assignemnt.NewDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EF.CA2Assignemnt.NewDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EF.CA2Assignemnt.NewDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EF.CA2Assignemnt.NewDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EF.CA2Assignemnt.NewDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EF.CA2Assignemnt.NewDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [EF.CA2Assignemnt.NewDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EF.CA2Assignemnt.NewDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EF.CA2Assignemnt.NewDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EF.CA2Assignemnt.NewDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EF.CA2Assignemnt.NewDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EF.CA2Assignemnt.NewDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [EF.CA2Assignemnt.NewDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EF.CA2Assignemnt.NewDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EF.CA2Assignemnt.NewDb] SET  MULTI_USER 
GO
ALTER DATABASE [EF.CA2Assignemnt.NewDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EF.CA2Assignemnt.NewDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EF.CA2Assignemnt.NewDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EF.CA2Assignemnt.NewDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [EF.CA2Assignemnt.NewDb] SET DELAYED_DURABILITY = DISABLED 
GO
USE [EF.CA2Assignemnt.NewDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 13/2/2017 2:43:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Booking]    Script Date: 13/2/2017 2:43:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[BookingId] [int] IDENTITY(1,1) NOT NULL,
	[BookingDateTime] [datetime2](7) NOT NULL,
	[ItemId] [int] NOT NULL,
	[ReservedAddress] [nvarchar](max) NOT NULL,
	[ReservedDate] [datetime2](7) NOT NULL,
	[ReservedPostal] [nvarchar](max) NOT NULL,
	[TimeSlotIn] [nvarchar](max) NOT NULL,
	[TimeSlotOut] [nvarchar](max) NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[BookingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 13/2/2017 2:43:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Item]    Script Date: 13/2/2017 2:43:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item](
	[ItemId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[ItemName] [nvarchar](max) NOT NULL,
	[ItemPrice] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Payment]    Script Date: 13/2/2017 2:43:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[PaymentId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[CVC] [int] NOT NULL,
	[CardNo] [nvarchar](max) NOT NULL,
	[ExpDate] [datetime2](7) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[PaymentId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 13/2/2017 2:43:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[EmailAdd] [nvarchar](max) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[PhoneNo] [nvarchar](max) NOT NULL,
	[PostCd] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170209154928_MyMigration', N'1.1.0-rtm-22752')
SET IDENTITY_INSERT [dbo].[Booking] ON 

INSERT [dbo].[Booking] ([BookingId], [BookingDateTime], [ItemId], [ReservedAddress], [ReservedDate], [ReservedPostal], [TimeSlotIn], [TimeSlotOut], [UserId]) VALUES (1, CAST(N'2017-02-10 03:55:06.1993901' AS DateTime2), 1, N'aasd', CAST(N'2017-02-10 00:00:00.0000000' AS DateTime2), N'asd', N'10:00', N'14:00', 1)
INSERT [dbo].[Booking] ([BookingId], [BookingDateTime], [ItemId], [ReservedAddress], [ReservedDate], [ReservedPostal], [TimeSlotIn], [TimeSlotOut], [UserId]) VALUES (2, CAST(N'2017-02-10 15:22:42.2215402' AS DateTime2), 1, N'asd', CAST(N'2017-02-10 00:00:00.0000000' AS DateTime2), N'123', N'17:00', N'19:00', 1)
INSERT [dbo].[Booking] ([BookingId], [BookingDateTime], [ItemId], [ReservedAddress], [ReservedDate], [ReservedPostal], [TimeSlotIn], [TimeSlotOut], [UserId]) VALUES (3, CAST(N'2017-02-10 15:38:12.6274998' AS DateTime2), 1, N'asd', CAST(N'2017-02-10 00:00:00.0000000' AS DateTime2), N'123', N'15:00', N'16:00', 2)
INSERT [dbo].[Booking] ([BookingId], [BookingDateTime], [ItemId], [ReservedAddress], [ReservedDate], [ReservedPostal], [TimeSlotIn], [TimeSlotOut], [UserId]) VALUES (4, CAST(N'2017-02-10 16:54:55.7425417' AS DateTime2), 2, N'asd', CAST(N'2017-02-16 00:00:00.0000000' AS DateTime2), N'123', N'12:00', N'13:00', 1)
INSERT [dbo].[Booking] ([BookingId], [BookingDateTime], [ItemId], [ReservedAddress], [ReservedDate], [ReservedPostal], [TimeSlotIn], [TimeSlotOut], [UserId]) VALUES (5, CAST(N'2017-02-13 01:08:16.0825714' AS DateTime2), 1, N'asd', CAST(N'2017-02-14 00:00:00.0000000' AS DateTime2), N'123', N'10:00', N'12:00', 1)
SET IDENTITY_INSERT [dbo].[Booking] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (1, N'Single Cleaning')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (2, N'Package Cleaning')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Item] ON 

INSERT [dbo].[Item] ([ItemId], [CategoryId], [ItemName], [ItemPrice]) VALUES (1, 1, N'Single Cleaning', CAST(10.00 AS Decimal(18, 2)))
INSERT [dbo].[Item] ([ItemId], [CategoryId], [ItemName], [ItemPrice]) VALUES (2, 2, N'Sweep + Mop + Polish Floor', CAST(20.00 AS Decimal(18, 2)))
INSERT [dbo].[Item] ([ItemId], [CategoryId], [ItemName], [ItemPrice]) VALUES (3, 2, N'Washing of aircon + Fanblades', CAST(30.00 AS Decimal(18, 2)))
INSERT [dbo].[Item] ([ItemId], [CategoryId], [ItemName], [ItemPrice]) VALUES (4, 2, N'Grime removal of floor and wall tiles', CAST(40.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Item] OFF
SET IDENTITY_INSERT [dbo].[Payment] ON 

INSERT [dbo].[Payment] ([PaymentId], [UserId], [CVC], [CardNo], [ExpDate], [FirstName], [LastName]) VALUES (1, 1, 123, N'1234', CAST(N'2010-06-08 00:00:00.0000000' AS DateTime2), N'Hello', N'World')
INSERT [dbo].[Payment] ([PaymentId], [UserId], [CVC], [CardNo], [ExpDate], [FirstName], [LastName]) VALUES (2, 0, 123, N'12312321', CAST(N'2017-02-10 00:00:00.0000000' AS DateTime2), N'p', N'p')
SET IDENTITY_INSERT [dbo].[Payment] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [Address], [EmailAdd], [FirstName], [LastName], [Password], [PhoneNo], [PostCd]) VALUES (1, N'TextBox', N'123@123.com', N'TextBox', N'TextBox', N'password', N'TextBox', N'TextBox')
INSERT [dbo].[User] ([UserId], [Address], [EmailAdd], [FirstName], [LastName], [Password], [PhoneNo], [PostCd]) VALUES (2, N'p', N'asd@123.com', N'p', N'p', N'password', N'p', N'123456')
SET IDENTITY_INSERT [dbo].[User] OFF
/****** Object:  Index [AK_Payment_PaymentId]    Script Date: 13/2/2017 2:43:05 AM ******/
ALTER TABLE [dbo].[Payment] ADD  CONSTRAINT [AK_Payment_PaymentId] UNIQUE NONCLUSTERED 
(
	[PaymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [EF.CA2Assignemnt.NewDb] SET  READ_WRITE 
GO
