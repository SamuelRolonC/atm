USE [Atm]
GO

INSERT INTO [dbo].[user]
           ([name]
           ,[surname]
           ,[identityNumber]
           ,[active]
           ,[createdBy]
           ,[createdAt])
     VALUES
           ('Walter'
           ,'Zamorano'
           ,'1012341234'
           ,1
           ,'SCRIPT'
           ,GETDATE())

DECLARE @userId INT;
SET @userId = SCOPE_IDENTITY()

INSERT INTO [dbo].[card]
           ([number]
           ,[pin]
           ,[userId]
           ,[dueDate]
           ,[balance]
           ,[isBlocked]
           ,[failAttempts]
           ,[active]
           ,[createdBy]
           ,[createdAt])
     VALUES
           ('1234123412345061'
           ,'5061'
           ,@userId
           ,DATEFROMPARTS(2030, 1, 1)
           ,100000
           ,0
           ,0
           ,1
           ,'SCRIPT'
           ,GETDATE())
GO

INSERT INTO [dbo].[user]
           ([name]
           ,[surname]
           ,[identityNumber]
           ,[active]
           ,[createdBy]
           ,[createdAt])
     VALUES
           ('Pablo'
           ,'Ramirez'
           ,'1012340002'
           ,1
           ,'SCRIPT'
           ,GETDATE())

DECLARE @userId INT;
SET @userId = SCOPE_IDENTITY()

INSERT INTO [dbo].[card]
           ([number]
           ,[pin]
           ,[userId]
           ,[dueDate]
           ,[balance]
           ,[isBlocked]
           ,[failAttempts]
           ,[active]
           ,[createdBy]
           ,[createdAt])
     VALUES
           ('1234123412340002'
           ,'0002'
           ,@userId
           ,DATEFROMPARTS(2025, 1, 1)
           ,10000
           ,0
           ,0
           ,1
           ,'SCRIPT'
           ,GETDATE())
GO

INSERT INTO [dbo].[user]
           ([name]
           ,[surname]
           ,[identityNumber]
           ,[active]
           ,[createdBy]
           ,[createdAt])
     VALUES
           ('Lucas'
           ,'Palermo'
           ,'1012341111'
           ,1
           ,'SCRIPT'
           ,GETDATE())

DECLARE @userId INT;
SET @userId = SCOPE_IDENTITY()

INSERT INTO [dbo].[card]
           ([number]
           ,[pin]
           ,[userId]
           ,[dueDate]
           ,[balance]
           ,[isBlocked]
           ,[failAttempts]
           ,[active]
           ,[createdBy]
           ,[createdAt])
     VALUES
           ('1111111111111111'
           ,'1111'
           ,@userId
           ,DATEFROMPARTS(2024, 1, 1)
           ,1000000
           ,0
           ,0
           ,1
           ,'SCRIPT'
           ,GETDATE())
GO