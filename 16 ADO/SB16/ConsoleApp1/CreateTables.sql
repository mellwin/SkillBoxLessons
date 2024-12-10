CREATE TABLE [dbo].[Products]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Email] NVARCHAR(50) NULL, 
    [ProductCode] INT NULL, 
    [ProductName] NVARCHAR(50) NULL
);

CREATE TABLE [dbo].[Custumers] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [LastName]    NVARCHAR (50)    NULL,
    [Name]        NVARCHAR (50)    NULL,
    [SecondName]  NVARCHAR (50)    NULL,
    [PhoneNumber] NVARCHAR (50)    NULL,
    [Email]       NVARCHAR (50)    NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);