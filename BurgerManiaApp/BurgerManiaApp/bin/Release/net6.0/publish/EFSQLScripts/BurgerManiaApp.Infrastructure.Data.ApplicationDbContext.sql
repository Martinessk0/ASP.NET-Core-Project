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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(128) NOT NULL,
        [ProviderKey] nvarchar(128) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(128) NOT NULL,
        [Name] nvarchar(128) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'00000000000000_CreateIdentitySchema', N'6.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221107100843_UserInitialize')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [FirstName] nvarchar(25) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221107100843_UserInitialize')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [LastName] nvarchar(25) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221107100843_UserInitialize')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221107100843_UserInitialize', N'6.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221113132552_AddedAddressFieldToUserTable')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [Address] nvarchar(60) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221113132552_AddedAddressFieldToUserTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221113132552_AddedAddressFieldToUserTable', N'6.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127124017_ProductIsActive')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221127124017_ProductIsActive', N'6.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127124033_TableAddedToDb')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'LastName');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [AspNetUsers] ALTER COLUMN [LastName] nvarchar(60) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127124033_TableAddedToDb')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'FirstName');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [AspNetUsers] ALTER COLUMN [FirstName] nvarchar(60) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127124033_TableAddedToDb')
BEGIN
    CREATE TABLE [Categories] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(50) NOT NULL,
        CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127124033_TableAddedToDb')
BEGIN
    CREATE TABLE [OrderStatuses] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_OrderStatuses] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127124033_TableAddedToDb')
BEGIN
    CREATE TABLE [Products] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(50) NOT NULL,
        [Description] nvarchar(500) NOT NULL,
        [ImageUrl] nvarchar(200) NOT NULL,
        [Price] money NOT NULL,
        [CategoryId] int NOT NULL,
        CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127124033_TableAddedToDb')
BEGIN
    CREATE TABLE [Orders] (
        [Id] int NOT NULL IDENTITY,
        [OrderStatusId] int NOT NULL,
        CONSTRAINT [PK_Orders] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Orders_OrderStatuses_OrderStatusId] FOREIGN KEY ([OrderStatusId]) REFERENCES [OrderStatuses] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127124033_TableAddedToDb')
