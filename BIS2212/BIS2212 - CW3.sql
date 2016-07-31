USE [master]
GO

/****** Object:  Database [BIS2212-CW3]    Script Date: 03/27/2013 23:09:10 ******/
CREATE DATABASE [BIS2212-CW3] ON  PRIMARY 
( NAME = N'BIS2212-CW3', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\BIS2212-CW3.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BIS2212-CW3_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\BIS2212-CW3_1.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [BIS2212-CW3] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BIS2212-CW3].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [BIS2212-CW3] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [BIS2212-CW3] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [BIS2212-CW3] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [BIS2212-CW3] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [BIS2212-CW3] SET ARITHABORT OFF 
GO

ALTER DATABASE [BIS2212-CW3] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [BIS2212-CW3] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [BIS2212-CW3] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [BIS2212-CW3] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [BIS2212-CW3] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [BIS2212-CW3] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [BIS2212-CW3] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [BIS2212-CW3] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [BIS2212-CW3] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [BIS2212-CW3] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [BIS2212-CW3] SET  DISABLE_BROKER 
GO

ALTER DATABASE [BIS2212-CW3] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [BIS2212-CW3] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [BIS2212-CW3] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [BIS2212-CW3] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [BIS2212-CW3] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [BIS2212-CW3] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [BIS2212-CW3] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [BIS2212-CW3] SET  READ_WRITE 
GO

ALTER DATABASE [BIS2212-CW3] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [BIS2212-CW3] SET  MULTI_USER 
GO

ALTER DATABASE [BIS2212-CW3] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [BIS2212-CW3] SET DB_CHAINING OFF 
GO
