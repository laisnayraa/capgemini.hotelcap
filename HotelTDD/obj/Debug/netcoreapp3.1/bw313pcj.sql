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

CREATE TABLE [Clients] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(500) NOT NULL,
    [CPF] nvarchar(max) NOT NULL,
    [Hashs] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [TypeRooms] (
    [Id] int NOT NULL IDENTITY,
    [Description] nvarchar(5) NOT NULL,
    [Value] float NOT NULL,
    CONSTRAINT [PK_TypeRooms] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Rooms] (
    [Id] int NOT NULL IDENTITY,
    [BuildingFloor] int NOT NULL,
    [RoomNum] int NOT NULL,
    [Situation] nvarchar(1) NOT NULL,
    [TypeRoomId] int NOT NULL,
    CONSTRAINT [PK_Rooms] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Rooms_TypeRooms_TypeRoomId] FOREIGN KEY ([TypeRoomId]) REFERENCES [TypeRooms] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Occupations] (
    [Id] int NOT NULL IDENTITY,
    [DailyAmount] int NOT NULL,
    [Date] datetime2 NOT NULL,
    [Situation] nvarchar(1) NOT NULL,
    [ClientId] int NOT NULL,
    [RoomId] int NOT NULL,
    CONSTRAINT [PK_Occupations] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Occupations_Clients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [Clients] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Occupations_Rooms_RoomId] FOREIGN KEY ([RoomId]) REFERENCES [Rooms] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Occupations_ClientId] ON [Occupations] ([ClientId]);
GO

CREATE INDEX [IX_Occupations_RoomId] ON [Occupations] ([RoomId]);
GO

CREATE INDEX [IX_Rooms_TypeRoomId] ON [Rooms] ([TypeRoomId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201130185130_initial', N'5.0.0');
GO

COMMIT;
GO

