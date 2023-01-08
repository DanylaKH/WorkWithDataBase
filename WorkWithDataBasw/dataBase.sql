USE [master]
GO

CREATE DATABASE [Store]
GO

USE Store 
GO

CREATE TABLE [dbo].[Products] (
    [ProductId]     INT           NOT NULL,
    [ProductName]   NVARCHAR (50) NOT NULL,
    [ProductPrice]  INT           NOT NULL,
    [ProductAmount] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([ProductId] ASC)
);

INSERT INTO Products(ProductId, ProductName, ProductPrice, ProductAmount) VALUES (1, 'Egg', 68, 500)
INSERT INTO Products(ProductId, ProductName, ProductPrice, ProductAmount) VALUES (2, 'Tea', 43, 750)
INSERT INTO Products(ProductId, ProductName, ProductPrice, ProductAmount) VALUES (3, 'Tomato', 5, 1000)
INSERT INTO Products(ProductId, ProductName, ProductPrice, ProductAmount) VALUES (4, 'Chiken meat', 110, 150)
INSERT INTO Products(ProductId, ProductName, ProductPrice, ProductAmount) VALUES (5, 'Pork meat', 140, 150)
INSERT INTO Products(ProductId, ProductName, ProductPrice, ProductAmount) VALUES (6, 'Beef meat', 180, 150)

CREATE TABLE [dbo].[Suppliers] (
    [Id]               INT           NOT NULL,
    [SuppliersName]    NVARCHAR (50) NULL,
    [SuppliersProduct] INT NULL,
    [SuppliersAmount]  INT           NULL,
    [SuppliersID]      INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([SuppliersProduct]) REFERENCES [dbo].[Products] ([ProductId])
);

INSERT INTO Suppliers(Id, SuppliersName, SuppliersProduct, SuppliersAmount, SuppliersID) VALUES (1, 'Kiev Farm', 1, 300, 1)
INSERT INTO Suppliers(Id, SuppliersName, SuppliersProduct, SuppliersAmount, SuppliersID) VALUES (2, 'Princess Noori', 2, 500, 2)
INSERT INTO Suppliers(Id, SuppliersName, SuppliersProduct, SuppliersAmount, SuppliersID) VALUES (3, 'Kherson Tomato', 3, 500, 3)
INSERT INTO Suppliers(Id, SuppliersName, SuppliersProduct, SuppliersAmount, SuppliersID) VALUES (4, 'Lviv Meat', 4, 100, 4)
INSERT INTO Suppliers(Id, SuppliersName, SuppliersProduct, SuppliersAmount, SuppliersID) VALUES (5, 'Lviv Meat', 5, 100, 4)
INSERT INTO Suppliers(Id, SuppliersName, SuppliersProduct, SuppliersAmount, SuppliersID) VALUES (6, 'Lviv Meat', 6, 100, 4)

CREATE TABLE [dbo].[Orders] (
    [Id]           INT        IDENTITY (1, 1) NOT NULL,
    [OrderProduct] INT        NOT NULL,
    [OrderName]    NCHAR (30) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([OrderProduct]) REFERENCES [dbo].[Products] ([ProductId])
);


