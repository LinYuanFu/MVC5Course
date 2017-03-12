CREATE TABLE [dbo].[Product] (
    [ProductId]   INT             IDENTITY (1, 1) NOT NULL,
    [ProductName] VARCHAR (80)    NULL,
    [Price]       SMALLMONEY      NULL,
    [Active]      BIT             NULL,
    [Stock]       NUMERIC (18, 3) NULL,
    [IsDeleted] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [pk_ProductId] PRIMARY KEY CLUSTERED ([ProductId] ASC)
);

