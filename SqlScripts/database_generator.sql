CREATE DATABASE [Importer]
GO
USE [Importer]
GO
/****** Object:  Table [dbo].[DownloadedFiles]    Script Date: 30/05/2021 08:04:37 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DownloadedFiles](
	[FileId] [int] IDENTITY(1,1) NOT NULL,
	[DownloadDate] [datetime] NOT NULL,
	[FileName] [varchar](100) NOT NULL,
	[InsertedRows] [int] NOT NULL,
 CONSTRAINT [PK_DownloadedFiles] PRIMARY KEY CLUSTERED 
(
	[FileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 30/05/2021 08:04:37 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[StockId] [int] IDENTITY(1,1) NOT NULL,
	[PointOfSale] [varchar](50) NULL,
	[Product] [varchar](50) NULL,
	[Date] [varchar](50) NULL,
	[Stock] [int] NULL,
 CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED 
(
	[StockId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
