
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/16/2025 16:40:58
-- Generated from EDMX file: C:\Users\Lorenz\Documents\SISTEMAS_C#\SistemaPuntoVentaMaderas\SistemaPuntoVentaMaderas\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BaseDatosInventarioMaderaV8];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ClientesPrecioVentaCliente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PrecioVentaClienteSet] DROP CONSTRAINT [FK_ClientesPrecioVentaCliente];
GO
IF OBJECT_ID(N'[dbo].[FK_ClientesSetVentasSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VentasSet] DROP CONSTRAINT [FK_ClientesSetVentasSet];
GO
IF OBJECT_ID(N'[dbo].[FK_ComprasDetalleCompra]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleComprasSet] DROP CONSTRAINT [FK_ComprasDetalleCompra];
GO
IF OBJECT_ID(N'[dbo].[FK_ComprasRegistroAbonoProveedor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RegistroAbonoProveedorSet] DROP CONSTRAINT [FK_ComprasRegistroAbonoProveedor];
GO
IF OBJECT_ID(N'[dbo].[FK_MaderasPrecioCompraProveedor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PrecioCompraProveedorSet] DROP CONSTRAINT [FK_MaderasPrecioCompraProveedor];
GO
IF OBJECT_ID(N'[dbo].[FK_MaderasSetPrecioVentaClienteSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PrecioVentaClienteSet] DROP CONSTRAINT [FK_MaderasSetPrecioVentaClienteSet];
GO
IF OBJECT_ID(N'[dbo].[FK_PrecioCompraProveedorSetDetalleComprasSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleComprasSet] DROP CONSTRAINT [FK_PrecioCompraProveedorSetDetalleComprasSet];
GO
IF OBJECT_ID(N'[dbo].[FK_PrecioVentaClienteSetDetalleVentasSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleVentasSet] DROP CONSTRAINT [FK_PrecioVentaClienteSetDetalleVentasSet];
GO
IF OBJECT_ID(N'[dbo].[FK_ProveedoresCompras]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ComprasSet] DROP CONSTRAINT [FK_ProveedoresCompras];
GO
IF OBJECT_ID(N'[dbo].[FK_ProveedoresPrecioCompraProveedor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PrecioCompraProveedorSet] DROP CONSTRAINT [FK_ProveedoresPrecioCompraProveedor];
GO
IF OBJECT_ID(N'[dbo].[FK_TipoPagoCompras]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ComprasSet] DROP CONSTRAINT [FK_TipoPagoCompras];
GO
IF OBJECT_ID(N'[dbo].[FK_TipoPagoSetVentasSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VentasSet] DROP CONSTRAINT [FK_TipoPagoSetVentasSet];
GO
IF OBJECT_ID(N'[dbo].[FK_VentasDetalleVentas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleVentasSet] DROP CONSTRAINT [FK_VentasDetalleVentas];
GO
IF OBJECT_ID(N'[dbo].[FK_VentasRegistroAbonoClientes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RegistroAbonoClientesSet] DROP CONSTRAINT [FK_VentasRegistroAbonoClientes];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ClientesSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClientesSet];
GO
IF OBJECT_ID(N'[dbo].[ComprasSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ComprasSet];
GO
IF OBJECT_ID(N'[dbo].[DetalleComprasSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetalleComprasSet];
GO
IF OBJECT_ID(N'[dbo].[DetalleVentasSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetalleVentasSet];
GO
IF OBJECT_ID(N'[dbo].[MaderasSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MaderasSet];
GO
IF OBJECT_ID(N'[dbo].[PrecioCompraProveedorSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PrecioCompraProveedorSet];
GO
IF OBJECT_ID(N'[dbo].[PrecioVentaClienteSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PrecioVentaClienteSet];
GO
IF OBJECT_ID(N'[dbo].[ProveedoresSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProveedoresSet];
GO
IF OBJECT_ID(N'[dbo].[RegistroAbonoClientesSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RegistroAbonoClientesSet];
GO
IF OBJECT_ID(N'[dbo].[RegistroAbonoProveedorSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RegistroAbonoProveedorSet];
GO
IF OBJECT_ID(N'[dbo].[TipoPagoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoPagoSet];
GO
IF OBJECT_ID(N'[dbo].[UsuariosSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsuariosSet];
GO
IF OBJECT_ID(N'[dbo].[VentasSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VentasSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ClientesSet'
CREATE TABLE [dbo].[ClientesSet] (
    [IdCliente] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [App] nvarchar(max)  NOT NULL,
    [Apm] nvarchar(max)  NOT NULL,
    [NumCel] nvarchar(max)  NOT NULL,
    [Correo] nvarchar(max)  NULL,
    [FechaRegistro] datetime  NOT NULL,
    [Estatus] smallint  NOT NULL,
    [Calle] nvarchar(max)  NOT NULL,
    [NumInt] nvarchar(max)  NULL,
    [NumExt] nvarchar(max)  NULL,
    [Estado] nvarchar(max)  NOT NULL,
    [Ciudad] nvarchar(max)  NOT NULL,
    [NombreEmpresa] nvarchar(max)  NULL
);
GO

-- Creating table 'ComprasSet'
CREATE TABLE [dbo].[ComprasSet] (
    [IdCompra] int  NOT NULL,
    [FechaCompra] datetime  NOT NULL,
    [TotalProducto] bigint  NOT NULL,
    [PrecioTotal] float  NOT NULL,
    [FechaRegistro] datetime  NOT NULL,
    [PagoCon] float  NOT NULL,
    [Deuda] float  NOT NULL,
    [Proveedores_IdProveedor] int  NOT NULL,
    [TipoPago_IdTipoPago] int  NOT NULL,
    [NombreEntrega] nvarchar(max)  NOT NULL,
    [NombreRecibe] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'DetalleComprasSet'
CREATE TABLE [dbo].[DetalleComprasSet] (
    [IdDetalleCompra] int IDENTITY(1,1) NOT NULL,
    [Cantidad] bigint  NOT NULL,
    [Subtotal] float  NOT NULL,
    [Compras_IdCompra] int  NOT NULL,
    [PrecioCompraProveedorSet_IdPrecioCpm] int  NOT NULL
);
GO

-- Creating table 'DetalleVentasSet'
CREATE TABLE [dbo].[DetalleVentasSet] (
    [IdDetalleVenta] int IDENTITY(1,1) NOT NULL,
    [Cantidad] bigint  NOT NULL,
    [SubTotal] float  NOT NULL,
    [Ventas_IdVenta] int  NOT NULL,
    [PrecioVentaClienteSet_IdPrecioVcm] int  NOT NULL
);
GO

-- Creating table 'MaderasSet'
CREATE TABLE [dbo].[MaderasSet] (
    [IdMadera] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [Estatus] smallint  NOT NULL,
    [Stock] bigint  NOT NULL,
    [StockControl] bigint  NOT NULL,
    [FechaMovInventario] datetime  NOT NULL
);
GO

-- Creating table 'PrecioCompraProveedorSet'
CREATE TABLE [dbo].[PrecioCompraProveedorSet] (
    [IdPrecioCpm] int IDENTITY(1,1) NOT NULL,
    [PrecioMadera] float  NOT NULL,
    [Estatus] smallint  NOT NULL,
    [Proveedores_IdProveedor] int  NOT NULL,
    [Maderas_IdMadera] int  NOT NULL
);
GO

-- Creating table 'PrecioVentaClienteSet'
CREATE TABLE [dbo].[PrecioVentaClienteSet] (
    [IdPrecioVcm] int IDENTITY(1,1) NOT NULL,
    [PrecioMadera] float  NOT NULL,
    [Estatus] smallint  NOT NULL,
    [Clientes_IdCliente] int  NOT NULL,
    [Maderas_IdMadera] int  NOT NULL
);
GO

-- Creating table 'ProveedoresSet'
CREATE TABLE [dbo].[ProveedoresSet] (
    [IdProveedor] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [App] nvarchar(max)  NOT NULL,
    [Apm] nvarchar(max)  NOT NULL,
    [NumCel] nvarchar(max)  NOT NULL,
    [Correo] nvarchar(max)  NULL,
    [FechaRegistro] datetime  NOT NULL,
    [Estatus] smallint  NOT NULL,
    [Calle] nvarchar(max)  NOT NULL,
    [NumExt] nvarchar(max)  NULL,
    [NumInt] nvarchar(max)  NULL,
    [Estado] nvarchar(max)  NOT NULL,
    [Ciudad] nvarchar(max)  NOT NULL,
    [NombreEmpresa] nvarchar(max)  NULL
);
GO

-- Creating table 'RegistroAbonoClientesSet'
CREATE TABLE [dbo].[RegistroAbonoClientesSet] (
    [IdAbono] int IDENTITY(1,1) NOT NULL,
    [FechaAbono] datetime  NOT NULL,
    [Debia] float  NOT NULL,
    [Abono] float  NOT NULL,
    [Debe] float  NOT NULL,
    [RecibeAbono] nvarchar(max)  NOT NULL,
    [Ventas_IdVenta] int  NOT NULL
);
GO

-- Creating table 'RegistroAbonoProveedorSet'
CREATE TABLE [dbo].[RegistroAbonoProveedorSet] (
    [IdAbono] int IDENTITY(1,1) NOT NULL,
    [FechaAbono] datetime  NOT NULL,
    [Debia] float  NOT NULL,
    [Abono] float  NOT NULL,
    [Debe] float  NOT NULL,
    [RecibeAbono] nvarchar(max)  NOT NULL,
    [Compras_IdCompra] int  NOT NULL
);
GO

-- Creating table 'TipoPagoSet'
CREATE TABLE [dbo].[TipoPagoSet] (
    [IdTipoPago] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Estatus] smallint  NOT NULL
);
GO

-- Creating table 'UsuariosSet'
CREATE TABLE [dbo].[UsuariosSet] (
    [IdUser] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [App] nvarchar(max)  NOT NULL,
    [Apm] nvarchar(max)  NOT NULL,
    [Usuario] nvarchar(max)  NOT NULL,
    [Contrasena] nvarchar(max)  NOT NULL,
    [Estatus] smallint  NOT NULL
);
GO

-- Creating table 'VentasSet'
CREATE TABLE [dbo].[VentasSet] (
    [IdVenta] int  NOT NULL,
    [FechaVenta] datetime  NOT NULL,
    [TotalProducto] bigint  NOT NULL,
    [PrecioTotal] float  NOT NULL,
    [FechaRegistro] datetime  NOT NULL,
    [PagoCon] float  NOT NULL,
    [Deuda] float  NOT NULL,
    [ClientesSet_IdCliente] int  NOT NULL,
    [TipoPagoSet_IdTipoPago] int  NOT NULL,
    [NombreEntrega] nvarchar(max)  NOT NULL,
    [NombreRecibe] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdCliente] in table 'ClientesSet'
ALTER TABLE [dbo].[ClientesSet]
ADD CONSTRAINT [PK_ClientesSet]
    PRIMARY KEY CLUSTERED ([IdCliente] ASC);
GO

-- Creating primary key on [IdCompra] in table 'ComprasSet'
ALTER TABLE [dbo].[ComprasSet]
ADD CONSTRAINT [PK_ComprasSet]
    PRIMARY KEY CLUSTERED ([IdCompra] ASC);
GO

-- Creating primary key on [IdDetalleCompra] in table 'DetalleComprasSet'
ALTER TABLE [dbo].[DetalleComprasSet]
ADD CONSTRAINT [PK_DetalleComprasSet]
    PRIMARY KEY CLUSTERED ([IdDetalleCompra] ASC);
GO

-- Creating primary key on [IdDetalleVenta] in table 'DetalleVentasSet'
ALTER TABLE [dbo].[DetalleVentasSet]
ADD CONSTRAINT [PK_DetalleVentasSet]
    PRIMARY KEY CLUSTERED ([IdDetalleVenta] ASC);
GO

-- Creating primary key on [IdMadera] in table 'MaderasSet'
ALTER TABLE [dbo].[MaderasSet]
ADD CONSTRAINT [PK_MaderasSet]
    PRIMARY KEY CLUSTERED ([IdMadera] ASC);
GO

-- Creating primary key on [IdPrecioCpm] in table 'PrecioCompraProveedorSet'
ALTER TABLE [dbo].[PrecioCompraProveedorSet]
ADD CONSTRAINT [PK_PrecioCompraProveedorSet]
    PRIMARY KEY CLUSTERED ([IdPrecioCpm] ASC);
GO

-- Creating primary key on [IdPrecioVcm] in table 'PrecioVentaClienteSet'
ALTER TABLE [dbo].[PrecioVentaClienteSet]
ADD CONSTRAINT [PK_PrecioVentaClienteSet]
    PRIMARY KEY CLUSTERED ([IdPrecioVcm] ASC);
GO

-- Creating primary key on [IdProveedor] in table 'ProveedoresSet'
ALTER TABLE [dbo].[ProveedoresSet]
ADD CONSTRAINT [PK_ProveedoresSet]
    PRIMARY KEY CLUSTERED ([IdProveedor] ASC);
GO

-- Creating primary key on [IdAbono] in table 'RegistroAbonoClientesSet'
ALTER TABLE [dbo].[RegistroAbonoClientesSet]
ADD CONSTRAINT [PK_RegistroAbonoClientesSet]
    PRIMARY KEY CLUSTERED ([IdAbono] ASC);
GO

-- Creating primary key on [IdAbono] in table 'RegistroAbonoProveedorSet'
ALTER TABLE [dbo].[RegistroAbonoProveedorSet]
ADD CONSTRAINT [PK_RegistroAbonoProveedorSet]
    PRIMARY KEY CLUSTERED ([IdAbono] ASC);
GO

-- Creating primary key on [IdTipoPago] in table 'TipoPagoSet'
ALTER TABLE [dbo].[TipoPagoSet]
ADD CONSTRAINT [PK_TipoPagoSet]
    PRIMARY KEY CLUSTERED ([IdTipoPago] ASC);
GO

-- Creating primary key on [IdUser] in table 'UsuariosSet'
ALTER TABLE [dbo].[UsuariosSet]
ADD CONSTRAINT [PK_UsuariosSet]
    PRIMARY KEY CLUSTERED ([IdUser] ASC);
GO

-- Creating primary key on [IdVenta] in table 'VentasSet'
ALTER TABLE [dbo].[VentasSet]
ADD CONSTRAINT [PK_VentasSet]
    PRIMARY KEY CLUSTERED ([IdVenta] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Clientes_IdCliente] in table 'PrecioVentaClienteSet'
ALTER TABLE [dbo].[PrecioVentaClienteSet]
ADD CONSTRAINT [FK_ClientesPrecioVentaCliente]
    FOREIGN KEY ([Clientes_IdCliente])
    REFERENCES [dbo].[ClientesSet]
        ([IdCliente])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientesPrecioVentaCliente'
CREATE INDEX [IX_FK_ClientesPrecioVentaCliente]
ON [dbo].[PrecioVentaClienteSet]
    ([Clientes_IdCliente]);
GO

-- Creating foreign key on [ClientesSet_IdCliente] in table 'VentasSet'
ALTER TABLE [dbo].[VentasSet]
ADD CONSTRAINT [FK_ClientesSetVentasSet]
    FOREIGN KEY ([ClientesSet_IdCliente])
    REFERENCES [dbo].[ClientesSet]
        ([IdCliente])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientesSetVentasSet'
CREATE INDEX [IX_FK_ClientesSetVentasSet]
ON [dbo].[VentasSet]
    ([ClientesSet_IdCliente]);
GO

-- Creating foreign key on [Compras_IdCompra] in table 'DetalleComprasSet'
ALTER TABLE [dbo].[DetalleComprasSet]
ADD CONSTRAINT [FK_ComprasDetalleCompra]
    FOREIGN KEY ([Compras_IdCompra])
    REFERENCES [dbo].[ComprasSet]
        ([IdCompra])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ComprasDetalleCompra'
CREATE INDEX [IX_FK_ComprasDetalleCompra]
ON [dbo].[DetalleComprasSet]
    ([Compras_IdCompra]);
GO

-- Creating foreign key on [Compras_IdCompra] in table 'RegistroAbonoProveedorSet'
ALTER TABLE [dbo].[RegistroAbonoProveedorSet]
ADD CONSTRAINT [FK_ComprasRegistroAbonoProveedor]
    FOREIGN KEY ([Compras_IdCompra])
    REFERENCES [dbo].[ComprasSet]
        ([IdCompra])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ComprasRegistroAbonoProveedor'
CREATE INDEX [IX_FK_ComprasRegistroAbonoProveedor]
ON [dbo].[RegistroAbonoProveedorSet]
    ([Compras_IdCompra]);
GO

-- Creating foreign key on [Proveedores_IdProveedor] in table 'ComprasSet'
ALTER TABLE [dbo].[ComprasSet]
ADD CONSTRAINT [FK_ProveedoresCompras]
    FOREIGN KEY ([Proveedores_IdProveedor])
    REFERENCES [dbo].[ProveedoresSet]
        ([IdProveedor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProveedoresCompras'
CREATE INDEX [IX_FK_ProveedoresCompras]
ON [dbo].[ComprasSet]
    ([Proveedores_IdProveedor]);
GO

-- Creating foreign key on [TipoPago_IdTipoPago] in table 'ComprasSet'
ALTER TABLE [dbo].[ComprasSet]
ADD CONSTRAINT [FK_TipoPagoCompras]
    FOREIGN KEY ([TipoPago_IdTipoPago])
    REFERENCES [dbo].[TipoPagoSet]
        ([IdTipoPago])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TipoPagoCompras'
CREATE INDEX [IX_FK_TipoPagoCompras]
ON [dbo].[ComprasSet]
    ([TipoPago_IdTipoPago]);
GO

-- Creating foreign key on [PrecioCompraProveedorSet_IdPrecioCpm] in table 'DetalleComprasSet'
ALTER TABLE [dbo].[DetalleComprasSet]
ADD CONSTRAINT [FK_PrecioCompraProveedorSetDetalleComprasSet]
    FOREIGN KEY ([PrecioCompraProveedorSet_IdPrecioCpm])
    REFERENCES [dbo].[PrecioCompraProveedorSet]
        ([IdPrecioCpm])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PrecioCompraProveedorSetDetalleComprasSet'
CREATE INDEX [IX_FK_PrecioCompraProveedorSetDetalleComprasSet]
ON [dbo].[DetalleComprasSet]
    ([PrecioCompraProveedorSet_IdPrecioCpm]);
GO

-- Creating foreign key on [PrecioVentaClienteSet_IdPrecioVcm] in table 'DetalleVentasSet'
ALTER TABLE [dbo].[DetalleVentasSet]
ADD CONSTRAINT [FK_PrecioVentaClienteSetDetalleVentasSet]
    FOREIGN KEY ([PrecioVentaClienteSet_IdPrecioVcm])
    REFERENCES [dbo].[PrecioVentaClienteSet]
        ([IdPrecioVcm])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PrecioVentaClienteSetDetalleVentasSet'
CREATE INDEX [IX_FK_PrecioVentaClienteSetDetalleVentasSet]
ON [dbo].[DetalleVentasSet]
    ([PrecioVentaClienteSet_IdPrecioVcm]);
GO

-- Creating foreign key on [Ventas_IdVenta] in table 'DetalleVentasSet'
ALTER TABLE [dbo].[DetalleVentasSet]
ADD CONSTRAINT [FK_VentasDetalleVentas]
    FOREIGN KEY ([Ventas_IdVenta])
    REFERENCES [dbo].[VentasSet]
        ([IdVenta])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VentasDetalleVentas'
CREATE INDEX [IX_FK_VentasDetalleVentas]
ON [dbo].[DetalleVentasSet]
    ([Ventas_IdVenta]);
GO

-- Creating foreign key on [Maderas_IdMadera] in table 'PrecioCompraProveedorSet'
ALTER TABLE [dbo].[PrecioCompraProveedorSet]
ADD CONSTRAINT [FK_MaderasPrecioCompraProveedor]
    FOREIGN KEY ([Maderas_IdMadera])
    REFERENCES [dbo].[MaderasSet]
        ([IdMadera])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MaderasPrecioCompraProveedor'
CREATE INDEX [IX_FK_MaderasPrecioCompraProveedor]
ON [dbo].[PrecioCompraProveedorSet]
    ([Maderas_IdMadera]);
GO

-- Creating foreign key on [Maderas_IdMadera] in table 'PrecioVentaClienteSet'
ALTER TABLE [dbo].[PrecioVentaClienteSet]
ADD CONSTRAINT [FK_MaderasSetPrecioVentaClienteSet]
    FOREIGN KEY ([Maderas_IdMadera])
    REFERENCES [dbo].[MaderasSet]
        ([IdMadera])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MaderasSetPrecioVentaClienteSet'
CREATE INDEX [IX_FK_MaderasSetPrecioVentaClienteSet]
ON [dbo].[PrecioVentaClienteSet]
    ([Maderas_IdMadera]);
GO

-- Creating foreign key on [Proveedores_IdProveedor] in table 'PrecioCompraProveedorSet'
ALTER TABLE [dbo].[PrecioCompraProveedorSet]
ADD CONSTRAINT [FK_ProveedoresPrecioCompraProveedor]
    FOREIGN KEY ([Proveedores_IdProveedor])
    REFERENCES [dbo].[ProveedoresSet]
        ([IdProveedor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProveedoresPrecioCompraProveedor'
CREATE INDEX [IX_FK_ProveedoresPrecioCompraProveedor]
ON [dbo].[PrecioCompraProveedorSet]
    ([Proveedores_IdProveedor]);
GO

-- Creating foreign key on [Ventas_IdVenta] in table 'RegistroAbonoClientesSet'
ALTER TABLE [dbo].[RegistroAbonoClientesSet]
ADD CONSTRAINT [FK_VentasRegistroAbonoClientes]
    FOREIGN KEY ([Ventas_IdVenta])
    REFERENCES [dbo].[VentasSet]
        ([IdVenta])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VentasRegistroAbonoClientes'
CREATE INDEX [IX_FK_VentasRegistroAbonoClientes]
ON [dbo].[RegistroAbonoClientesSet]
    ([Ventas_IdVenta]);
GO

-- Creating foreign key on [TipoPagoSet_IdTipoPago] in table 'VentasSet'
ALTER TABLE [dbo].[VentasSet]
ADD CONSTRAINT [FK_TipoPagoSetVentasSet]
    FOREIGN KEY ([TipoPagoSet_IdTipoPago])
    REFERENCES [dbo].[TipoPagoSet]
        ([IdTipoPago])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TipoPagoSetVentasSet'
CREATE INDEX [IX_FK_TipoPagoSetVentasSet]
ON [dbo].[VentasSet]
    ([TipoPagoSet_IdTipoPago]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------