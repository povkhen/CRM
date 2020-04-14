CREATE TABLE [dbo].[Department]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(50) NOT NULL, 
    [HeadId] INT NULL, 
    [Phone] NVARCHAR(50) NULL, 

    -- цей запрос виконати після створення таблиці User
    -- ALTER TABLE  [dbo].[Department]
    -- ADD FOREIGN KEY ([HeadId]) REFERENCES [User]([Id])
)

