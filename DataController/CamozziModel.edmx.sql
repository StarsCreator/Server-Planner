
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/27/2015 16:25:57
-- Generated from EDMX file: C:\Users\ШаталовАА\Documents\Visual Studio 2013\Projects\CamozziServer\DataController\CamozziModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [WorkCamozzi];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_DeptProject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Projects] DROP CONSTRAINT [FK_DeptProject];
GO
IF OBJECT_ID(N'[dbo].[FK_DeptsUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_DeptsUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_UserProject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Projects] DROP CONSTRAINT [FK_UserProject];
GO
IF OBJECT_ID(N'[dbo].[FK_UserProject1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Projects] DROP CONSTRAINT [FK_UserProject1];
GO
IF OBJECT_ID(N'[dbo].[FK_UserProject2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Projects] DROP CONSTRAINT [FK_UserProject2];
GO
IF OBJECT_ID(N'[dbo].[FK_UserReclamation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reclamations] DROP CONSTRAINT [FK_UserReclamation];
GO
IF OBJECT_ID(N'[dbo].[FK_UserReclamation1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reclamations] DROP CONSTRAINT [FK_UserReclamation1];
GO
IF OBJECT_ID(N'[dbo].[FK_UserReclamation2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reclamations] DROP CONSTRAINT [FK_UserReclamation2];
GO
IF OBJECT_ID(N'[dbo].[FK_Users_Accounts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_Users_Accounts];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Accounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Accounts];
GO
IF OBJECT_ID(N'[dbo].[Depts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Depts];
GO
IF OBJECT_ID(N'[dbo].[Projects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Projects];
GO
IF OBJECT_ID(N'[dbo].[Reclamations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Reclamations];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AccountDbs'
CREATE TABLE [dbo].[AccountDbs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(200)  NOT NULL,
    [AllowCreateAll] bit  NOT NULL,
    [AllowCreateSelf] bit  NOT NULL,
    [AllowCommment] bit  NOT NULL,
    [AllowRow] bit  NOT NULL,
    [AllowReclamation] bit  NOT NULL
);
GO

-- Creating table 'DeptDbs'
CREATE TABLE [dbo].[DeptDbs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(200)  NOT NULL,
    [Description] nvarchar(1000)  NULL
);
GO

-- Creating table 'ProjectDbs'
CREATE TABLE [dbo].[ProjectDbs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(200)  NOT NULL,
    [Start] datetime  NOT NULL,
    [Finish] datetime  NOT NULL,
    [UserId] int  NOT NULL,
    [ManagerId] int  NOT NULL,
    [CreatorId] int  NOT NULL,
    [State] int  NOT NULL,
    [Priority] int  NOT NULL,
    [Comment] nvarchar(1000)  NULL,
    [DeptId] int  NOT NULL,
    [CreationDate] datetime  NOT NULL
);
GO

-- Creating table 'ReclamationDbs'
CREATE TABLE [dbo].[ReclamationDbs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Start] datetime  NOT NULL,
    [Finish] datetime  NOT NULL,
    [ManagerId] int  NOT NULL,
    [UserId] int  NOT NULL,
    [CreatorId] int  NOT NULL,
    [Send] datetime  NOT NULL,
    [Production] nvarchar(1000)  NOT NULL,
    [Nomenclature] nvarchar(200)  NOT NULL,
    [Act] nvarchar(100)  NOT NULL,
    [Count] int  NOT NULL,
    [State] int  NOT NULL,
    [Comment] nvarchar(1000)  NOT NULL,
    [Solution] bit  NOT NULL,
    [Client] nvarchar(1000)  NULL,
    [ReclamationAct] nvarchar(1000)  NULL
);
GO

-- Creating table 'UserDbs'
CREATE TABLE [dbo].[UserDbs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(200)  NOT NULL,
    [Phone] nvarchar(50)  NULL,
    [DeptId] int  NOT NULL,
    [Password] nvarchar(50)  NOT NULL,
    [Mail] nvarchar(200)  NULL,
    [AccountId] int  NOT NULL,
    [Comment] nvarchar(1000)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'AccountDbs'
ALTER TABLE [dbo].[AccountDbs]
ADD CONSTRAINT [PK_AccountDbs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DeptDbs'
ALTER TABLE [dbo].[DeptDbs]
ADD CONSTRAINT [PK_DeptDbs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProjectDbs'
ALTER TABLE [dbo].[ProjectDbs]
ADD CONSTRAINT [PK_ProjectDbs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ReclamationDbs'
ALTER TABLE [dbo].[ReclamationDbs]
ADD CONSTRAINT [PK_ReclamationDbs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserDbs'
ALTER TABLE [dbo].[UserDbs]
ADD CONSTRAINT [PK_UserDbs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AccountId] in table 'UserDbs'
ALTER TABLE [dbo].[UserDbs]
ADD CONSTRAINT [FK_Users_Accounts]
    FOREIGN KEY ([AccountId])
    REFERENCES [dbo].[AccountDbs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Users_Accounts'
CREATE INDEX [IX_FK_Users_Accounts]
ON [dbo].[UserDbs]
    ([AccountId]);
GO

-- Creating foreign key on [DeptId] in table 'ProjectDbs'
ALTER TABLE [dbo].[ProjectDbs]
ADD CONSTRAINT [FK_DeptProject]
    FOREIGN KEY ([DeptId])
    REFERENCES [dbo].[DeptDbs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DeptProject'
CREATE INDEX [IX_FK_DeptProject]
ON [dbo].[ProjectDbs]
    ([DeptId]);
GO

-- Creating foreign key on [DeptId] in table 'UserDbs'
ALTER TABLE [dbo].[UserDbs]
ADD CONSTRAINT [FK_DeptsUsers]
    FOREIGN KEY ([DeptId])
    REFERENCES [dbo].[DeptDbs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DeptsUsers'
CREATE INDEX [IX_FK_DeptsUsers]
ON [dbo].[UserDbs]
    ([DeptId]);
GO

-- Creating foreign key on [CreatorId] in table 'ProjectDbs'
ALTER TABLE [dbo].[ProjectDbs]
ADD CONSTRAINT [FK_UserProject]
    FOREIGN KEY ([CreatorId])
    REFERENCES [dbo].[UserDbs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserProject'
CREATE INDEX [IX_FK_UserProject]
ON [dbo].[ProjectDbs]
    ([CreatorId]);
GO

-- Creating foreign key on [ManagerId] in table 'ProjectDbs'
ALTER TABLE [dbo].[ProjectDbs]
ADD CONSTRAINT [FK_UserProject1]
    FOREIGN KEY ([ManagerId])
    REFERENCES [dbo].[UserDbs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserProject1'
CREATE INDEX [IX_FK_UserProject1]
ON [dbo].[ProjectDbs]
    ([ManagerId]);
GO

-- Creating foreign key on [UserId] in table 'ProjectDbs'
ALTER TABLE [dbo].[ProjectDbs]
ADD CONSTRAINT [FK_UserProject2]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserDbs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserProject2'
CREATE INDEX [IX_FK_UserProject2]
ON [dbo].[ProjectDbs]
    ([UserId]);
GO

-- Creating foreign key on [CreatorId] in table 'ReclamationDbs'
ALTER TABLE [dbo].[ReclamationDbs]
ADD CONSTRAINT [FK_UserReclamation]
    FOREIGN KEY ([CreatorId])
    REFERENCES [dbo].[UserDbs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserReclamation'
CREATE INDEX [IX_FK_UserReclamation]
ON [dbo].[ReclamationDbs]
    ([CreatorId]);
GO

-- Creating foreign key on [ManagerId] in table 'ReclamationDbs'
ALTER TABLE [dbo].[ReclamationDbs]
ADD CONSTRAINT [FK_UserReclamation1]
    FOREIGN KEY ([ManagerId])
    REFERENCES [dbo].[UserDbs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserReclamation1'
CREATE INDEX [IX_FK_UserReclamation1]
ON [dbo].[ReclamationDbs]
    ([ManagerId]);
GO

-- Creating foreign key on [UserId] in table 'ReclamationDbs'
ALTER TABLE [dbo].[ReclamationDbs]
ADD CONSTRAINT [FK_UserReclamation2]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserDbs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserReclamation2'
CREATE INDEX [IX_FK_UserReclamation2]
ON [dbo].[ReclamationDbs]
    ([UserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------