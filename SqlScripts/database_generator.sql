USE [Importer]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Errors]') AND type in (N'U'))
ALTER TABLE [dbo].[Errors] DROP CONSTRAINT IF EXISTS [FK_Errors_DownloadedFiles]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 27/05/2021 11:16:53 p. m. ******/
DROP TABLE IF EXISTS [dbo].[Stock]
GO
/****** Object:  Table [dbo].[Errors]    Script Date: 27/05/2021 11:16:53 p. m. ******/
DROP TABLE IF EXISTS [dbo].[Errors]
GO
/****** Object:  Table [dbo].[DownloadedFiles]    Script Date: 27/05/2021 11:16:53 p. m. ******/
DROP TABLE IF EXISTS [dbo].[DownloadedFiles]
GO
/****** Object:  Table [dbo].[DownloadedFiles]    Script Date: 27/05/2021 11:16:53 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DownloadedFiles](
	[FileId] [int] IDENTITY(1,1) NOT NULL,
	[DownloadDate] [datetime] NOT NULL,
	[FileName] [varchar](100) NOT NULL,
	[CorrectRows] [int] NOT NULL,
	[IncorrectRows] [int] NOT NULL,
 CONSTRAINT [PK_DownloadedFiles] PRIMARY KEY CLUSTERED 
(
	[FileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Errors]    Script Date: 27/05/2021 11:16:53 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Errors](
	[ErrorId] [int] IDENTITY(1,1) NOT NULL,
	[FileId] [int] NOT NULL,
	[Data] [varchar](200) NOT NULL,
	[ImportDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Errors] PRIMARY KEY CLUSTERED 
(
	[ErrorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 27/05/2021 11:16:53 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[StockId] [int] IDENTITY(1,1) NOT NULL,
	[PointOfSale] [varchar](50) NOT NULL,
	[Product] [varchar](50) NOT NULL,
	[Date] [varchar](50) NOT NULL,
	[Stock] [int] NOT NULL,
 CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED 
(
	[StockId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Errors]  WITH CHECK ADD  CONSTRAINT [FK_Errors_DownloadedFiles] FOREIGN KEY([FileId])
REFERENCES [dbo].[DownloadedFiles] ([FileId])
GO
ALTER TABLE [dbo].[Errors] CHECK CONSTRAINT [FK_Errors_DownloadedFiles]
GO
