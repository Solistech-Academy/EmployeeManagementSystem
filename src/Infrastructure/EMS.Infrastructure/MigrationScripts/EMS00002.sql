﻿BEGIN TRANSACTION;
GO

ALTER TABLE [Employee] ADD [IsActive] bit NOT NULL DEFAULT CAST(0 AS bit);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240325104635_EMS00002', N'8.0.3');
GO

COMMIT;
GO

