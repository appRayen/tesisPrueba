
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/07/2017 17:35:39
-- Generated from EDMX file: C:\Tesis\SistemaCalculo\SistemaCalculoweb\SlaCalculo.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Calculo];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CalculosResultados_Empresa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CalculosResultados] DROP CONSTRAINT [FK_CalculosResultados_Empresa];
GO
IF OBJECT_ID(N'[dbo].[FK_CalculosResultados_TipoActividadBase]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CalculosResultados] DROP CONSTRAINT [FK_CalculosResultados_TipoActividadBase];
GO
IF OBJECT_ID(N'[dbo].[FK_CalculosResultados_TipoInfraestructura]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CalculosResultados] DROP CONSTRAINT [FK_CalculosResultados_TipoInfraestructura];
GO
IF OBJECT_ID(N'[dbo].[FK_CalculosResultados_TipoOperacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CalculosResultados] DROP CONSTRAINT [FK_CalculosResultados_TipoOperacion];
GO
IF OBJECT_ID(N'[dbo].[FK_CalculosResultados_TipoServicioBrindado]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CalculosResultados] DROP CONSTRAINT [FK_CalculosResultados_TipoServicioBrindado];
GO
IF OBJECT_ID(N'[dbo].[FK_CalculosResultados_TipoTicket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CalculosResultados] DROP CONSTRAINT [FK_CalculosResultados_TipoTicket];
GO
IF OBJECT_ID(N'[dbo].[FK_CalculosResultados_Usuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CalculosResultados] DROP CONSTRAINT [FK_CalculosResultados_Usuario];
GO
IF OBJECT_ID(N'[dbo].[FK_Usuario_Perfil]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuario] DROP CONSTRAINT [FK_Usuario_Perfil];
GO
IF OBJECT_ID(N'[dbo].[FK_Usuario_Usuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuario] DROP CONSTRAINT [FK_Usuario_Usuario];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CalculosResultados]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CalculosResultados];
GO
IF OBJECT_ID(N'[dbo].[Empresa]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Empresa];
GO
IF OBJECT_ID(N'[dbo].[Perfil]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Perfil];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[TipoActividadBase]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoActividadBase];
GO
IF OBJECT_ID(N'[dbo].[TipoInfraestructura]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoInfraestructura];
GO
IF OBJECT_ID(N'[dbo].[TipoOperacion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoOperacion];
GO
IF OBJECT_ID(N'[dbo].[TipoServicioBrindado]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoServicioBrindado];
GO
IF OBJECT_ID(N'[dbo].[TipoTicket]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoTicket];
GO
IF OBJECT_ID(N'[dbo].[Usuario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuario];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CalculosResultados'
CREATE TABLE [dbo].[CalculosResultados] (
    [IdCalculo] int IDENTITY(1,1) NOT NULL,
    [resultado] decimal(18,0)  NULL,
    [cantidadPersonas] int  NULL,
    [fechaCalculo] datetime  NULL,
    [idUsuario] int  NULL,
    [idTipoInfraestructura] int  NULL,
    [idTipoOperacion] int  NULL,
    [idTipoTicket] int  NULL,
    [idTipoServicioBrindado] int  NULL,
    [idTipoActividadBase] int  NULL,
    [idEmpresa] int  NULL
);
GO

-- Creating table 'Empresa'
CREATE TABLE [dbo].[Empresa] (
    [IdEmpresa] int IDENTITY(1,1) NOT NULL,
    [Nombre] varchar(500)  NULL,
    [Direccion] varchar(500)  NULL,
    [rut] nchar(12)  NULL,
    [razonSocial] varchar(500)  NULL,
    [estado] smallint  NULL
);
GO

-- Creating table 'Perfil'
CREATE TABLE [dbo].[Perfil] (
    [IdPerfil] int  NOT NULL,
    [Descripcion] varchar(500)  NULL,
    [estado] smallint  NOT NULL,
    [contraseña] varchar(max)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'TipoActividadBase'
CREATE TABLE [dbo].[TipoActividadBase] (
    [idTipoActividadBase] int IDENTITY(1,1) NOT NULL,
    [descripcion] varchar(500)  NULL,
    [estado] smallint  NULL
);
GO

-- Creating table 'TipoInfraestructura'
CREATE TABLE [dbo].[TipoInfraestructura] (
    [idTipoInfraesteructura] int IDENTITY(1,1) NOT NULL,
    [descripcion] varchar(500)  NULL,
    [estado] smallint  NULL
);
GO

-- Creating table 'TipoOperacion'
CREATE TABLE [dbo].[TipoOperacion] (
    [idTipoOperacion] int IDENTITY(1,1) NOT NULL,
    [descripcion] varchar(500)  NULL,
    [estado] smallint  NOT NULL
);
GO

-- Creating table 'TipoServicioBrindado'
CREATE TABLE [dbo].[TipoServicioBrindado] (
    [idTipoServicioBrindado] int IDENTITY(1,1) NOT NULL,
    [descripcion] varchar(max)  NULL,
    [estado] smallint  NULL
);
GO

-- Creating table 'TipoTicket'
CREATE TABLE [dbo].[TipoTicket] (
    [tipoTicket1] int IDENTITY(1,1) NOT NULL,
    [descripcion] varchar(500)  NULL,
    [estado] smallint  NULL
);
GO

-- Creating table 'Usuario'
CREATE TABLE [dbo].[Usuario] (
    [idTipoUsuario] int  NOT NULL,
    [nombreUsuario] varchar(max)  NULL,
    [correo] varchar(max)  NULL,
    [nombre] varchar(max)  NULL,
    [apellidoP] varchar(max)  NULL,
    [apellidoM] varchar(max)  NULL,
    [rut] varchar(12)  NULL,
    [telefono] varchar(50)  NULL,
    [idPerfil] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdCalculo] in table 'CalculosResultados'
ALTER TABLE [dbo].[CalculosResultados]
ADD CONSTRAINT [PK_CalculosResultados]
    PRIMARY KEY CLUSTERED ([IdCalculo] ASC);
GO

-- Creating primary key on [IdEmpresa] in table 'Empresa'
ALTER TABLE [dbo].[Empresa]
ADD CONSTRAINT [PK_Empresa]
    PRIMARY KEY CLUSTERED ([IdEmpresa] ASC);
GO

-- Creating primary key on [IdPerfil] in table 'Perfil'
ALTER TABLE [dbo].[Perfil]
ADD CONSTRAINT [PK_Perfil]
    PRIMARY KEY CLUSTERED ([IdPerfil] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [idTipoActividadBase] in table 'TipoActividadBase'
ALTER TABLE [dbo].[TipoActividadBase]
ADD CONSTRAINT [PK_TipoActividadBase]
    PRIMARY KEY CLUSTERED ([idTipoActividadBase] ASC);
GO

-- Creating primary key on [idTipoInfraesteructura] in table 'TipoInfraestructura'
ALTER TABLE [dbo].[TipoInfraestructura]
ADD CONSTRAINT [PK_TipoInfraestructura]
    PRIMARY KEY CLUSTERED ([idTipoInfraesteructura] ASC);
GO

-- Creating primary key on [idTipoOperacion] in table 'TipoOperacion'
ALTER TABLE [dbo].[TipoOperacion]
ADD CONSTRAINT [PK_TipoOperacion]
    PRIMARY KEY CLUSTERED ([idTipoOperacion] ASC);
GO

-- Creating primary key on [idTipoServicioBrindado] in table 'TipoServicioBrindado'
ALTER TABLE [dbo].[TipoServicioBrindado]
ADD CONSTRAINT [PK_TipoServicioBrindado]
    PRIMARY KEY CLUSTERED ([idTipoServicioBrindado] ASC);
GO

-- Creating primary key on [tipoTicket1] in table 'TipoTicket'
ALTER TABLE [dbo].[TipoTicket]
ADD CONSTRAINT [PK_TipoTicket]
    PRIMARY KEY CLUSTERED ([tipoTicket1] ASC);
GO

-- Creating primary key on [idTipoUsuario] in table 'Usuario'
ALTER TABLE [dbo].[Usuario]
ADD CONSTRAINT [PK_Usuario]
    PRIMARY KEY CLUSTERED ([idTipoUsuario] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [idEmpresa] in table 'CalculosResultados'
ALTER TABLE [dbo].[CalculosResultados]
ADD CONSTRAINT [FK_CalculosResultados_Empresa]
    FOREIGN KEY ([idEmpresa])
    REFERENCES [dbo].[Empresa]
        ([IdEmpresa])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CalculosResultados_Empresa'
CREATE INDEX [IX_FK_CalculosResultados_Empresa]
ON [dbo].[CalculosResultados]
    ([idEmpresa]);
GO

-- Creating foreign key on [idTipoActividadBase] in table 'CalculosResultados'
ALTER TABLE [dbo].[CalculosResultados]
ADD CONSTRAINT [FK_CalculosResultados_TipoActividadBase]
    FOREIGN KEY ([idTipoActividadBase])
    REFERENCES [dbo].[TipoActividadBase]
        ([idTipoActividadBase])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CalculosResultados_TipoActividadBase'
CREATE INDEX [IX_FK_CalculosResultados_TipoActividadBase]
ON [dbo].[CalculosResultados]
    ([idTipoActividadBase]);
GO

-- Creating foreign key on [idTipoInfraestructura] in table 'CalculosResultados'
ALTER TABLE [dbo].[CalculosResultados]
ADD CONSTRAINT [FK_CalculosResultados_TipoInfraestructura]
    FOREIGN KEY ([idTipoInfraestructura])
    REFERENCES [dbo].[TipoInfraestructura]
        ([idTipoInfraesteructura])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CalculosResultados_TipoInfraestructura'
CREATE INDEX [IX_FK_CalculosResultados_TipoInfraestructura]
ON [dbo].[CalculosResultados]
    ([idTipoInfraestructura]);
GO

-- Creating foreign key on [idTipoOperacion] in table 'CalculosResultados'
ALTER TABLE [dbo].[CalculosResultados]
ADD CONSTRAINT [FK_CalculosResultados_TipoOperacion]
    FOREIGN KEY ([idTipoOperacion])
    REFERENCES [dbo].[TipoOperacion]
        ([idTipoOperacion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CalculosResultados_TipoOperacion'
CREATE INDEX [IX_FK_CalculosResultados_TipoOperacion]
ON [dbo].[CalculosResultados]
    ([idTipoOperacion]);
GO

-- Creating foreign key on [idTipoServicioBrindado] in table 'CalculosResultados'
ALTER TABLE [dbo].[CalculosResultados]
ADD CONSTRAINT [FK_CalculosResultados_TipoServicioBrindado]
    FOREIGN KEY ([idTipoServicioBrindado])
    REFERENCES [dbo].[TipoServicioBrindado]
        ([idTipoServicioBrindado])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CalculosResultados_TipoServicioBrindado'
CREATE INDEX [IX_FK_CalculosResultados_TipoServicioBrindado]
ON [dbo].[CalculosResultados]
    ([idTipoServicioBrindado]);
GO

-- Creating foreign key on [idTipoTicket] in table 'CalculosResultados'
ALTER TABLE [dbo].[CalculosResultados]
ADD CONSTRAINT [FK_CalculosResultados_TipoTicket]
    FOREIGN KEY ([idTipoTicket])
    REFERENCES [dbo].[TipoTicket]
        ([tipoTicket1])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CalculosResultados_TipoTicket'
CREATE INDEX [IX_FK_CalculosResultados_TipoTicket]
ON [dbo].[CalculosResultados]
    ([idTipoTicket]);
GO

-- Creating foreign key on [idUsuario] in table 'CalculosResultados'
ALTER TABLE [dbo].[CalculosResultados]
ADD CONSTRAINT [FK_CalculosResultados_Usuario]
    FOREIGN KEY ([idUsuario])
    REFERENCES [dbo].[Usuario]
        ([idTipoUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CalculosResultados_Usuario'
CREATE INDEX [IX_FK_CalculosResultados_Usuario]
ON [dbo].[CalculosResultados]
    ([idUsuario]);
GO

-- Creating foreign key on [idPerfil] in table 'Usuario'
ALTER TABLE [dbo].[Usuario]
ADD CONSTRAINT [FK_Usuario_Perfil]
    FOREIGN KEY ([idPerfil])
    REFERENCES [dbo].[Perfil]
        ([IdPerfil])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Usuario_Perfil'
CREATE INDEX [IX_FK_Usuario_Perfil]
ON [dbo].[Usuario]
    ([idPerfil]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------