BEGIN
    CREATE TABLE [CartItems] (
        [Id] int NOT NULL IDENTITY,
        [ProductId] int NOT NULL,
        [Quantity] int NOT NULL,
        [Price] decimal(18,2) NOT NULL,
        CONSTRAINT [PK_CartItems] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_CartItems_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127124033_TableAddedToDb')
BEGIN
    CREATE TABLE [UserOrder] (
        [UserId] nvarchar(450) NOT NULL,
        [OrderId] int NOT NULL,
        CONSTRAINT [PK_UserOrder] PRIMARY KEY ([UserId], [OrderId]),
        CONSTRAINT [FK_UserOrder_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_UserOrder_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127124033_TableAddedToDb')
BEGIN
    CREATE TABLE [ShoppingCarts] (
        [Id] int NOT NULL IDENTITY,
        [CartItemId] int NOT NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_ShoppingCarts] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ShoppingCarts_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_ShoppingCarts_CartItems_CartItemId] FOREIGN KEY ([CartItemId]) REFERENCES [CartItems] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127124033_TableAddedToDb')
BEGIN
    CREATE INDEX [IX_CartItems_ProductId] ON [CartItems] ([ProductId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127124033_TableAddedToDb')
BEGIN
    CREATE INDEX [IX_Orders_OrderStatusId] ON [Orders] ([OrderStatusId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127124033_TableAddedToDb')
BEGIN
    CREATE INDEX [IX_Products_CategoryId] ON [Products] ([CategoryId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127124033_TableAddedToDb')
BEGIN
    CREATE INDEX [IX_ShoppingCarts_CartItemId] ON [ShoppingCarts] ([CartItemId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127124033_TableAddedToDb')
BEGIN
    CREATE INDEX [IX_ShoppingCarts_UserId] ON [ShoppingCarts] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127124033_TableAddedToDb')
BEGIN
    CREATE INDEX [IX_UserOrder_OrderId] ON [UserOrder] ([OrderId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127124033_TableAddedToDb')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221127124033_TableAddedToDb', N'6.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127124349_ProductTableWithThreeNewFields')
BEGIN
    ALTER TABLE [Products] ADD [CreatedAt] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127124349_ProductTableWithThreeNewFields')
BEGIN
    ALTER TABLE [Products] ADD [IsActive] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127124349_ProductTableWithThreeNewFields')
BEGIN
    ALTER TABLE [Products] ADD [ModifiedAt] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127124349_ProductTableWithThreeNewFields')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221127124349_ProductTableWithThreeNewFields', N'6.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127154125_UserCategoryOrderStatusSeeded')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[OrderStatuses]') AND [c].[name] = N'Description');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [OrderStatuses] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [OrderStatuses] DROP COLUMN [Description];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127154125_UserCategoryOrderStatusSeeded')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'Address', N'ConcurrencyStamp', N'Email', N'EmailConfirmed', N'FirstName', N'LastName', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
        SET IDENTITY_INSERT [AspNetUsers] ON;
    EXEC(N'INSERT INTO [AspNetUsers] ([Id], [AccessFailedCount], [Address], [ConcurrencyStamp], [Email], [EmailConfirmed], [FirstName], [LastName], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName])
    VALUES (N''06552aa5-bcbe-49ef-ac65-fd84699d0d3e'', 0, N''Guest Street 3'', N''48942768-2647-4194-8080-5f1a42f2a011'', N''guest@gmail.com'', CAST(0 AS bit), N''Guest'', N''Guestov'', CAST(0 AS bit), NULL, N''guest@gmail.com'', N''guest'', N''AQAAAAEAACcQAAAAEPBnc5UbFO7sH05wjnbeenEWqHc2p7APwQ8Wb/cc0a7ktuOkH05sCdthNqqkiWi1MQ=='', NULL, CAST(0 AS bit), N''1c3b45a1-c6ae-442f-8abf-f4b2cc7c9973'', CAST(0 AS bit), N''Guest''),
    (N''fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f'', 0, N''Admin Street 6'', N''36710fac-7d8d-4c70-9f9e-0b3c20556dc0'', N''admin@gmail.com'', CAST(0 AS bit), N''Admin'', N''Adminov'', CAST(0 AS bit), NULL, N''admin@gmail.com'', N''admin'', N''AQAAAAEAACcQAAAAEMIgGfced5BnZb8WxHA8lAfih4+mbk7EEq/hKp3BKRFQOn4nTThna0KhoANtnZCXAQ=='', NULL, CAST(0 AS bit), N''5dff8cba-85b3-4f4a-a932-47f5bf3e61ac'', CAST(0 AS bit), N''Admin'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'Address', N'ConcurrencyStamp', N'Email', N'EmailConfirmed', N'FirstName', N'LastName', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
        SET IDENTITY_INSERT [AspNetUsers] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127154125_UserCategoryOrderStatusSeeded')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Categories]'))
        SET IDENTITY_INSERT [Categories] ON;
    EXEC(N'INSERT INTO [Categories] ([Id], [Name])
    VALUES (1, N''Burger''),
    (2, N''Drink''),
    (3, N''Fries''),
    (4, N''Salad'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Categories]'))
        SET IDENTITY_INSERT [Categories] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127154125_UserCategoryOrderStatusSeeded')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[OrderStatuses]'))
        SET IDENTITY_INSERT [OrderStatuses] ON;
    EXEC(N'INSERT INTO [OrderStatuses] ([Id], [Name])
    VALUES (1, N''Pending''),
    (2, N''In Progress''),
    (3, N''Completed''),
    (4, N''Canceled'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[OrderStatuses]'))
        SET IDENTITY_INSERT [OrderStatuses] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127154125_UserCategoryOrderStatusSeeded')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221127154125_UserCategoryOrderStatusSeeded', N'6.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127162419_ProductSeed')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''dcc4a3e7-1814-4528-b58f-545d7da42c3f'', [NormalizedEmail] = N''GUEST@GMAIL.COM'', [NormalizedUserName] = N''GUEST'', [PasswordHash] = N''AQAAAAEAACcQAAAAEEytNs6p8B8vPaGuhYinqAD/hQVjY/qiVkq1daol0dfYtsRrNnYxrzPTQgFsr0KgEQ=='', [SecurityStamp] = N''ac93785f-0c10-4b6e-90d5-247832427abf''
    WHERE [Id] = N''06552aa5-bcbe-49ef-ac65-fd84699d0d3e'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127162419_ProductSeed')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''ace8aa4a-dcb0-427f-b6c1-b63282a53658'', [NormalizedEmail] = N''ADMIN@GMAIL.COM'', [NormalizedUserName] = N''ADMIN'', [PasswordHash] = N''AQAAAAEAACcQAAAAEMGSDSxKARfEFtCWXugIsoWRlrbPrVFjZD4Fxl5Dm7JtSg0WDPIlaJ/z5J+AgsMpjg=='', [SecurityStamp] = N''e78cdafe-e721-4bd1-8808-9dace38eab11''
    WHERE [Id] = N''fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127162419_ProductSeed')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221127162419_ProductSeed', N'6.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127162722_SeededProducts')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''82bdd7a0-c83e-4de0-82a4-cdf714975e0b'', [PasswordHash] = N''AQAAAAEAACcQAAAAEA6jyBR4IdsON32ujHIR09jyJIur2i0k40r5sdBoT8sCTbwY2hsebpTy34J4/zFv2Q=='', [SecurityStamp] = N''086c115d-b24f-44a1-9b37-d25d43f92ada''
    WHERE [Id] = N''06552aa5-bcbe-49ef-ac65-fd84699d0d3e'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127162722_SeededProducts')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''1724f7ed-8bd8-4908-a8e0-7c240b65cc97'', [PasswordHash] = N''AQAAAAEAACcQAAAAEMz49qo/AsQ5iNdbIYnd9j5E3wSAO2WqzPKmFwQNzAdR/8UI5lm/1R/Z9+guqpeVSw=='', [SecurityStamp] = N''c715d2b9-fc62-41a2-9cfa-ce762e92d2e6''
    WHERE [Id] = N''fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127162722_SeededProducts')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CategoryId', N'CreatedAt', N'Description', N'ImageUrl', N'IsActive', N'ModifiedAt', N'Name', N'Price') AND [object_id] = OBJECT_ID(N'[Products]'))
        SET IDENTITY_INSERT [Products] ON;
    EXEC(N'INSERT INTO [Products] ([Id], [CategoryId], [CreatedAt], [Description], [ImageUrl], [IsActive], [ModifiedAt], [Name], [Price])
    VALUES (1, 1, ''2022-11-27T18:27:22.1840099+02:00'', N''Spicy Burger'', N''https://wickedkitchen.com/wp-content/uploads/2022/05/Wicked-jalapeno-burger.jpeg'', CAST(1 AS bit), ''2022-11-27T18:27:22.1840135+02:00'', N''Spicy Burger'', 7.0),
    (2, 2, ''2022-11-27T18:27:22.1840144+02:00'', N''Coca-Cola'', N''https://cdncloudcart.com/16372/products/images/68308/coca-cola-bezalkoholna-napitka-ken-250-ml-image_629659e5b307d_1920x1920.jpeg?1654020601'', CAST(1 AS bit), ''2022-11-27T18:27:22.1840145+02:00'', N''Coca-Cola'', 1.0),
    (3, 4, ''2022-11-27T18:27:22.1840150+02:00'', N''Salad with Iceberg lettuce'', N''https://eatsomethingvegan.com/wp-content/uploads/2021/11/Iceberg-Lettuce-Salad-5-681x1024.jpg'', CAST(1 AS bit), ''2022-11-27T18:27:22.1840151+02:00'', N''Salad with Iceberg lettuce'', 7.0)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CategoryId', N'CreatedAt', N'Description', N'ImageUrl', N'IsActive', N'ModifiedAt', N'Name', N'Price') AND [object_id] = OBJECT_ID(N'[Products]'))
        SET IDENTITY_INSERT [Products] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127162722_SeededProducts')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221127162722_SeededProducts', N'6.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221206204716_ShoppingCartTableUpdate')
BEGIN
    ALTER TABLE [ShoppingCarts] DROP CONSTRAINT [FK_ShoppingCarts_CartItems_CartItemId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221206204716_ShoppingCartTableUpdate')
BEGIN
    DROP INDEX [IX_ShoppingCarts_CartItemId] ON [ShoppingCarts];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221206204716_ShoppingCartTableUpdate')
BEGIN
    ALTER TABLE [CartItems] ADD [CartItemId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221206204716_ShoppingCartTableUpdate')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''312fd6b1-a08a-402e-a8ba-2f7bd25b9a8b'', [PasswordHash] = N''AQAAAAEAACcQAAAAECj5x5HPUwdbkeOCmD7BZ//smJ0fbfMZSTw4WF80+6KztBjgoyrkoFOpiczDCzC9rQ=='', [SecurityStamp] = N''03aa015c-1afc-41cf-a566-f1e97bfa083e''
    WHERE [Id] = N''06552aa5-bcbe-49ef-ac65-fd84699d0d3e'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221206204716_ShoppingCartTableUpdate')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''c688cd44-2834-4759-b17b-b52111464745'', [PasswordHash] = N''AQAAAAEAACcQAAAAEBXfj5MNvUro64zVdE2r7Ofj4qaZWVaJqUFb5D4Iz05wVWjk+sYPPdvA6ZB7SeSGpg=='', [SecurityStamp] = N''cbfd5508-28b0-4ac0-87d6-961ae14ddce1''
    WHERE [Id] = N''fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221206204716_ShoppingCartTableUpdate')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'Address', N'ConcurrencyStamp', N'Email', N'EmailConfirmed', N'FirstName', N'LastName', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
        SET IDENTITY_INSERT [AspNetUsers] ON;
    EXEC(N'INSERT INTO [AspNetUsers] ([Id], [AccessFailedCount], [Address], [ConcurrencyStamp], [Email], [EmailConfirmed], [FirstName], [LastName], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName])
    VALUES (N''f9bf120c-fafd-48d1-a4c6-330f99ad8a67'', 0, N''DELIVERER Street 5'', N''ca324cfd-013f-4419-b128-5c154040845a'', N''deliverer@gmail.com'', CAST(0 AS bit), N''Deliverer'', N''Delivrov'', CAST(0 AS bit), NULL, N''DELIVERER@GMAIL.COM'', N''DELIVERER'', N''AQAAAAEAACcQAAAAECjCdG2+OkkW+uKSWuynGgIN96cFbcAQe3JgSWVXBxo8tVgG7bzI3UIRnVtGpQOgDg=='', NULL, CAST(0 AS bit), N''378b7a9d-0391-4f45-9eac-3cca0200fced'', CAST(0 AS bit), N''Deliverer'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'Address', N'ConcurrencyStamp', N'Email', N'EmailConfirmed', N'FirstName', N'LastName', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
        SET IDENTITY_INSERT [AspNetUsers] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221206204716_ShoppingCartTableUpdate')
BEGIN
    EXEC(N'UPDATE [Products] SET [CreatedAt] = ''2022-12-06T22:47:16.0113822+02:00'', [ModifiedAt] = ''2022-12-06T22:47:16.0113967+02:00''
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221206204716_ShoppingCartTableUpdate')
BEGIN
    EXEC(N'UPDATE [Products] SET [CreatedAt] = ''2022-12-06T22:47:16.0113992+02:00'', [ModifiedAt] = ''2022-12-06T22:47:16.0113998+02:00''
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221206204716_ShoppingCartTableUpdate')
BEGIN
    EXEC(N'UPDATE [Products] SET [CreatedAt] = ''2022-12-06T22:47:16.0114005+02:00'', [ModifiedAt] = ''2022-12-06T22:47:16.0114007+02:00''
    WHERE [Id] = 3;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221206204716_ShoppingCartTableUpdate')
BEGIN
    CREATE INDEX [IX_CartItems_CartItemId] ON [CartItems] ([CartItemId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221206204716_ShoppingCartTableUpdate')
BEGIN
    ALTER TABLE [CartItems] ADD CONSTRAINT [FK_CartItems_ShoppingCarts_CartItemId] FOREIGN KEY ([CartItemId]) REFERENCES [ShoppingCarts] ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221206204716_ShoppingCartTableUpdate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221206204716_ShoppingCartTableUpdate', N'6.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221206214948_IsActiveCartItemField')
BEGIN
    ALTER TABLE [CartItems] ADD [IsActive] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221206214948_IsActiveCartItemField')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''9c523617-3af1-48f7-bf90-9c6eef348018'', [PasswordHash] = N''AQAAAAEAACcQAAAAEN479ZxRT+uvl1NeskcdIweN7oaJ9YGw1N6eQAtO8zdqJxwm3o/vepP091TELEMK2A=='', [SecurityStamp] = N''2974970b-5e0d-4919-8122-e33e6dde9747''
    WHERE [Id] = N''06552aa5-bcbe-49ef-ac65-fd84699d0d3e'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221206214948_IsActiveCartItemField')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''a8de561e-2673-4d4e-b199-ae26feba8feb'', [PasswordHash] = N''AQAAAAEAACcQAAAAEHjCS+VHPeCFN1qeVWxkufguK6CdTfh9SwZ8hPjJnUUgGnnGWt10vzuzBi7a6dCBCg=='', [SecurityStamp] = N''bce530a7-eb30-4640-84c8-af50163d45c4''
    WHERE [Id] = N''f9bf120c-fafd-48d1-a4c6-330f99ad8a67'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221206214948_IsActiveCartItemField')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''0d51cc36-d5fe-4d65-9d7c-9b596b65614d'', [PasswordHash] = N''AQAAAAEAACcQAAAAEGKSGOn/B7eu1ToxbTEkGVAzKP/N2AFuVnUKSNhk/nHsZ05gz4yYcfx1UGDWOnTk+A=='', [SecurityStamp] = N''51164585-8d54-4e16-b95c-311257842c5b''
    WHERE [Id] = N''fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221206214948_IsActiveCartItemField')
BEGIN
    EXEC(N'UPDATE [Products] SET [CreatedAt] = ''2022-12-06T23:49:48.5273256+02:00'', [ModifiedAt] = ''2022-12-06T23:49:48.5273295+02:00''
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221206214948_IsActiveCartItemField')
BEGIN
    EXEC(N'UPDATE [Products] SET [CreatedAt] = ''2022-12-06T23:49:48.5273303+02:00'', [ModifiedAt] = ''2022-12-06T23:49:48.5273305+02:00''
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221206214948_IsActiveCartItemField')
BEGIN
    EXEC(N'UPDATE [Products] SET [CreatedAt] = ''2022-12-06T23:49:48.5273308+02:00'', [ModifiedAt] = ''2022-12-06T23:49:48.5273310+02:00''
    WHERE [Id] = 3;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221206214948_IsActiveCartItemField')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221206214948_IsActiveCartItemField', N'6.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091229_shoppingCartChanched')
BEGIN
    ALTER TABLE [CartItems] DROP CONSTRAINT [FK_CartItems_Products_ProductId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091229_shoppingCartChanched')
BEGIN
    ALTER TABLE [CartItems] DROP CONSTRAINT [FK_CartItems_ShoppingCarts_CartItemId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091229_shoppingCartChanched')
BEGIN
    ALTER TABLE [ShoppingCarts] DROP CONSTRAINT [FK_ShoppingCarts_AspNetUsers_UserId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091229_shoppingCartChanched')
BEGIN
    DROP INDEX [IX_ShoppingCarts_UserId] ON [ShoppingCarts];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091229_shoppingCartChanched')
BEGIN
    DROP INDEX [IX_CartItems_ProductId] ON [CartItems];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091229_shoppingCartChanched')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ShoppingCarts]') AND [c].[name] = N'CartItemId');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [ShoppingCarts] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [ShoppingCarts] DROP COLUMN [CartItemId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091229_shoppingCartChanched')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ShoppingCarts]') AND [c].[name] = N'UserId');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [ShoppingCarts] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [ShoppingCarts] DROP COLUMN [UserId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091229_shoppingCartChanched')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CartItems]') AND [c].[name] = N'IsActive');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [CartItems] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [CartItems] DROP COLUMN [IsActive];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091229_shoppingCartChanched')
BEGIN
    EXEC sp_rename N'[CartItems].[CartItemId]', N'OrderId', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091229_shoppingCartChanched')
BEGIN
    EXEC sp_rename N'[CartItems].[IX_CartItems_CartItemId]', N'IX_CartItems_OrderId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091229_shoppingCartChanched')
BEGIN
    ALTER TABLE [ShoppingCarts] ADD [BuyerId] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091229_shoppingCartChanched')
BEGIN
    ALTER TABLE [ShoppingCarts] ADD [DateOfCreation] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091229_shoppingCartChanched')
BEGIN
    ALTER TABLE [Orders] ADD [BuyerId] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091229_shoppingCartChanched')
BEGIN
    ALTER TABLE [Orders] ADD [DeliveryAddressId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091229_shoppingCartChanched')
BEGIN
    ALTER TABLE [Orders] ADD [Email] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091229_shoppingCartChanched')
BEGIN
    ALTER TABLE [Orders] ADD [FullName] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091229_shoppingCartChanched')
BEGIN
    ALTER TABLE [Orders] ADD [OrderDate] datetimeoffset NOT NULL DEFAULT '0001-01-01T00:00:00.0000000+00:00';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091229_shoppingCartChanched')
BEGIN
    ALTER TABLE [Orders] ADD [OrderNumber] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091229_shoppingCartChanched')
BEGIN
    ALTER TABLE [Orders] ADD [PhoneNumber] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091229_shoppingCartChanched')
BEGIN
    ALTER TABLE [CartItems] ADD [BasketId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091229_shoppingCartChanched')
BEGIN
    ALTER TABLE [CartItems] ADD [PictureUrl] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091229_shoppingCartChanched')
BEGIN
    ALTER TABLE [CartItems] ADD [ProductBrand] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091229_shoppingCartChanched')
BEGIN
    ALTER TABLE [CartItems] ADD [ProductName] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091229_shoppingCartChanched')
BEGIN
    ALTER TABLE [CartItems] ADD [ShoppingCartId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091229_shoppingCartChanched')
BEGIN
    CREATE TABLE [DeliveryAddress] (
        [Id] int NOT NULL IDENTITY,
        [StreetAddress] nvarchar(max) NOT NULL,
        [ZipCode] nvarchar(max) NOT NULL,
        [City] nvarchar(max) NOT NULL,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_DeliveryAddress] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091229_shoppingCartChanched')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''59a04e60-d296-48b0-8a94-f92eed3eac9b'', [PasswordHash] = N''AQAAAAEAACcQAAAAEDp9+QF4MuggRmq8smtbeWX4Z4rpmUTnIO7Ng4rqqS4r89H1kxdG++cVE5NZcRjuNA=='', [SecurityStamp] = N''1cb2971c-2dbb-4f5d-8f6d-37f294ada9d7''
    WHERE [Id] = N''06552aa5-bcbe-49ef-ac65-fd84699d0d3e'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091229_shoppingCartChanched')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''a32ba02d-8c58-4a17-8399-08a0f47e78fb'', [PasswordHash] = N''AQAAAAEAACcQAAAAELXdwjp7zlflg2WInGeXqnDnbcal6wFYKNBnVQI7Z3axTfJp3l4yo6RjJIdZ7MDq9w=='', [SecurityStamp] = N''9c808743-dfa0-40c6-b95f-07c802b5e57a''
    WHERE [Id] = N''f9bf120c-fafd-48d1-a4c6-330f99ad8a67'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091229_shoppingCartChanched')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''e52f5265-d9c1-4903-81c6-8fdf545b1557'', [PasswordHash] = N''AQAAAAEAACcQAAAAEBibzqjVuiQJigNihmCM1pUJXb2AwRfJIxu/H1w82QpXJhbc/aaO+cBMseDgnC6D1w=='', [SecurityStamp] = N''1cfbf056-ebb5-4afc-bf8b-b993d3a0440d''
    WHERE [Id] = N''fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091229_shoppingCartChanched')
BEGIN
    EXEC(N'UPDATE [Products] SET [CreatedAt] = ''2022-12-07T11:12:29.4037350+02:00'', [ModifiedAt] = ''2022-12-07T11:12:29.4037393+02:00''
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091229_shoppingCartChanched')
BEGIN
    EXEC(N'UPDATE [Products] SET [CreatedAt] = ''2022-12-07T11:12:29.4037403+02:00'', [ModifiedAt] = ''2022-12-07T11:12:29.4037405+02:00''
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091229_shoppingCartChanched')
BEGIN
    EXEC(N'UPDATE [Products] SET [CreatedAt] = ''2022-12-07T11:12:29.4037408+02:00'', [ModifiedAt] = ''2022-12-07T11:12:29.4037410+02:00''
    WHERE [Id] = 3;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091229_shoppingCartChanched')
BEGIN
    CREATE INDEX [IX_Orders_DeliveryAddressId] ON [Orders] ([DeliveryAddressId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091229_shoppingCartChanched')
BEGIN
    CREATE INDEX [IX_CartItems_ShoppingCartId] ON [CartItems] ([ShoppingCartId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091229_shoppingCartChanched')
BEGIN
    ALTER TABLE [CartItems] ADD CONSTRAINT [FK_CartItems_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091229_shoppingCartChanched')
BEGIN
    ALTER TABLE [CartItems] ADD CONSTRAINT [FK_CartItems_ShoppingCarts_ShoppingCartId] FOREIGN KEY ([ShoppingCartId]) REFERENCES [ShoppingCarts] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091229_shoppingCartChanched')
BEGIN
    ALTER TABLE [Orders] ADD CONSTRAINT [FK_Orders_DeliveryAddress_DeliveryAddressId] FOREIGN KEY ([DeliveryAddressId]) REFERENCES [DeliveryAddress] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091229_shoppingCartChanched')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221207091229_shoppingCartChanched', N'6.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091820_DbRelSetUp')
BEGIN
    ALTER TABLE [CartItems] DROP CONSTRAINT [FK_CartItems_ShoppingCarts_ShoppingCartId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091820_DbRelSetUp')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CartItems]') AND [c].[name] = N'BasketId');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [CartItems] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [CartItems] DROP COLUMN [BasketId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091820_DbRelSetUp')
BEGIN
    EXEC sp_rename N'[CartItems].[ShoppingCartId]', N'CartId', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091820_DbRelSetUp')
BEGIN
    EXEC sp_rename N'[CartItems].[PictureUrl]', N'ImageUrl', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091820_DbRelSetUp')
BEGIN
    EXEC sp_rename N'[CartItems].[IX_CartItems_ShoppingCartId]', N'IX_CartItems_CartId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091820_DbRelSetUp')
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ShoppingCarts]') AND [c].[name] = N'BuyerId');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [ShoppingCarts] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [ShoppingCarts] ALTER COLUMN [BuyerId] nvarchar(450) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091820_DbRelSetUp')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''e4ebbd62-075e-49ee-b5ed-5e994bf74811'', [PasswordHash] = N''AQAAAAEAACcQAAAAEMi9QOuON92T0v+TTi6alYFrf3dfVBIWk3EoUT5FBazn8otymRlc8OGLARlM7DbWwQ=='', [SecurityStamp] = N''fe401208-91b9-43a2-97c3-71680c3b04a7''
    WHERE [Id] = N''06552aa5-bcbe-49ef-ac65-fd84699d0d3e'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091820_DbRelSetUp')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''a60e8130-453b-40d1-92a5-2e5fbf5cbf38'', [PasswordHash] = N''AQAAAAEAACcQAAAAELgESIY+2RyxST8R4b+Y5/DmawiP1ePV+hTcOJogjGGJxD5g3io7lZHEbi/siWdYLQ=='', [SecurityStamp] = N''1aa7e2db-f1b1-4034-b469-c4b7a355b49e''
    WHERE [Id] = N''f9bf120c-fafd-48d1-a4c6-330f99ad8a67'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091820_DbRelSetUp')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''afbedd99-529c-4f7f-95ee-ef516521c3fc'', [PasswordHash] = N''AQAAAAEAACcQAAAAEKTa77Fs6XQq3UYQFpnz5jMCguNmwTkus9xhDHvO3uhgXc/zlWrISuWHkAXDcZ7xVg=='', [SecurityStamp] = N''a3962bad-191d-4f40-87a4-f811896b90b9''
    WHERE [Id] = N''fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091820_DbRelSetUp')
BEGIN
    EXEC(N'UPDATE [Products] SET [CreatedAt] = ''2022-12-07T11:18:20.4216477+02:00'', [ModifiedAt] = ''2022-12-07T11:18:20.4216521+02:00''
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091820_DbRelSetUp')
BEGIN
    EXEC(N'UPDATE [Products] SET [CreatedAt] = ''2022-12-07T11:18:20.4216529+02:00'', [ModifiedAt] = ''2022-12-07T11:18:20.4216531+02:00''
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091820_DbRelSetUp')
BEGIN
    EXEC(N'UPDATE [Products] SET [CreatedAt] = ''2022-12-07T11:18:20.4216534+02:00'', [ModifiedAt] = ''2022-12-07T11:18:20.4216536+02:00''
    WHERE [Id] = 3;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091820_DbRelSetUp')
BEGIN
    CREATE INDEX [IX_ShoppingCarts_BuyerId] ON [ShoppingCarts] ([BuyerId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091820_DbRelSetUp')
BEGIN
    CREATE INDEX [IX_CartItems_ProductId] ON [CartItems] ([ProductId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091820_DbRelSetUp')
BEGIN
    ALTER TABLE [CartItems] ADD CONSTRAINT [FK_CartItems_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091820_DbRelSetUp')
BEGIN
    ALTER TABLE [CartItems] ADD CONSTRAINT [FK_CartItems_ShoppingCarts_CartId] FOREIGN KEY ([CartId]) REFERENCES [ShoppingCarts] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091820_DbRelSetUp')
BEGIN
    ALTER TABLE [ShoppingCarts] ADD CONSTRAINT [FK_ShoppingCarts_AspNetUsers_BuyerId] FOREIGN KEY ([BuyerId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207091820_DbRelSetUp')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221207091820_DbRelSetUp', N'6.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207092100_DeliveryAdressTableWasAdded')
BEGIN
    ALTER TABLE [Orders] DROP CONSTRAINT [FK_Orders_DeliveryAddress_DeliveryAddressId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207092100_DeliveryAdressTableWasAdded')
BEGIN
    ALTER TABLE [DeliveryAddress] DROP CONSTRAINT [PK_DeliveryAddress];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207092100_DeliveryAdressTableWasAdded')
BEGIN
    EXEC sp_rename N'[DeliveryAddress]', N'DeliveryAddresses';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207092100_DeliveryAdressTableWasAdded')
BEGIN
    ALTER TABLE [DeliveryAddresses] ADD CONSTRAINT [PK_DeliveryAddresses] PRIMARY KEY ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207092100_DeliveryAdressTableWasAdded')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''56c72520-8efb-4271-b289-a30910cd7695'', [PasswordHash] = N''AQAAAAEAACcQAAAAEJPKrIa6nKnQvuiL6wlrt2typxzgDpm826s9/EBpdPqqr8LhRI/pR3SPpcp9EnofNw=='', [SecurityStamp] = N''301a8088-33d2-4cce-b5bf-5033227344ae''
    WHERE [Id] = N''06552aa5-bcbe-49ef-ac65-fd84699d0d3e'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207092100_DeliveryAdressTableWasAdded')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''174f28bb-abc0-4ab0-865e-3da7eb464752'', [PasswordHash] = N''AQAAAAEAACcQAAAAEEqifx/xdj56nwDej2/ZTsPwGwWw7+bHpWLILrSIwF48q+oGJ9iYEZgEOZB7dOxCiQ=='', [SecurityStamp] = N''09e2eec4-91c9-4a85-9cdc-dd3b433147b6''
    WHERE [Id] = N''f9bf120c-fafd-48d1-a4c6-330f99ad8a67'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207092100_DeliveryAdressTableWasAdded')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''71c3785f-4390-4dd8-b542-aeb073d35914'', [PasswordHash] = N''AQAAAAEAACcQAAAAEC5qVIlB9mhapZ/AaCMTDz8haB61v04zcizuqmNFVYhS5w7bMdkoR5ebM46EW4U/eQ=='', [SecurityStamp] = N''4de79cdb-c6d9-4385-ae5b-26b11179114b''
    WHERE [Id] = N''fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207092100_DeliveryAdressTableWasAdded')
BEGIN
    EXEC(N'UPDATE [Products] SET [CreatedAt] = ''2022-12-07T11:20:59.8418405+02:00'', [ModifiedAt] = ''2022-12-07T11:20:59.8418442+02:00''
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207092100_DeliveryAdressTableWasAdded')
BEGIN
    EXEC(N'UPDATE [Products] SET [CreatedAt] = ''2022-12-07T11:20:59.8418449+02:00'', [ModifiedAt] = ''2022-12-07T11:20:59.8418451+02:00''
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207092100_DeliveryAdressTableWasAdded')
BEGIN
    EXEC(N'UPDATE [Products] SET [CreatedAt] = ''2022-12-07T11:20:59.8418454+02:00'', [ModifiedAt] = ''2022-12-07T11:20:59.8418456+02:00''
    WHERE [Id] = 3;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207092100_DeliveryAdressTableWasAdded')
BEGIN
    ALTER TABLE [Orders] ADD CONSTRAINT [FK_Orders_DeliveryAddresses_DeliveryAddressId] FOREIGN KEY ([DeliveryAddressId]) REFERENCES [DeliveryAddresses] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207092100_DeliveryAdressTableWasAdded')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221207092100_DeliveryAdressTableWasAdded', N'6.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207095437_ProductBrandRemoved')
BEGIN
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CartItems]') AND [c].[name] = N'ProductBrand');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [CartItems] DROP CONSTRAINT [' + @var8 + '];');
    ALTER TABLE [CartItems] DROP COLUMN [ProductBrand];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207095437_ProductBrandRemoved')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''1ec2b39e-4a46-4a09-913a-140faefaaa5f'', [PasswordHash] = N''AQAAAAEAACcQAAAAEBhXn2aqCOM1cs17P9cUALk7s7AGKhx7T/JSb+JNqrOMchQ9viPJqaAwOhaiWkmq+g=='', [SecurityStamp] = N''9f31ba86-74c3-4579-8dac-f075f1085bad''
    WHERE [Id] = N''06552aa5-bcbe-49ef-ac65-fd84699d0d3e'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207095437_ProductBrandRemoved')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''58dee496-beee-4cab-b228-93df2988c3d8'', [PasswordHash] = N''AQAAAAEAACcQAAAAEIMYuh6ObWQ92nsOBBhENVsc1NV2hYHeYJAF9Ixku1dhYT218PI9ADR5E1UCTQwr0A=='', [SecurityStamp] = N''0f40e620-2e13-4705-a384-5ca73efae228''
    WHERE [Id] = N''f9bf120c-fafd-48d1-a4c6-330f99ad8a67'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207095437_ProductBrandRemoved')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''26de151e-74c3-43ed-9628-a7587363faef'', [PasswordHash] = N''AQAAAAEAACcQAAAAEEEafEPCnRL4SN3KLnqkXGzh0nFkVnHpidBxVmY8neuTR3+ZL/nN9TE86D2s0mz7qw=='', [SecurityStamp] = N''f0a016cc-2df1-4995-9f74-200efdd218de''
    WHERE [Id] = N''fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207095437_ProductBrandRemoved')
BEGIN
    EXEC(N'UPDATE [Products] SET [CreatedAt] = ''2022-12-07T11:54:36.7435002+02:00'', [ModifiedAt] = ''2022-12-07T11:54:36.7435036+02:00''
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207095437_ProductBrandRemoved')
BEGIN
    EXEC(N'UPDATE [Products] SET [CreatedAt] = ''2022-12-07T11:54:36.7435047+02:00'', [ModifiedAt] = ''2022-12-07T11:54:36.7435049+02:00''
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207095437_ProductBrandRemoved')
BEGIN
    EXEC(N'UPDATE [Products] SET [CreatedAt] = ''2022-12-07T11:54:36.7435054+02:00'', [ModifiedAt] = ''2022-12-07T11:54:36.7435056+02:00''
    WHERE [Id] = 3;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207095437_ProductBrandRemoved')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221207095437_ProductBrandRemoved', N'6.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221208183539_IsActiveAddedOnShoppingCart')
BEGIN
    ALTER TABLE [ShoppingCarts] ADD [IsActive] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221208183539_IsActiveAddedOnShoppingCart')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''cc259eb5-de03-4f89-b1cd-8e959d3b715a'', [PasswordHash] = N''AQAAAAEAACcQAAAAECbSN0L652D05UHczM+bS3jlIKrCvJE0ZFhA2TZg0hrKoEMqe/9t8l0NRhpuN+DASQ=='', [SecurityStamp] = N''ad0422ff-33c8-4b4a-88c7-43d86794e23b''
    WHERE [Id] = N''06552aa5-bcbe-49ef-ac65-fd84699d0d3e'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221208183539_IsActiveAddedOnShoppingCart')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''294c5634-f401-4705-bf0d-acd79f0f32ed'', [PasswordHash] = N''AQAAAAEAACcQAAAAEHU1NAstdtoB+Zmyn7V76S6aGwBY9ZtrReaI6HOdtOjtxyXGV2eQm4hURawkcmaAKw=='', [SecurityStamp] = N''3b55a8e7-8d32-414a-8beb-dfd9aff812bf''
    WHERE [Id] = N''f9bf120c-fafd-48d1-a4c6-330f99ad8a67'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221208183539_IsActiveAddedOnShoppingCart')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''f07464ea-aef6-4e75-be54-053721f4e4a5'', [PasswordHash] = N''AQAAAAEAACcQAAAAEAoDmlgZXY/kNgW5vlR8YimnRfeLHDMnKSg/KhBx6bRcbZbvkNyCufOBUkcn9b7BiQ=='', [SecurityStamp] = N''45966acd-048a-4585-9f4f-24dbb23253b3''
    WHERE [Id] = N''fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221208183539_IsActiveAddedOnShoppingCart')
BEGIN
    EXEC(N'UPDATE [Products] SET [CreatedAt] = ''2022-12-08T20:35:39.0380209+02:00'', [ModifiedAt] = ''2022-12-08T20:35:39.0380246+02:00''
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221208183539_IsActiveAddedOnShoppingCart')
BEGIN
    EXEC(N'UPDATE [Products] SET [CreatedAt] = ''2022-12-08T20:35:39.0380256+02:00'', [ModifiedAt] = ''2022-12-08T20:35:39.0380257+02:00''
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221208183539_IsActiveAddedOnShoppingCart')
BEGIN
    EXEC(N'UPDATE [Products] SET [CreatedAt] = ''2022-12-08T20:35:39.0380260+02:00'', [ModifiedAt] = ''2022-12-08T20:35:39.0380262+02:00''
    WHERE [Id] = 3;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221208183539_IsActiveAddedOnShoppingCart')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221208183539_IsActiveAddedOnShoppingCart', N'6.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221211142949_ConstantsAdded')
BEGIN
    DECLARE @var9 sysname;
    SELECT @var9 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Products]') AND [c].[name] = N'ImageUrl');
    IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [Products] DROP CONSTRAINT [' + @var9 + '];');
    ALTER TABLE [Products] ALTER COLUMN [ImageUrl] nvarchar(300) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221211142949_ConstantsAdded')
BEGIN
    DECLARE @var10 sysname;
    SELECT @var10 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[OrderStatuses]') AND [c].[name] = N'Name');
    IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [OrderStatuses] DROP CONSTRAINT [' + @var10 + '];');
    ALTER TABLE [OrderStatuses] ALTER COLUMN [Name] nvarchar(20) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221211142949_ConstantsAdded')
BEGIN
    DECLARE @var11 sysname;
    SELECT @var11 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Orders]') AND [c].[name] = N'PhoneNumber');
    IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [Orders] DROP CONSTRAINT [' + @var11 + '];');
    ALTER TABLE [Orders] ALTER COLUMN [PhoneNumber] nvarchar(15) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221211142949_ConstantsAdded')
BEGIN
    DECLARE @var12 sysname;
    SELECT @var12 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Orders]') AND [c].[name] = N'FullName');
    IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [Orders] DROP CONSTRAINT [' + @var12 + '];');
    ALTER TABLE [Orders] ALTER COLUMN [FullName] nvarchar(60) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221211142949_ConstantsAdded')
BEGIN
    DECLARE @var13 sysname;
    SELECT @var13 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DeliveryAddresses]') AND [c].[name] = N'ZipCode');
    IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [DeliveryAddresses] DROP CONSTRAINT [' + @var13 + '];');
    ALTER TABLE [DeliveryAddresses] ALTER COLUMN [ZipCode] nvarchar(5) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221211142949_ConstantsAdded')
BEGIN
    DECLARE @var14 sysname;
    SELECT @var14 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DeliveryAddresses]') AND [c].[name] = N'StreetAddress');
    IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [DeliveryAddresses] DROP CONSTRAINT [' + @var14 + '];');
    ALTER TABLE [DeliveryAddresses] ALTER COLUMN [StreetAddress] nvarchar(100) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221211142949_ConstantsAdded')
BEGIN
    DECLARE @var15 sysname;
    SELECT @var15 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DeliveryAddresses]') AND [c].[name] = N'Name');
    IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [DeliveryAddresses] DROP CONSTRAINT [' + @var15 + '];');
    ALTER TABLE [DeliveryAddresses] ALTER COLUMN [Name] nvarchar(30) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221211142949_ConstantsAdded')
BEGIN
    DECLARE @var16 sysname;
    SELECT @var16 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DeliveryAddresses]') AND [c].[name] = N'City');
    IF @var16 IS NOT NULL EXEC(N'ALTER TABLE [DeliveryAddresses] DROP CONSTRAINT [' + @var16 + '];');
    ALTER TABLE [DeliveryAddresses] ALTER COLUMN [City] nvarchar(20) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221211142949_ConstantsAdded')
BEGIN
    DECLARE @var17 sysname;
    SELECT @var17 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Categories]') AND [c].[name] = N'Name');
    IF @var17 IS NOT NULL EXEC(N'ALTER TABLE [Categories] DROP CONSTRAINT [' + @var17 + '];');
    ALTER TABLE [Categories] ALTER COLUMN [Name] nvarchar(60) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221211142949_ConstantsAdded')
BEGIN
    DECLARE @var18 sysname;
    SELECT @var18 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CartItems]') AND [c].[name] = N'ProductName');
    IF @var18 IS NOT NULL EXEC(N'ALTER TABLE [CartItems] DROP CONSTRAINT [' + @var18 + '];');
    ALTER TABLE [CartItems] ALTER COLUMN [ProductName] nvarchar(50) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221211142949_ConstantsAdded')
BEGIN
    DECLARE @var19 sysname;
    SELECT @var19 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CartItems]') AND [c].[name] = N'Price');
    IF @var19 IS NOT NULL EXEC(N'ALTER TABLE [CartItems] DROP CONSTRAINT [' + @var19 + '];');
    ALTER TABLE [CartItems] ALTER COLUMN [Price] money NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221211142949_ConstantsAdded')
BEGIN
    DECLARE @var20 sysname;
    SELECT @var20 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CartItems]') AND [c].[name] = N'ImageUrl');
    IF @var20 IS NOT NULL EXEC(N'ALTER TABLE [CartItems] DROP CONSTRAINT [' + @var20 + '];');
    ALTER TABLE [CartItems] ALTER COLUMN [ImageUrl] nvarchar(300) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221211142949_ConstantsAdded')
BEGIN
    DECLARE @var21 sysname;
    SELECT @var21 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'LastName');
    IF @var21 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var21 + '];');
    ALTER TABLE [AspNetUsers] ALTER COLUMN [LastName] nvarchar(25) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221211142949_ConstantsAdded')
BEGIN
    DECLARE @var22 sysname;
    SELECT @var22 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'FirstName');
    IF @var22 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var22 + '];');
    ALTER TABLE [AspNetUsers] ALTER COLUMN [FirstName] nvarchar(25) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221211142949_ConstantsAdded')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''15e36561-653a-4e7e-8c2c-4d06440345d8'', [PasswordHash] = N''AQAAAAEAACcQAAAAEMr7Z7yvrwz4yORiWmNBwMe64w7MG+N60O+ehqSOw/fbXJOVzZfa1/ITiMipfZXWKQ=='', [SecurityStamp] = N''eb1e59ba-dd72-4c6a-b126-94bcbda7da2e''
    WHERE [Id] = N''06552aa5-bcbe-49ef-ac65-fd84699d0d3e'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221211142949_ConstantsAdded')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''ee4ee95e-eb47-4dc2-887b-d4521eacfd7d'', [PasswordHash] = N''AQAAAAEAACcQAAAAENXcDOb6L8Ik5WsV3zwzGNgVwl0MGS+Ewr980U/WYtqFTDJojXXnaCnCjPYb2vfaew=='', [SecurityStamp] = N''aa49327c-27d9-4010-a0a6-4b719dcd1d88''
    WHERE [Id] = N''f9bf120c-fafd-48d1-a4c6-330f99ad8a67'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221211142949_ConstantsAdded')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''b61d0a30-cad0-4133-8b3e-f5a831330c4c'', [PasswordHash] = N''AQAAAAEAACcQAAAAEDfRS3wLDfQGMxLGnV83lyerFxzlTTfjl0tTHTNV8+Mm04bTPSNQ26zNy9yOZU0jZQ=='', [SecurityStamp] = N''7018a548-f5ab-403c-8120-bfdbdf9950a5''
    WHERE [Id] = N''fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221211142949_ConstantsAdded')
BEGIN
    EXEC(N'UPDATE [Products] SET [CreatedAt] = ''2022-12-11T16:29:48.9593387+02:00'', [ModifiedAt] = ''2022-12-11T16:29:48.9593426+02:00''
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221211142949_ConstantsAdded')
BEGIN
    EXEC(N'UPDATE [Products] SET [CreatedAt] = ''2022-12-11T16:29:48.9593435+02:00'', [ModifiedAt] = ''2022-12-11T16:29:48.9593437+02:00''
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221211142949_ConstantsAdded')
BEGIN
    EXEC(N'UPDATE [Products] SET [CreatedAt] = ''2022-12-11T16:29:48.9593440+02:00'', [ModifiedAt] = ''2022-12-11T16:29:48.9593442+02:00''
    WHERE [Id] = 3;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221211142949_ConstantsAdded')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221211142949_ConstantsAdded', N'6.0.10');
END;
GO

COMMIT;
GO

