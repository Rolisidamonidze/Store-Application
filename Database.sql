USE [master]
GO
/****** Object:  Database [Market]    Script Date: 8/10/2021 7:42:08 PM ******/
CREATE DATABASE [Market]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Market', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Market.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Market_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Market_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Market] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Market].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Market] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Market] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Market] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Market] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Market] SET ARITHABORT OFF 
GO
ALTER DATABASE [Market] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Market] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Market] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Market] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Market] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Market] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Market] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Market] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Market] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Market] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Market] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Market] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Market] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Market] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Market] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Market] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Market] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Market] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Market] SET  MULTI_USER 
GO
ALTER DATABASE [Market] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Market] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Market] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Market] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Market] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Market] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Market] SET QUERY_STORE = OFF
GO
USE [Market]
GO
/****** Object:  UserDefinedFunction [dbo].[HasUserPermission_F]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE function [dbo].[HasUserPermission_F](@UserID int, @PermissionCode int)
returns bit
as
	begin
		if exists(
		select P.PermissionCode, P.Description from UserGroups UG
		inner join Groups G on UG.GroupID = G.ID 
		inner join GroupPermissons GP on GP.GroupID = UG.GroupID
		inner join Permissions P on P.PermissionCode = GP.PermissionCode
		where 
		UserID = @UserID 
		and UG.IsDeleted = 0
		and P.PermissionCode = @PermissionCode)
			begin
				return 1
			end
		else
			begin
				return 0
			end
		return -1;
	end
	
GO
/****** Object:  Table [dbo].[ProductDetails]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductDetails](
	[ID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[ExpirationDate] [date] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK__ProductD__8971168CAF8D4410] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[ExpirationDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[GetAvailableProducts_F]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[GetAvailableProducts_F](@ProductID int)
returns table
as
return 
	select ExpirationDate, Quantity 
	from ProductDetails 
	where ExpirationDate >= cast(getdate() as date) and Quantity > 0;
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](30) NOT NULL,
	[PersonalID] [char](11) NOT NULL,
	[Phone] [varchar](20) NULL,
	[Email] [nvarchar](30) NULL,
	[HomeAddress] [nvarchar](50) NULL,
	[StartJob] [date] NOT NULL,
	[EndJob] [date] NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[GetEmployees]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[GetEmployees]
as
	select E.ID, E.FirstName, E.LastName, E.PersonalID, E.HomeAddress, E.Email, E.Phone, E.StartJob, E.EndJob
	from Employees E
	where E.IsDeleted = 0
GO
/****** Object:  Table [dbo].[Users]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] NOT NULL,
	[Username] [nvarchar](30) NOT NULL,
	[Password] [char](128) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[GetUsers]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create view [dbo].[GetUsers] 
as
	select U.ID, U.Username
	from Users U
	where U.IsActive = 1 and
		  U.IsDeleted = 0
GO
/****** Object:  Table [dbo].[Providers]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Providers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Phone] [varchar](20) NOT NULL,
	[Email] [nvarchar](30) NULL,
	[IsDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[GetProviders]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create view [dbo].[GetProviders]
as
	select P.ID, P.Name, P.Phone, P.Email
	from Providers P
	where P.IsDeleted = 0
GO
/****** Object:  Table [dbo].[Products]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductCode] [smallint] NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[CategoryID] [int] NULL,
	[UnitPrice] [money] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[ProductCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[GetProducts]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[GetProducts] 
as
	select P.ID, P.CategoryID, P.Name, P.ProductCode, P.UnitPrice
	from Products P
	where P.IsDeleted = 0
GO
/****** Object:  Table [dbo].[GroupPermissons]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupPermissons](
	[GroupID] [int] NOT NULL,
	[PermissionCode] [smallint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC,
	[PermissionCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permissions]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permissions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PermissionCode] [smallint] NOT NULL,
	[Description] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[PermissionCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserGroups]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserGroups](
	[UserID] [int] NOT NULL,
	[GroupID] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[GroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Groups]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK__Groups__3214EC27454FA083] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__Groups__737584F64FD2BA84] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[GetUserPermissions_F]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE function [dbo].[GetUserPermissions_F](@UserID int)
returns table
as
return
	select P.PermissionCode from UserGroups UG
	inner join Groups G on UG.GroupID = G.ID 
	inner join GroupPermissons GP on GP.GroupID = UG.GroupID
	inner join Permissions P on P.PermissionCode = GP.PermissionCode
	where UserID = @UserID and UG.IsDeleted = 0
GO
/****** Object:  Table [dbo].[PurchaseDetails]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseDetails](
	[ID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[Quantity] [smallint] NOT NULL,
	[StoreDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[GetPurchaseDetails]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[GetPurchaseDetails]
AS
SELECT ID AS Expr1, ProductID AS Expr2, Quantity AS Expr3, StoreDate AS Expr4, UnitPrice AS Expr5
FROM     dbo.PurchaseDetails AS PD
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[ID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Quantity] [smallint] NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[Discount] [real] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[GetOrderDetails]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[GetOrderDetails]
as
	select OD.ID, OD.ProductID, OD.Quantity, OD.Discount, OD.UnitPrice
	from OrderDetails OD
GO
/****** Object:  View [dbo].[GetProductDetails]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[GetProductDetails] 
as
	select PR.ID, PR.Quantity, PR.ExpirationDate
	from ProductDetails PR
	where PR.IsDeleted = 0
GO
/****** Object:  View [dbo].[GetGroups]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[GetGroups]
as
	select G.ID, G.Name
	from Groups G
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[GetCategorys]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[GetCategorys]
as
	select C.ID, C.Name, C.Description
	from Categories C
	where C.IsDeleted = 0
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[OrderDate] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[GetOrders]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[GetOrders]
as
	select O.ID, O.OrderDate, O.UserID, OD.ProductID, OD.Quantity, OD.Discount, OD.UnitPrice
	from Orders O
	inner join OrderDetails OD on O.ID = OD.ID
GO
/****** Object:  Table [dbo].[Purchases]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchases](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProviderID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[PurchaseDate] [date] NOT NULL,
	[RequiredDate] [date] NOT NULL,
 CONSTRAINT [PK__Purchase__3214EC2748D79249] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[GetPurchases]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[GetPurchases]
as
	select P.ID, P.UserID, P.ProviderID, P.PurchaseDate, P.RequiredDate, 
		   PD.Quantity, PD.StoreDate, PD.UnitPrice
	from Purchases P 
	inner join PurchaseDetails PD on P.ID = PD.ID
GO
ALTER TABLE [dbo].[Categories] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Employees] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (getdate()) FOR [OrderDate]
GO
ALTER TABLE [dbo].[ProductDetails] ADD  CONSTRAINT [DF__ProductDe__IsDel__44FF419A]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Providers] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[PurchaseDetails] ADD  DEFAULT (getdate()) FOR [StoreDate]
GO
ALTER TABLE [dbo].[Purchases] ADD  CONSTRAINT [DF__Purchases__Order__4D94879B]  DEFAULT (getdate()) FOR [PurchaseDate]
GO
ALTER TABLE [dbo].[UserGroups] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[GroupPermissons]  WITH CHECK ADD  CONSTRAINT [FK__GroupPerm__Group__220B0B18] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Groups] ([ID])
GO
ALTER TABLE [dbo].[GroupPermissons] CHECK CONSTRAINT [FK__GroupPerm__Group__220B0B18]
GO
ALTER TABLE [dbo].[GroupPermissons]  WITH CHECK ADD FOREIGN KEY([PermissionCode])
REFERENCES [dbo].[Permissions] ([PermissionCode])
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ID])
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD FOREIGN KEY([ID])
REFERENCES [dbo].[Orders] ([ID])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[ProductDetails]  WITH CHECK ADD  CONSTRAINT [FK__ProductDetai__ID__4316F928] FOREIGN KEY([ID])
REFERENCES [dbo].[Products] ([ID])
GO
ALTER TABLE [dbo].[ProductDetails] CHECK CONSTRAINT [FK__ProductDetai__ID__4316F928]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([ID])
GO
ALTER TABLE [dbo].[PurchaseDetails]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ID])
GO
ALTER TABLE [dbo].[PurchaseDetails]  WITH CHECK ADD  CONSTRAINT [FK__PurchaseDeta__ID__5070F446] FOREIGN KEY([ID])
REFERENCES [dbo].[Purchases] ([ID])
GO
ALTER TABLE [dbo].[PurchaseDetails] CHECK CONSTRAINT [FK__PurchaseDeta__ID__5070F446]
GO
ALTER TABLE [dbo].[Purchases]  WITH CHECK ADD  CONSTRAINT [FK__Purchases__Provi__4BAC3F29] FOREIGN KEY([ProviderID])
REFERENCES [dbo].[Providers] ([ID])
GO
ALTER TABLE [dbo].[Purchases] CHECK CONSTRAINT [FK__Purchases__Provi__4BAC3F29]
GO
ALTER TABLE [dbo].[Purchases]  WITH CHECK ADD  CONSTRAINT [FK__Purchases__UserI__4CA06362] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Purchases] CHECK CONSTRAINT [FK__Purchases__UserI__4CA06362]
GO
ALTER TABLE [dbo].[UserGroups]  WITH CHECK ADD  CONSTRAINT [FK__UserGroup__Group__36B12243] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Groups] ([ID])
GO
ALTER TABLE [dbo].[UserGroups] CHECK CONSTRAINT [FK__UserGroup__Group__36B12243]
GO
ALTER TABLE [dbo].[UserGroups]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([ID])
REFERENCES [dbo].[Employees] ([ID])
GO
/****** Object:  StoredProcedure [dbo].[ActivateUser_SP]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[ActivateUser_SP]
@ID int
as
	begin
		set nocount on;

		update Users
		set isActive = 1
		where ID = @ID

		return 0;
	end

GO
/****** Object:  StoredProcedure [dbo].[Authenticate_SP]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Authenticate_SP]
@Username nvarchar(50), 
@Password char(128)
as
	begin
		set nocount on;
		
		declare @UserID int = (select U.ID from Users U
		where U.Username = @Username
		and U.Password = hashbytes('MD5', @Password))

	   if(@UserID is null)
	   begin
			select -1;
			return -1;
	   end

	   select @UserID
	   return @UserID
	end
GO
/****** Object:  StoredProcedure [dbo].[Authorize_SP]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Authorize_SP]
@Username nvarchar(50), 
@Password char(128)
as
	begin
		set nocount on;

		declare @UserID int = (select U.ID from Users U
		where U.Username = @Username
		and U.Password = hashbytes('MD5', @Password))

		if(@UserID != null)
			begin
				select distinct P.PermissionCode, p.Description from UserGroups UG
				inner join Groups G on UG.GroupID = G.ID and UG.IsDeleted = 0
				inner join GroupPermissons GP on GP.GroupID = UG.GroupID
				inner join Permissions P on P.PermissionCode = GP.PermissionCode
				where UserID = @UserID
			end
	end
GO
/****** Object:  StoredProcedure [dbo].[DeactivateUser_SP]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[DeactivateUser_SP]
@ID int
as
	begin
		set nocount on;

		update Users
		set isActive = 0
		where ID = @ID

		return 0;
	end

GO
/****** Object:  StoredProcedure [dbo].[DeleteCategory_SP]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[DeleteCategory_SP]
@CurrentUserID int,
@ID int
as
	begin
		set nocount on;

		
		declare @HasPermission int
		exec @HasPermission = HasUserPermission_F @CurrentUserID, 26
		if(@HasPermission = 0)
		begin
			raiserror ('No Permission', 16, 1)
		end

		update Categories
		set IsDeleted = 1

		return 0;
	end
GO
/****** Object:  StoredProcedure [dbo].[DeleteEmployee_SP]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[DeleteEmployee_SP]
@CurrentUserID int,
@ID int
as
	begin
		set nocount on;

		declare @HasPermission int
		exec @HasPermission = HasUserPermission_F @CurrentUserID, 3

		if(@HasPermission = 0)
		begin
			raiserror ('No Permission', 16, 1)
		end

		update Employees
		set IsDeleted = 1
		where ID = @ID

		return 0;
		
	end
GO
/****** Object:  StoredProcedure [dbo].[DeleteProduct_SP]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[DeleteProduct_SP]
@CurrentUserID int,
@ID int
as
	begin
		set nocount on;

		declare @HasPermission int
		exec @HasPermission = HasUserPermission_F @CurrentUserID, 20
		if(@HasPermission = 0)
		begin
			raiserror ('No Permission', 16, 1)
		end

		update Products
		set IsDeleted = 1
		where ID = @ID

		return 0;
	end
GO
/****** Object:  StoredProcedure [dbo].[DeleteProductDetail_SP]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[DeleteProductDetail_SP]
@CurrentUserID int,
@ID int
as
	begin
		set nocount on;

		declare @HasPermission int
		exec @HasPermission = HasUserPermission_F @CurrentUserID, 23
		if(@HasPermission = 0)
		begin
			raiserror ('No Permission', 16, 1)
		end
		
		update ProductDetails
		set IsDeleted = 1
		where ID = @ID

		return 0;
	end
GO
/****** Object:  StoredProcedure [dbo].[DeleteProvider_SP]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[DeleteProvider_SP]
@CurrentUserID int,
@ID int
as
	begin
		set nocount on;

		declare @HasPermission int
		exec @HasPermission = HasUserPermission_F @CurrentUserID, 9

		if(@HasPermission = 0)
		begin
			raiserror ('No Permission', 16, 1)
		end

		update Providers
		set IsDeleted = 1
		where ID = @ID

		return 0
	end
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser_SP]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[DeleteUser_SP]
@CurrentUserID int,
@ID int
as
	begin
		set nocount on;

		declare @HasPermission int
		exec @HasPermission = HasUserPermission_F @CurrentUserID, 6

		if(@HasPermission = 0)
		begin
			raiserror ('No Permission', 16, 1)
		end

		update Users
		set IsDeleted = 1
		where ID = @ID

		exec DeactivateUser_SP @ID

		return 0;
	end

GO
/****** Object:  StoredProcedure [dbo].[GetProcedureParameters_SP]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetProcedureParameters_SP]
@ProcedureName varchar(50)
as
select parameters.name as Name
from sys.parameters
inner join sys.procedures on parameters.object_id = procedures.object_id
inner join sys.types on parameters.system_type_id = types.system_type_id
        AND parameters.user_type_id = types.user_type_id
where procedures.name = @ProcedureName
GO
/****** Object:  StoredProcedure [dbo].[GetUserPermissions_SP]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetUserPermissions_SP]
@ID int
as
	begin
		set nocount on;
	
		select distinct P.PermissionCode, p.Description from UserGroups UG
		inner join Groups G on UG.GroupID = G.ID and UG.IsDeleted = 0
		inner join GroupPermissons GP on GP.GroupID = UG.GroupID
		inner join Permissions P on P.PermissionCode = GP.PermissionCode
		where UserID = @ID
	end
GO
/****** Object:  StoredProcedure [dbo].[InsertCategory_SP]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[InsertCategory_SP]
@CurrentUserID int,
@Name nvarchar(30),
@Description nvarchar(200)
as
	begin
		set nocount on;

		
		declare @HasPermission int
		exec @HasPermission = HasUserPermission_F @CurrentUserID, 24
		if(@HasPermission = 0)
		begin
			raiserror ('No Permission', 16, 1)
		end

		insert into Categories(Name, Description)
		values(@Name, @Description)

		select @@IDENTITY as ID
		return 0;
	end
GO
/****** Object:  StoredProcedure [dbo].[InsertEmployee_SP]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[InsertEmployee_SP]
@CurrentUserID int,
@Firstname nvarchar(20),
@Lastname nvarchar(30),
@PersonalID char(11),
@Phone varchar(20),
@Email nvarchar(30),
@HomeAddress nvarchar(50),
@StartJob date,
@EndJob date
as
	begin
		set nocount on;

		declare @HasPermission int
		exec @HasPermission = HasUserPermission_F @CurrentUserID, 1

		if(@HasPermission = 0)
		begin
			raiserror ('No Permission', 16, 1)
		end


		insert into Employees(FirstName, LastName, PersonalID, Phone, Email, HomeAddress, StartJob, EndJob)
		values(@FirstName, @LastName, @PersonalID, @Phone, @Email, @HomeAddress, @StartJob, @EndJob)

		select @@IDENTITY as ID
		return 0
	end
GO
/****** Object:  StoredProcedure [dbo].[InsertOrder_SP]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[InsertOrder_SP]
@CurrentUserID int,
@UserID int
as
	begin
		set nocount on;
		
		declare @HasPermission int
		exec @HasPermission = HasUserPermission_F @CurrentUserID, 14

		if(@HasPermission = 0)
		begin
			raiserror ('No Permission', 16, 1)
		end

		insert into Orders(UserID, OrderDate)
		values(@UserID, getdate())

		select @@IDENTITY as ID
		return 0;
	end
GO
/****** Object:  StoredProcedure [dbo].[InsertOrderDetail_SP]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-------------------------------------------------OrderDetails

CREATE proc [dbo].[InsertOrderDetail_SP]
@CurrentUserID int,
@ID int,
@ProductID int,
@Quantity smallint,
@UnitPrice money,
@Discount real
as
	begin
		set nocount on;

		declare @HasPermission int
		exec @HasPermission = HasUserPermission_F @CurrentUserID, 17

		if(@HasPermission = 0)
		begin
			raiserror ('No Permission', 16, 1)
		end

		declare @TempQuantity int
		set @TempQuantity = (select sum(Quantity) from GetAvailableProducts_F(@ProductID))

		if(@TempQuantity < @Quantity)
			begin
				raiserror('There is not enough quantity in the store', 16, 1)
			end

		declare @UrgentQuantity int
		declare @UrgentDate date
		set @TempQuantity = @Quantity
		while(@TempQuantity > 0)
			begin
				set @UrgentQuantity = (select top(1)Quantity 
									   from GetAvailableProducts_F(@ProductID) 
									   order by ExpirationDate asc)
				set @UrgentDate = (select top(1)ExpirationDate 
								   from GetAvailableProducts_F(1) 
								   order by ExpirationDate asc)
				if(@TempQuantity > @UrgentQuantity)
					begin
						set @TempQuantity -= @UrgentQuantity
						exec UpdateProductDetail_SP @CurrentUserID, @ID, @UrgentQuantity, 0
					end
				else
					begin
						set @UrgentQuantity -= @TempQuantity
						set @TempQuantity = 0
						exec UpdateProductDetail_SP @CurrentUserID, @ID, @UrgentQuantity, @UrgentDate
					end
			end


		insert into OrderDetails(ID, ProductID, Quantity, UnitPrice, Discount)
		values(@ID, @ProductID, @Quantity, @UnitPrice, @Discount)

		select @ID as OrderID, @ProductID as ProductID
		return 0;
	end
GO
/****** Object:  StoredProcedure [dbo].[InsertProduct_SP]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-------------------------------------------------Products

CREATE proc [dbo].[InsertProduct_SP]
@CurrentUserID int,
@ProductCode smallint,
@Name nvarchar(50),
@CategoryID int,
@UnitPrice money
as
	begin
		set nocount on;

		declare @HasPermission int
		exec @HasPermission = HasUserPermission_F @CurrentUserID, 18

		if(@HasPermission = 0)
		begin
			raiserror ('No Permission', 16, 1)
		end

		insert into Products(ProductCode, Name, CategoryID, UnitPrice)
		values(@ProductCode, @Name, @CategoryID, @UnitPrice)

		select @@IDENTITY as ID
		return 0
	end
GO
/****** Object:  StoredProcedure [dbo].[InsertProductDetail_SP]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-------------------------------------------------ProductDetails

CREATE proc [dbo].[InsertProductDetail_SP]
@CurrentUserID int,
@ID int,
@Quantity int,
@ExpirationDate date
as
	begin
		set nocount on;

		declare @HasPermission int
		exec @HasPermission = HasUserPermission_F @CurrentUserID, 21
		if(@HasPermission = 0)
		begin
			raiserror ('No Permission', 16, 1)
		end

		insert into ProductDetails(ID, Quantity, ExpirationDate)
		values(@ID, @Quantity, @ExpirationDate)

		select @ID
		return 0;
	end
GO
/****** Object:  StoredProcedure [dbo].[InsertProvider_SP]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-------------------------------------------------Providers

CREATE proc [dbo].[InsertProvider_SP]
@CurrentUserID int,
@Name nvarchar(30),
@Phone varchar(20),
@Email nvarchar(30)
as
	begin
		set nocount on;

		declare @HasPermission int
		exec @HasPermission = HasUserPermission_F @CurrentUserID, 7

		if(@HasPermission = 0)
		begin
			raiserror ('No Permission', 16, 1)
		end

		insert into Providers(Name, Phone, Email)
		values(@Name, @Phone, @Email)

		select @@IDENTITY as ID
		return 0;
	end
GO
/****** Object:  StoredProcedure [dbo].[InsertPurchase_SP]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-------------------------------------------------Purchases

CREATE proc [dbo].[InsertPurchase_SP]
@CurrentUserID int,
@ProviderID int,
@UserID int,
@RequiredDate date
as
	begin
		set nocount on;

		declare @HasPermission int
		exec @HasPermission = HasUserPermission_F @CurrentUserID, 10

		if(@HasPermission = 0)
		begin
			raiserror ('No Permission', 16, 1)
		end

		insert into Purchases(ProviderID, UserID, PurchaseDate, RequiredDate)
		values(@ProviderID, @UserID, GETDATE(), @RequiredDate)

		select @@IDENTITY as ID;
		return 0;
	end
GO
/****** Object:  StoredProcedure [dbo].[InsertPurchaseDetail_SP]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-------------------------------------------------PurchaseDetails

CREATE proc [dbo].[InsertPurchaseDetail_SP]
@CurrentUserID int,
@ID int,
@ProductID int,
@UnitPrice money,
@Quantity smallint,
@ExpirationDate date
as
	begin
		set nocount on;
		
		declare @HasPermission int
		exec @HasPermission = HasUserPermission_F @CurrentUserID, 13

		if(@HasPermission = 0)
		begin
			raiserror ('No Permission', 16, 1)
		end

		insert into PurchaseDetails(ID, ProductID, UnitPrice, Quantity)
		values (@ID, @ProductID, @UnitPrice, @Quantity)

		exec InsertProductDetail_SP @CurrentUserID, @ProductID, @Quantity, @ExpirationDate

		select @ID as ID, @ProductID as ProductID
		return 0
	end
GO
/****** Object:  StoredProcedure [dbo].[InsertUser_SP]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-------------------------------------------------Users

CREATE proc [dbo].[InsertUser_SP]
@CurrentUserID int,
@ID int,
@Username nvarchar(50), 
@Password char(128)
as
    begin
        set nocount on;

		declare @HasPermission int
		exec @HasPermission = HasUserPermission_F @CurrentUserID, 4

		if(@HasPermission = 0)
		begin
			raiserror ('No Permission', 16, 1)
		end

		insert into Users(ID, Username, Password)
		values (@ID, @Username, hashbytes('MD5', @Password))

        return 0;
    end

GO
/****** Object:  StoredProcedure [dbo].[InsertUserGroup_SP]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[InsertUserGroup_SP]
@CurrentUserID int,
@UserID int,
@GroupID int
as
	begin
		
		declare @HasPermission int
		exec @HasPermission = HasUserPermission_F @CurrentUserID, 27
		if(@HasPermission = 0)
		begin
			raiserror ('No Permission', 16, 1)
		end
		
		set nocount on;
		insert into UserGroups(UserID, GroupID)
		values(@UserID, @GroupID)
		select @@IDENTITY as ID

		return 0;
	end
GO
/****** Object:  StoredProcedure [dbo].[ProcedureExists_SP]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ProcedureExists_SP]
@ProcedureName varchar(50)
as
if exists(
	select parameters.name
	from sys.parameters
	inner join sys.procedures on parameters.object_id = procedures.object_id
	where procedures.name = @ProcedureName
)
	begin
		select 1;
	end
else
	begin
		select 0;
	end
	
GO
/****** Object:  StoredProcedure [dbo].[UpdateCategory_SP]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[UpdateCategory_SP]
@CurrentUserID int,
@ID int,
@Name nvarchar(30),
@Description nvarchar(200)
as
	begin
		set nocount on;

		
		declare @HasPermission int
		exec @HasPermission = HasUserPermission_F @CurrentUserID, 25
		if(@HasPermission = 0)
		begin
			raiserror ('No Permission', 16, 1)
		end

		update Categories
		set Name = @Name,
			Description = @Description
		where ID = @ID

		return 0;
	end
GO
/****** Object:  StoredProcedure [dbo].[UpdateEmployee_SP]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UpdateEmployee_SP]
@CurrentUserID int,
@ID int,
@FirstName nvarchar(20),
@LastName nvarchar(30),
@PersonalID char(11),
@Phone varchar(20),
@Email nvarchar(30),
@HomeAddress nvarchar(50),
@StartJob date,
@EndJob date
as
	begin
		set nocount on;

		declare @HasPermission int
		exec @HasPermission = HasUserPermission_F @CurrentUserID, 2

		if(@HasPermission = 0)
		begin
			raiserror ('No Permission', 16, 1)
		end

		update Employees
		set FirstName = @FirstName,
			LastName = @LastName,
			PersonalID = @PersonalID,
			Phone = @Phone,
			Email = @Email,
			HomeAddress = @HomeAddress,
			StartJob = @StartJob,
			EndJob = @EndJob
		where ID = @ID

		return 0;
	end
GO
/****** Object:  StoredProcedure [dbo].[UpdateOrder_SP]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateOrder_SP]
@CurrentUserID int,
@ID int,
@UserID int,
@OrderDate date
as
	begin
		set nocount on;

		declare @HasPermission int
		exec @HasPermission = HasUserPermission_F @CurrentUserID, 15

		if(@HasPermission = 0)
		begin
			select -1;
			return -1;
		end

		update Orders
		set UserID = @UserID,
			OrderDate = @OrderDate
		where ID = @ID

		select @@IDENTITY as ID
		return 0;
	end
GO
/****** Object:  StoredProcedure [dbo].[UpdateProduct_SP]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[UpdateProduct_SP]
@CurrentUserID int,
@ID int,
@ProductCode smallint,
@Name nvarchar(50),
@CategoryID int,
@UnitPrice money
as
	begin
		set nocount on;

		declare @HasPermission int
		exec @HasPermission = HasUserPermission_F @CurrentUserID, 19

		if(@HasPermission = 0)
		begin
			raiserror ('No Permission', 16, 1)
		end

		update Products
		set ProductCode = @ProductCode,
			Name = @Name,
			CategoryID = @CategoryID,
			UnitPrice = @UnitPrice
		where ID = @ID

		return 0;
	end
GO
/****** Object:  StoredProcedure [dbo].[UpdateProductDetail_SP]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[UpdateProductDetail_SP]
@CurrentUserID int,
@ID int,
@Quantity int,
@ExpirationDate date
as
	begin
		set nocount on;

		declare @HasPermission int
		exec @HasPermission = HasUserPermission_F @CurrentUserID, 22

		if(@HasPermission = 0)
		begin
			raiserror ('No Permission', 16, 1)
		end
		
		update ProductDetails
		set Quantity = @Quantity, 
		    ExpirationDate = @ExpirationDate
		where ID = @ID

		return 0;
	end
GO
/****** Object:  StoredProcedure [dbo].[UpdateProvider_SP]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[UpdateProvider_SP]
@CurrentUserID int,
@ID int,
@Name nvarchar(30),
@Phone varchar(20),
@Email nvarchar(30)
as
	begin
		set nocount on;

		declare @HasPermission int
		exec @HasPermission = HasUserPermission_F @CurrentUserID, 8

		if(@HasPermission = 0)
		begin
			raiserror ('No Permission', 16, 1)
		end

		update Providers
		set Name = @Name,
			Phone = @Phone,
			Email = @Email
		where ID = @ID

		return 0;
	end
GO
/****** Object:  StoredProcedure [dbo].[UpdatePurchase_SP]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdatePurchase_SP]
@ID int,
@CurrentUserID int,
@ProviderID int,
@UserID int,
@PurchaseDate date,
@RequiredDate date
as
	begin
		set nocount on;

		declare @HasPermission int
		exec @HasPermission = HasUserPermission_F @CurrentUserID, 11

		if(@HasPermission = 0)
		begin
			select -1;
			return -1;
		end

		update Purchases
		set ProviderID = @ProviderID,
			UserID = @UserID,
			PurchaseDate = @PurchaseDate,
			RequiredDate = @RequiredDate
		where ID = @ID

		return 0;
	end
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser_SP]    Script Date: 8/10/2021 7:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[UpdateUser_SP]
@CurrentUserID int,
@ID int,
@Username nvarchar(50), 
@Password char(128)
as
	begin
		set nocount on;

		declare @HasPermission int
		exec @HasPermission = HasUserPermission_F @CurrentUserID, 5

		if(@HasPermission = 0)
		begin
			raiserror ('No Permission', 16, 1)
		end

		update Users
		set Username = @Username
		where ID = @ID

		select 0;
		return 0;
	end

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "PD"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'GetPurchaseDetails'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'GetPurchaseDetails'
GO
USE [master]
GO
ALTER DATABASE [Market] SET  READ_WRITE 
GO
