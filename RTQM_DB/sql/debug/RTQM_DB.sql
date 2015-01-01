/*
Deployment script for RTQM_DB
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "RTQM_DB"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\"

GO
:on error exit
GO
USE [master]
GO
IF (DB_ID(N'$(DatabaseName)') IS NOT NULL
    AND DATABASEPROPERTYEX(N'$(DatabaseName)','Status') <> N'ONLINE')
BEGIN
    RAISERROR(N'The state of the target database, %s, is not set to ONLINE. To deploy to this database, its state must be set to ONLINE.', 16, 127,N'$(DatabaseName)') WITH NOWAIT
    RETURN
END

GO
IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Creating $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [RTQM_DB], FILENAME = N'$(DefaultDataPath)RTQM_DB.mdf')
    LOG ON (NAME = [RTQM_DB_log], FILENAME = N'$(DefaultLogPath)RTQM_DB_log.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
EXECUTE sp_dbcmptlevel [$(DatabaseName)], 100;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
USE [$(DatabaseName)]
GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

GO
PRINT N'Creating [dbo].[lg_DefectDesInfos]...';


GO
CREATE TABLE [dbo].[lg_DefectDesInfos] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [DefectDes] NVARCHAR (50) NOT NULL
);


GO
PRINT N'Creating PK_DefectDesInfos...';


GO
ALTER TABLE [dbo].[lg_DefectDesInfos]
    ADD CONSTRAINT [PK_DefectDesInfos] PRIMARY KEY CLUSTERED ([Id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[lg_DisqualificationReports]...';


GO
CREATE TABLE [dbo].[lg_DisqualificationReports] (
    [Id]                    UNIQUEIDENTIFIER NOT NULL,
    [CreateDate]            DATETIME         NOT NULL,
    [OrderId]               UNIQUEIDENTIFIER NOT NULL,
    [OrderLineId]           UNIQUEIDENTIFIER NOT NULL,
    [OrderDate]             DATETIME         NOT NULL,
    [OrderNo]               NVARCHAR (50)    NOT NULL,
    [MaterialNo]            NVARCHAR (50)    NOT NULL,
    [SupplierName]          NVARCHAR (50)    NOT NULL,
    [Total]                 INT              NOT NULL,
    [DefectCount]           INT              NOT NULL,
    [QtyCount]              INT              NOT NULL,
    [DefectFindIn]          NVARCHAR (500)   NOT NULL,
    [DefectDescription]     NVARCHAR (500)   NOT NULL,
    [DisposalOption]        INT              NOT NULL,
    [DisposalView]          NVARCHAR (500)   NOT NULL,
    [DisposalAdvanceOption] INT              NOT NULL,
    [UseDepartmentView]     NVARCHAR (500)   NOT NULL,
    [Decision]              NVARCHAR (500)   NOT NULL
);


GO
PRINT N'Creating PK_DisqualificationReports_Id...';


GO
ALTER TABLE [dbo].[lg_DisqualificationReports]
    ADD CONSTRAINT [PK_DisqualificationReports_Id] PRIMARY KEY CLUSTERED ([Id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[lg_DisqualificationReports].[IX_DisqualificationReports_CreateDate]...';


GO
CREATE NONCLUSTERED INDEX [IX_DisqualificationReports_CreateDate]
    ON [dbo].[lg_DisqualificationReports]([CreateDate] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF, ONLINE = OFF, MAXDOP = 0);


GO
PRINT N'Creating [dbo].[lg_DisqualificationReports].[IX_DisqualificationReports_MaterialNo]...';


GO
CREATE NONCLUSTERED INDEX [IX_DisqualificationReports_MaterialNo]
    ON [dbo].[lg_DisqualificationReports]([MaterialNo] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF, ONLINE = OFF, MAXDOP = 0);


GO
PRINT N'Creating [dbo].[lg_DisqualificationReports].[IX_DisqualificationReports_OrderDate]...';


GO
CREATE NONCLUSTERED INDEX [IX_DisqualificationReports_OrderDate]
    ON [dbo].[lg_DisqualificationReports]([OrderDate] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF, ONLINE = OFF, MAXDOP = 0);


GO
PRINT N'Creating [dbo].[lg_DisqualificationReports].[IX_DisqualificationReports_OrderNo]...';


GO
CREATE NONCLUSTERED INDEX [IX_DisqualificationReports_OrderNo]
    ON [dbo].[lg_DisqualificationReports]([OrderNo] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF, ONLINE = OFF, MAXDOP = 0);


GO
PRINT N'Creating [dbo].[lg_DisqualificationReports].[IX_DisqualificationReports_SupplierName]...';


GO
CREATE NONCLUSTERED INDEX [IX_DisqualificationReports_SupplierName]
    ON [dbo].[lg_DisqualificationReports]([SupplierName] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF, ONLINE = OFF, MAXDOP = 0);


GO
PRINT N'Creating [dbo].[lg_Files]...';


GO
CREATE TABLE [dbo].[lg_Files] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [FileName]        NVARCHAR (50)    NOT NULL,
    [FileExtName]     NVARCHAR (10)    NOT NULL,
    [StorageFileName] NVARCHAR (30)    NOT NULL,
    [FileSize]        BIGINT           NOT NULL,
    [IsTempFile]      BIT              NOT NULL,
    [CreateDate]      DATETIME         NOT NULL
);


GO
PRINT N'Creating PK_Files_Id...';


GO
ALTER TABLE [dbo].[lg_Files]
    ADD CONSTRAINT [PK_Files_Id] PRIMARY KEY CLUSTERED ([Id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating UK_Files_StorageFileName...';


GO
ALTER TABLE [dbo].[lg_Files]
    ADD CONSTRAINT [UK_Files_StorageFileName] UNIQUE NONCLUSTERED ([StorageFileName] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[lg_MaterialInfos]...';


GO
CREATE TABLE [dbo].[lg_MaterialInfos] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [MaterialNo]  NVARCHAR (50)    NOT NULL,
    [MaterialDes] NVARCHAR (100)   NOT NULL,
    [IsDeleted]   BIT              NOT NULL
);


GO
PRINT N'Creating PK_MaterialInfos...';


GO
ALTER TABLE [dbo].[lg_MaterialInfos]
    ADD CONSTRAINT [PK_MaterialInfos] PRIMARY KEY CLUSTERED ([Id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating UK_MaterialInfos_MaterialNo...';


GO
ALTER TABLE [dbo].[lg_MaterialInfos]
    ADD CONSTRAINT [UK_MaterialInfos_MaterialNo] UNIQUE NONCLUSTERED ([MaterialNo] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[lg_PurchaseOrderItems]...';


GO
CREATE TABLE [dbo].[lg_PurchaseOrderItems] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [POId]            UNIQUEIDENTIFIER NOT NULL,
    [BatchNo]         NVARCHAR (50)    NOT NULL,
    [MaterialId]      UNIQUEIDENTIFIER NOT NULL,
    [SupplierId]      UNIQUEIDENTIFIER NOT NULL,
    [MaterialType]    INT              NOT NULL,
    [Total]           INT              NOT NULL,
    [DefectDes]       NVARCHAR (50)    NULL,
    [ConcessionCount] INT              NOT NULL,
    [ReworkCount]     INT              NOT NULL,
    [RejectionCount]  INT              NOT NULL,
    [ScrapCount]      INT              NOT NULL,
    [QtyTotal]        INT              NOT NULL,
    [Conformance]     FLOAT            NOT NULL
);


GO
PRINT N'Creating UK_PurchaseOrderItems_BatchNo...';


GO
ALTER TABLE [dbo].[lg_PurchaseOrderItems]
    ADD CONSTRAINT [UK_PurchaseOrderItems_BatchNo] UNIQUE CLUSTERED ([BatchNo] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating PK_PurchaseOrderItems...';


GO
ALTER TABLE [dbo].[lg_PurchaseOrderItems]
    ADD CONSTRAINT [PK_PurchaseOrderItems] PRIMARY KEY NONCLUSTERED ([Id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[lg_PurchaseOrderItems].[IX_PurchaseOrderItems_Conformance]...';


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrderItems_Conformance]
    ON [dbo].[lg_PurchaseOrderItems]([Conformance] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF, ONLINE = OFF, MAXDOP = 0);


GO
PRINT N'Creating [dbo].[lg_PurchaseOrders]...';


GO
CREATE TABLE [dbo].[lg_PurchaseOrders] (
    [Id]        UNIQUEIDENTIFIER NOT NULL,
    [PONo]      NVARCHAR (50)    NOT NULL,
    [PODate]    DATETIME         NOT NULL,
    [ItemCount] INT              NOT NULL
);


GO
PRINT N'Creating UK_PurchaseOrders_PONo...';


GO
ALTER TABLE [dbo].[lg_PurchaseOrders]
    ADD CONSTRAINT [UK_PurchaseOrders_PONo] UNIQUE CLUSTERED ([PONo] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating PK_PurchaseOrders...';


GO
ALTER TABLE [dbo].[lg_PurchaseOrders]
    ADD CONSTRAINT [PK_PurchaseOrders] PRIMARY KEY NONCLUSTERED ([Id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[lg_PurchaseOrders].[IX_PurchaseOrders_PODate]...';


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrders_PODate]
    ON [dbo].[lg_PurchaseOrders]([PODate] ASC, [PONo] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF, ONLINE = OFF, MAXDOP = 0);


GO
PRINT N'Creating [dbo].[lg_Roles]...';


GO
CREATE TABLE [dbo].[lg_Roles] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [RoleName]    VARCHAR (20)     NOT NULL,
    [Description] NVARCHAR (100)   NOT NULL
);


GO
PRINT N'Creating PK_Roles...';


GO
ALTER TABLE [dbo].[lg_Roles]
    ADD CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED ([Id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating UK_Roles_RoleName...';


GO
ALTER TABLE [dbo].[lg_Roles]
    ADD CONSTRAINT [UK_Roles_RoleName] UNIQUE NONCLUSTERED ([RoleName] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[lg_SupplierInfos]...';


GO
CREATE TABLE [dbo].[lg_SupplierInfos] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [SupplierName] NVARCHAR (50)    NOT NULL,
    [IsDelete]     BIT              NOT NULL
);


GO
PRINT N'Creating PK_SupplierInfos...';


GO
ALTER TABLE [dbo].[lg_SupplierInfos]
    ADD CONSTRAINT [PK_SupplierInfos] PRIMARY KEY CLUSTERED ([Id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating UK_SupplierInfos_SupplierName...';


GO
ALTER TABLE [dbo].[lg_SupplierInfos]
    ADD CONSTRAINT [UK_SupplierInfos_SupplierName] UNIQUE NONCLUSTERED ([SupplierName] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[lg_UserRoles]...';


GO
CREATE TABLE [dbo].[lg_UserRoles] (
    [UserId] UNIQUEIDENTIFIER NOT NULL,
    [RoleId] UNIQUEIDENTIFIER NOT NULL
);


GO
PRINT N'Creating PK_UserRoles...';


GO
ALTER TABLE [dbo].[lg_UserRoles]
    ADD CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[lg_Users]...';


GO
CREATE TABLE [dbo].[lg_Users] (
    [Id]                UNIQUEIDENTIFIER NOT NULL,
    [UserName]          NVARCHAR (20)    NOT NULL,
    [Password]          VARCHAR (50)     NOT NULL,
    [RelationADAccount] NVARCHAR (50)    NOT NULL,
    [RealName]          NVARCHAR (20)    NOT NULL,
    [Department]        NVARCHAR (20)    NOT NULL,
    [Email]             VARCHAR (50)     NOT NULL,
    [CreateDate]        DATETIME         NOT NULL
);


GO
PRINT N'Creating PK_Users...';


GO
ALTER TABLE [dbo].[lg_Users]
    ADD CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating UK_Users_UserName...';


GO
ALTER TABLE [dbo].[lg_Users]
    ADD CONSTRAINT [UK_Users_UserName] UNIQUE NONCLUSTERED ([UserName] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating FK_DisqualificationReports_OrderLineId...';


GO
ALTER TABLE [dbo].[lg_DisqualificationReports] WITH NOCHECK
    ADD CONSTRAINT [FK_DisqualificationReports_OrderLineId] FOREIGN KEY ([OrderLineId]) REFERENCES [dbo].[lg_PurchaseOrderItems] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_PurchaseOrderItems_MaterialId_MaterialInfos...';


GO
ALTER TABLE [dbo].[lg_PurchaseOrderItems] WITH NOCHECK
    ADD CONSTRAINT [FK_PurchaseOrderItems_MaterialId_MaterialInfos] FOREIGN KEY ([MaterialId]) REFERENCES [dbo].[lg_MaterialInfos] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_PurchaseOrderItems_POId_PurchaseOrders...';


GO
ALTER TABLE [dbo].[lg_PurchaseOrderItems] WITH NOCHECK
    ADD CONSTRAINT [FK_PurchaseOrderItems_POId_PurchaseOrders] FOREIGN KEY ([POId]) REFERENCES [dbo].[lg_PurchaseOrders] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_PurchaseOrderItems_SupplierId_SupplierInfos...';


GO
ALTER TABLE [dbo].[lg_PurchaseOrderItems] WITH NOCHECK
    ADD CONSTRAINT [FK_PurchaseOrderItems_SupplierId_SupplierInfos] FOREIGN KEY ([SupplierId]) REFERENCES [dbo].[lg_SupplierInfos] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_UserRoles_RoleId...';


GO
ALTER TABLE [dbo].[lg_UserRoles] WITH NOCHECK
    ADD CONSTRAINT [FK_UserRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[lg_Roles] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_UserRoles_UserId...';


GO
ALTER TABLE [dbo].[lg_UserRoles] WITH NOCHECK
    ADD CONSTRAINT [FK_UserRoles_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[lg_Users] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
-- Refactoring step to update target server with deployed transaction logs
CREATE TABLE  [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
GO
sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
GO

GO
/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

-- 创建默认管理员用户
insert into [dbo].[lg_Users] values('11111111-aaaa-aaaa-aaaa-000000000001', 'admin', 'ISMvKXpXpadDiUoOSoAfww==', '', '', '', '', GETDATE())

-- 创建系统角色
insert into [dbo].[lg_Roles] values('11111111-aaaa-aaaa-aaaa-100000000001', 'Admin', N'系统管理员')
insert into [dbo].[lg_Roles] values('11111111-aaaa-aaaa-aaaa-100000000002', 'QualityManager', N'质量部门经理')
insert into [dbo].[lg_Roles] values('11111111-aaaa-aaaa-aaaa-100000000003', 'QualityStaff', N'质量部门职员')
insert into [dbo].[lg_Roles] values('11111111-aaaa-aaaa-aaaa-100000000004', 'MCManager', N'生产部门经理')
insert into [dbo].[lg_Roles] values('11111111-aaaa-aaaa-aaaa-100000000005', 'MCStaff', N'生产部门职员')
insert into [dbo].[lg_Roles] values('11111111-aaaa-aaaa-aaaa-100000000006', 'TSManager', N'技术支持部门经理')
insert into [dbo].[lg_Roles] values('11111111-aaaa-aaaa-aaaa-100000000007', 'TSStaff', N'技术支持部门职员')
insert into [dbo].[lg_Roles] values('11111111-aaaa-aaaa-aaaa-100000000008', 'PLOManager', N'PLO 经理')
insert into [dbo].[lg_Roles] values('11111111-aaaa-aaaa-aaaa-100000000009', 'PLOStaff', N'PLO 职员')

-- 为默认管理员用户分配角色
insert into [dbo].[lg_UserRoles] values('11111111-aaaa-aaaa-aaaa-000000000001', '11111111-aaaa-aaaa-aaaa-100000000001')

GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[lg_DisqualificationReports] WITH CHECK CHECK CONSTRAINT [FK_DisqualificationReports_OrderLineId];

ALTER TABLE [dbo].[lg_PurchaseOrderItems] WITH CHECK CHECK CONSTRAINT [FK_PurchaseOrderItems_MaterialId_MaterialInfos];

ALTER TABLE [dbo].[lg_PurchaseOrderItems] WITH CHECK CHECK CONSTRAINT [FK_PurchaseOrderItems_POId_PurchaseOrders];

ALTER TABLE [dbo].[lg_PurchaseOrderItems] WITH CHECK CHECK CONSTRAINT [FK_PurchaseOrderItems_SupplierId_SupplierInfos];

ALTER TABLE [dbo].[lg_UserRoles] WITH CHECK CHECK CONSTRAINT [FK_UserRoles_RoleId];

ALTER TABLE [dbo].[lg_UserRoles] WITH CHECK CHECK CONSTRAINT [FK_UserRoles_UserId];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        DECLARE @VarDecimalSupported AS BIT;
        SELECT @VarDecimalSupported = 0;
        IF ((ServerProperty(N'EngineEdition') = 3)
            AND (((@@microsoftversion / power(2, 24) = 9)
                  AND (@@microsoftversion & 0xffff >= 3024))
                 OR ((@@microsoftversion / power(2, 24) = 10)
                     AND (@@microsoftversion & 0xffff >= 1600))))
            SELECT @VarDecimalSupported = 1;
        IF (@VarDecimalSupported > 0)
            BEGIN
                EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
            END
    END


GO
