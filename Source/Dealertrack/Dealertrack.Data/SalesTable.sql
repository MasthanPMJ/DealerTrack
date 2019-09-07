CREATE TABLE [dbo].[SalesTable]
(
    [DealNumber] INT NOT NULL, 
    [CustomerName] VARCHAR(150) NULL, 
    [DealershipName] VARCHAR(150) NULL, 
    [Vehicle] VARCHAR(100) NULL, 
    [Price] MONEY NULL, 
    [SoldDate] DATETIME NULL, 
    PRIMARY KEY ([DealNumber])
)
