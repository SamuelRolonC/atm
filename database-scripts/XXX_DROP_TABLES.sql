USE [Atm]
GO

ALTER TABLE [card] DROP CONSTRAINT [FK_card_userId]
ALTER TABLE [operation] DROP CONSTRAINT [FK_operation_cardId]
ALTER TABLE [operation] DROP CONSTRAINT [FK_operation_operationTypeId]

DROP TABLE [card]
DROP TABLE [operation]
DROP TABLE [operationType]
DROP TABLE [user]

GO