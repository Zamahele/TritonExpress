IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Branches] (
    [BranchId] int NOT NULL IDENTITY,
    [BranchName] nvarchar(max) NULL,
    CONSTRAINT [PK_Branches] PRIMARY KEY ([BranchId])
);
GO

CREATE TABLE [Locations] (
    [LocationId] int NOT NULL IDENTITY,
    [Address] nvarchar(max) NULL,
    [ZipCode] int NOT NULL,
    [BrancheId] int NOT NULL,
    CONSTRAINT [PK_Locations] PRIMARY KEY ([LocationId])
);
GO

CREATE TABLE [Vehicles] (
    [VehicleId] int NOT NULL IDENTITY,
    [Model] nvarchar(max) NULL,
    [Make] nvarchar(max) NULL,
    [Year] int NOT NULL,
    [RegistrationNo] nvarchar(max) NULL,
    CONSTRAINT [PK_Vehicles] PRIMARY KEY ([VehicleId])
);
GO

CREATE TABLE [WayBills] (
    [WayBillId] int NOT NULL IDENTITY,
    [WaybillNo] nvarchar(max) NULL,
    [WaybillDate] datetime2 NOT NULL,
    [Status] nvarchar(max) NULL,
    [ETADate] datetime2 NOT NULL,
    [ETATime] datetime2 NOT NULL,
    [Quantity] int NOT NULL,
    [Weight] int NOT NULL,
    CONSTRAINT [PK_WayBills] PRIMARY KEY ([WayBillId])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221116102331_TritonExpressData', N'5.0.4');
GO

COMMIT;
GO

