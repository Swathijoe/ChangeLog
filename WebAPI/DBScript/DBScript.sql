USE [master]
GO
/****** Object:  Database [ChangeLog]    Script Date: 2/21/2021 8:12:45 PM ******/
CREATE DATABASE [ChangeLog]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ChangeLog', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\ChangeLog.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ChangeLog_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\ChangeLog_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ChangeLog] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ChangeLog].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ChangeLog] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ChangeLog] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ChangeLog] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ChangeLog] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ChangeLog] SET ARITHABORT OFF 
GO
ALTER DATABASE [ChangeLog] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ChangeLog] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ChangeLog] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ChangeLog] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ChangeLog] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ChangeLog] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ChangeLog] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ChangeLog] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ChangeLog] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ChangeLog] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ChangeLog] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ChangeLog] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ChangeLog] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ChangeLog] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ChangeLog] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ChangeLog] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ChangeLog] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ChangeLog] SET RECOVERY FULL 
GO
ALTER DATABASE [ChangeLog] SET  MULTI_USER 
GO
ALTER DATABASE [ChangeLog] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ChangeLog] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ChangeLog] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ChangeLog] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ChangeLog] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ChangeLog', N'ON'
GO
USE [ChangeLog]
GO
/****** Object:  Table [dbo].[ChangeLog]    Script Date: 2/21/2021 8:12:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ChangeLog](
	[Id] [uniqueidentifier] NOT NULL,
	[ChangeLogType] [varchar](50) NULL,
	[ChangeLogTime] [datetime] NULL,
	[Content] [nvarchar](max) NULL,
	[UserId] [uniqueidentifier] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 2/21/2021 8:12:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NULL,
	[SocialLoginId] [nvarchar](200) NULL,
	[Email] [nvarchar](100) NULL,
	[SocialLoginToken] [nvarchar](max) NULL,
	[Password] [nvarchar](25) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[ChangeLog]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
USE [master]
GO
ALTER DATABASE [ChangeLog] SET  READ_WRITE 
GO