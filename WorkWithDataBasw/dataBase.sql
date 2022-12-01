USE master
GO

IF NOT EXISTS (
   SELECT name
   FROM sys.databases
   WHERE name = N'Store'
)
CREATE DATABASE [Store]
GO

USE [Store]
IF OBJECT_ID('dbo.Products', 'U') IS NOT NULL
DROP TABLE dbo.Products
GO

CREATE TABLE dbo.Products
(
   ProductId        INT    NOT NULL   PRIMARY KEY, 
   ProductName      [NVARCHAR](50)  NOT NULL,
   ProductPrice		INT NOT NULL,
   ProductAmount	INT  NOT NULL
);
GO

INSERT INTO dbo.Products
   ([ProductId],[ProductName],[ProductPrice],[ProductAmount])
VALUES
   ( 1, N'Egg', 68, 500),
   ( 2, N'Tea', 43, 750),
   ( 3, N'Tomato', 5, 1000),
   ( 4, N'Meat', 110, 150)
GO