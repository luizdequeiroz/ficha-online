
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/24/2017 14:51:54
-- Generated from EDMX file: C:\Users\Luiz de Queiroz\Dropbox\RolePlayingGame\Sistema - FichaOnline\FichaOnline\FichaOnline\Models\FichaOnline.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [FichaOnline];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UsuarioSet'
CREATE TABLE [dbo].[UsuarioSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Senha] nvarchar(max)  NOT NULL,
    [DataCadastro] nvarchar(max)  NOT NULL,
    [Pergunta] nvarchar(max)  NOT NULL,
    [Resposta] nvarchar(max)  NOT NULL,
    [DataNascimento] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'FichaSet'
CREATE TABLE [dbo].[FichaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Idade] int  NOT NULL,
    [Classe] nvarchar(max)  NOT NULL,
    [Raca] nvarchar(max)  NOT NULL,
    [Adre] int  NOT NULL,
    [Ataq] int  NOT NULL,
    [Defe] int  NOT NULL,
    [Dest] int  NOT NULL,
    [Forc] int  NOT NULL,
    [Inte] int  NOT NULL,
    [Resi] int  NOT NULL,
    [Sabe] int  NOT NULL,
    [Velo] int  NOT NULL,
    [Vital] int  NOT NULL,
    [Sorte] int  NOT NULL,
    [Nota] nvarchar(max)  NOT NULL,
    [Experiencia] int  NOT NULL,
    [UsuarioId] int  NOT NULL
);
GO

-- Creating table 'PeculiaridadeSet'
CREATE TABLE [dbo].[PeculiaridadeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Tipo] nvarchar(max)  NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Descricao] nvarchar(max)  NOT NULL,
    [Teste] int  NOT NULL,
    [FichaId] int  NOT NULL
);
GO

-- Creating table 'PraticaSet'
CREATE TABLE [dbo].[PraticaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Descricao] nvarchar(max)  NOT NULL,
    [Mod] int  NOT NULL,
    [PeculiaridadeId] int  NOT NULL
);
GO

-- Creating table 'PropriedadeRiquezaItemArmaSet'
CREATE TABLE [dbo].[PropriedadeRiquezaItemArmaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Tipo] nvarchar(max)  NOT NULL,
    [Subtipo] nvarchar(max)  NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Descricao] nvarchar(max)  NOT NULL,
    [PesoQuantidade] int  NOT NULL,
    [ValorDano] int  NOT NULL,
    [FichaId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UsuarioSet'
ALTER TABLE [dbo].[UsuarioSet]
ADD CONSTRAINT [PK_UsuarioSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FichaSet'
ALTER TABLE [dbo].[FichaSet]
ADD CONSTRAINT [PK_FichaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PeculiaridadeSet'
ALTER TABLE [dbo].[PeculiaridadeSet]
ADD CONSTRAINT [PK_PeculiaridadeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PraticaSet'
ALTER TABLE [dbo].[PraticaSet]
ADD CONSTRAINT [PK_PraticaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PropriedadeRiquezaItemArmaSet'
ALTER TABLE [dbo].[PropriedadeRiquezaItemArmaSet]
ADD CONSTRAINT [PK_PropriedadeRiquezaItemArmaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UsuarioId] in table 'FichaSet'
ALTER TABLE [dbo].[FichaSet]
ADD CONSTRAINT [FK_UsuarioFicha]
    FOREIGN KEY ([UsuarioId])
    REFERENCES [dbo].[UsuarioSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioFicha'
CREATE INDEX [IX_FK_UsuarioFicha]
ON [dbo].[FichaSet]
    ([UsuarioId]);
GO

-- Creating foreign key on [FichaId] in table 'PeculiaridadeSet'
ALTER TABLE [dbo].[PeculiaridadeSet]
ADD CONSTRAINT [FK_FichaPeculiaridade]
    FOREIGN KEY ([FichaId])
    REFERENCES [dbo].[FichaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FichaPeculiaridade'
CREATE INDEX [IX_FK_FichaPeculiaridade]
ON [dbo].[PeculiaridadeSet]
    ([FichaId]);
GO

-- Creating foreign key on [PeculiaridadeId] in table 'PraticaSet'
ALTER TABLE [dbo].[PraticaSet]
ADD CONSTRAINT [FK_PeculiaridadePratica]
    FOREIGN KEY ([PeculiaridadeId])
    REFERENCES [dbo].[PeculiaridadeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PeculiaridadePratica'
CREATE INDEX [IX_FK_PeculiaridadePratica]
ON [dbo].[PraticaSet]
    ([PeculiaridadeId]);
GO

-- Creating foreign key on [FichaId] in table 'PropriedadeRiquezaItemArmaSet'
ALTER TABLE [dbo].[PropriedadeRiquezaItemArmaSet]
ADD CONSTRAINT [FK_FichaPropriedadeRiquezaItemArma]
    FOREIGN KEY ([FichaId])
    REFERENCES [dbo].[FichaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FichaPropriedadeRiquezaItemArma'
CREATE INDEX [IX_FK_FichaPropriedadeRiquezaItemArma]
ON [dbo].[PropriedadeRiquezaItemArmaSet]
    ([FichaId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------