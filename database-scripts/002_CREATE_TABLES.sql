USE [Atm]
GO

CREATE TABLE [Card] (
  [id] INTEGER IDENTITY(1,1) PRIMARY KEY,
  [number] NVARCHAR(16) NOT NULL UNIQUE,
  [pin] NVARCHAR(4) NOT NULL,
  [userId] INTEGER NOT NULL,
  [dueDate] DATE NOT NULL,
  [balance] DECIMAL(38,5) NOT NULL,
  [isBlocked] BIT NOT NULL DEFAULT 0,
  [failAttempts] INTEGER NOT NULL,
  [active] BIT NOT NULL DEFAULT 0,
  [createdBy] NVARCHAR(100) NOT NULL,
  [createdAt] DATETIME2 NOT NULL,
  [updatedBy] NVARCHAR(100),
  [updatedAt] DATETIME2
)
GO

CREATE TABLE [User] (
  [id] INTEGER IDENTITY(1,1) PRIMARY KEY,
  [name] NVARCHAR(255),
  [surname] NVARCHAR(255),
  [identityNumber] NVARCHAR(10) NOT NULL,
  [active] BIT NOT NULL DEFAULT 0,
  [createdBy] NVARCHAR(100) NOT NULL,
  [createdAt] DATETIME2 NOT NULL,
  [updatedBy] NVARCHAR(100),
  [updatedAt] DATETIME2
)
GO

CREATE TABLE [Operation] (
  [id] INTEGER IDENTITY(1,1) PRIMARY KEY,
  [cardId] INTEGER NOT NULL,
  [amount] DECIMAL(38,5),
  [dateTime] DATETIME2 NOT NULL,
  [operationTypeId] INTEGER NOT NULL
)
GO

CREATE TABLE [OperationType] (
  [id] INTEGER IDENTITY(1,1) PRIMARY KEY,
  [description] NVARCHAR(100) NOT NULL,
  [code] NVARCHAR(20) NOT NULL,
  [active] BIT NOT NULL DEFAULT 0,
  [createdBy] NVARCHAR(100) NOT NULL,
  [createdAt] DATETIME2 NOT NULL,
  [updatedBy] NVARCHAR(100),
  [updatedAt] DATETIME2
)
GO

ALTER TABLE [Card] ADD CONSTRAINT [FK_card_userId] FOREIGN KEY ([userId]) REFERENCES [User] ([id])
GO

ALTER TABLE [Operation] ADD CONSTRAINT [FK_operation_cardId] FOREIGN KEY ([cardId]) REFERENCES [Card] ([id])
GO

ALTER TABLE [Operation] ADD CONSTRAINT [FK_operation_operationTypeId] FOREIGN KEY ([operationTypeId]) REFERENCES [OperationType] ([id])
GO
