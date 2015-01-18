
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/13/2014 10:01:09
-- Generated from EDMX file: D:\_projects\visual studio 2013\Projects\WebApplication2\WebApplication2\Model1.edmx
-- --------------------------------------------------



-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_TaskUser_Task]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TaskUser] DROP CONSTRAINT [FK_TaskUser_Task];
GO
IF OBJECT_ID(N'[dbo].[FK_TaskUser_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TaskUser] DROP CONSTRAINT [FK_TaskUser_User];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Tasks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tasks];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[TaskUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TaskUser];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Tasks'
CREATE TABLE [dbo].[Tasks] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(50)  NOT NULL,
    [Description] nvarchar(100)  NULL,
    [CreatedDate] datetime  NOT NULL,
    [ModifiedDate] datetime  NOT NULL,
    [StateId] smallint  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TaskUser'
CREATE TABLE [dbo].[TaskUser] (
    [Tasks_Id] int  NOT NULL,
    [Users_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Tasks'
ALTER TABLE [dbo].[Tasks]
ADD CONSTRAINT [PK_Tasks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Tasks_Id], [Users_Id] in table 'TaskUser'
ALTER TABLE [dbo].[TaskUser]
ADD CONSTRAINT [PK_TaskUser]
    PRIMARY KEY CLUSTERED ([Tasks_Id], [Users_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Tasks_Id] in table 'TaskUser'
ALTER TABLE [dbo].[TaskUser]
ADD CONSTRAINT [FK_TaskUser_Task]
    FOREIGN KEY ([Tasks_Id])
    REFERENCES [dbo].[Tasks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Users_Id] in table 'TaskUser'
ALTER TABLE [dbo].[TaskUser]
ADD CONSTRAINT [FK_TaskUser_User]
    FOREIGN KEY ([Users_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TaskUser_User'
CREATE INDEX [IX_FK_TaskUser_User]
ON [dbo].[TaskUser]
    ([Users_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------