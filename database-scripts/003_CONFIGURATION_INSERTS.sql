USE [Atm]
GO

INSERT INTO operationType (description, code, active, createdBy, createdAt)
VALUES ('Retiro', 'RETIRO', 1, 'SCRIPT', GETDATE()),
       ('Balance', 'BALANCE', 1, 'SCRIPT', GETDATE())
GO