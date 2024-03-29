USE [master]
GO
/****** Object:  Database [parmod]    Script Date: 11/11/2019 8:44:34 AM ******/
CREATE DATABASE [parmod]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'parmod', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\parmod.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'parmod_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\parmod_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [parmod] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [parmod].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [parmod] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [parmod] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [parmod] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [parmod] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [parmod] SET ARITHABORT OFF 
GO
ALTER DATABASE [parmod] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [parmod] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [parmod] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [parmod] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [parmod] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [parmod] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [parmod] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [parmod] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [parmod] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [parmod] SET  DISABLE_BROKER 
GO
ALTER DATABASE [parmod] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [parmod] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [parmod] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [parmod] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [parmod] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [parmod] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [parmod] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [parmod] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [parmod] SET  MULTI_USER 
GO
ALTER DATABASE [parmod] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [parmod] SET DB_CHAINING OFF 
GO
ALTER DATABASE [parmod] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [parmod] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [parmod] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [parmod] SET QUERY_STORE = OFF
GO
USE [parmod]
GO
/****** Object:  Table [dbo].[admin]    Script Date: 11/11/2019 8:44:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[admin](
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[student]    Script Date: 11/11/2019 8:44:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[student](
	[Id] [int] NOT NULL,
	[stu_name] [varchar](40) NULL,
	[stu_batch] [varchar](30) NULL,
	[stu_stream] [varchar](40) NULL,
	[stu_email] [varchar](30) NULL,
	[stu_mno] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[student_register]    Script Date: 11/11/2019 8:44:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[student_register](
	[username] [varchar](40) NOT NULL,
	[password] [varchar](40) NULL,
PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[admin] ([username], [password]) VALUES (N'admin', N'admin')
INSERT [dbo].[student] ([Id], [stu_name], [stu_batch], [stu_stream], [stu_email], [stu_mno]) VALUES (1, N'parmod', N'2018', N'IT', N'parmod@gmail.com', N'67878787878')
INSERT [dbo].[student] ([Id], [stu_name], [stu_batch], [stu_stream], [stu_email], [stu_mno]) VALUES (2, N'gurpreet', N'2018', N'IT', N'gurpreet@gmail.com', N'89878787878')
INSERT [dbo].[student_register] ([username], [password]) VALUES (N'gurpreet', N'123')
INSERT [dbo].[student_register] ([username], [password]) VALUES (N'parmod', N'123')
ALTER TABLE [dbo].[student]  WITH CHECK ADD FOREIGN KEY([stu_name])
REFERENCES [dbo].[student_register] ([username])
GO
USE [master]
GO
ALTER DATABASE [parmod] SET  READ_WRITE 
GO
