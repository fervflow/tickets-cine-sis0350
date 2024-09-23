USE master;

IF EXISTS (SELECT name FROM sys.databases WHERE name = 'upds_ventas')
BEGIN
    USE master;
    ALTER DATABASE upds_ventas SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE upds_ventas;
END
GO

CREATE DATABASE upds_ventas;
GO

USE upds_ventas;

CREATE TABLE persona
(
    id_persona INT         PRIMARY KEY IDENTITY(1, 1),
    ci         VARCHAR(20) UNIQUE,
    nombre     VARCHAR(30) NOT NULL,
    ap_paterno VARCHAR(30) NOT NULL,
    ap_materno VARCHAR(30),
)
GO

CREATE TABLE cliente
(
    id_cliente INT         PRIMARY KEY,
    nit        VARCHAR(20) UNIQUE NOT NULL,
    FOREIGN KEY(id_cliente) REFERENCES persona(id_persona),
)

CREATE TABLE usuario
(
    id_usuario     INT            PRIMARY KEY,
    nombre_usuario VARCHAR(30)    UNIQUE NOT NULL,
    pass           VARBINARY(256) NOT NULL,
    tipo           VARCHAR(15)    CHECK(tipo IN('VENDEDOR', 'ADMINISTRADOR')),
    -- activo: 1, inactivo: 0
    estado         BIT            NOT NULL,
    FOREIGN KEY(id_usuario) REFERENCES persona(id_persona),
)
GO

CREATE TABLE venta
(
    id_cliente INT,
    id_usuario INT,
    id_venta   INT           PRIMARY KEY IDENTITY(1, 1),
    fecha      DATETIME      NOT NULL,
    total      DECIMAL(10,2) CHECK (total > 0),
    FOREIGN KEY(id_cliente) REFERENCES cliente(id_cliente),
    FOREIGN KEY(id_usuario) REFERENCES usuario(id_usuario),
)

CREATE TABLE proveedor
(
    id_proveedor INT         PRIMARY KEY IDENTITY(1, 1),
    nit          VARCHAR(20) UNIQUE,
    nombre       VARCHAR(30) NOT NULL,
    direccion    VARCHAR(30) NOT NULL,
    telefono     VARCHAR(20) NOT NULL,
    ciudad       VARCHAR(20) CHECK(ciudad IN(
        'POTOSI', 'COCHABAMBA', 'CHUQUISACA', 'TARIJA',
        'LA PAZ', 'SANTA CRUZ', 'ORURO', 'BENI', 'PANDO')),
)
GO

CREATE TABLE producto
(
    id_producto   INT            PRIMARY KEY IDENTITY(1, 1),
    id_proveedor  INT,
    nombre        VARCHAR(30)    NOT NULL,
    precio_compra DECIMAL(10, 2) CHECK(precio_compra>0),
    precio_venta  DECIMAL(10, 2) CHECK(precio_venta>0),
    stock         INT            CHECK(stock >= 0),
    -- activo: 1, inactivo: 0
    estado        BIT            NOT NULL,
    FOREIGN KEY(id_proveedor) REFERENCES proveedor(id_proveedor),
)

CREATE TABLE detalle_venta
(
    id_detalle_venta INT            PRIMARY KEY IDENTITY(1, 1),
    id_venta         INT,
    id_producto      INT,
    cantidad         INT            CHECK(cantidad > 0),
    sub_total        DECIMAL(10, 2),
    FOREIGN KEY (id_venta) REFERENCES venta(id_venta),
    FOREIGN KEY (id_producto) REFERENCES producto(id_producto),
)
GO

-- Carga de datos iniciales
INSERT INTO persona VALUES
    ('1234 PO', 'Erick Fernando', 'Velasco', 'Flores'),
    ('2345 OR', 'Ani', 'Melon', NULL),
    ('333 CBB', 'Mar', 'Apollo', 'Guerrero'),
    ('444 AR', 'Nicki', 'Nicole', NULL)
GO
INSERT INTO usuario VALUES
    (1, 'erick', ENCRYPTBYPASSPHRASE('upds2024', '123'), 'ADMINISTRADOR', 1),
    (2, 'anime', ENCRYPTBYPASSPHRASE('upds2024', 'anime'), 'VENDEDOR', 1)
GO
INSERT INTO cliente VALUES
    (3, '333010'),
    (4, '444018')
GO
INSERT INTO proveedor VALUES
    ('511015', 'Campos de Solana', 'Carretera a Bermejo Km 12', '+591 466 45498', 'TARIJA'),
    ('522012', 'XSport', 'Calle San Alberto S/N', '60708090', 'POTOSI'),
    ('577017', 'Coca Cola', 'Av. Periférica #333-E', '61616262', 'COCHABAMBA')
GO
INSERT INTO producto VALUES
    (2, 'Agua 500 ml', 3.70, 4.50, 120, 1),
    (1, 'ESTHER ORTIZ 10 años', 250.00, 300.00, 6, 1),
    (1, 'MALBEC', 50.00, 60.00, 40, 1),
    (1, 'ROSÉ', 39.50, 46.50, 24, 1),
    (2, 'Agua botellón 20 L', 31.30, 35.00, 20, 1),
    (3, 'Coca Cola 2 L', 8.70, 10.00, 41, 1)
GO

-- Creacion del usuario para login correspondiente a la cadena de conexion
USE master;
IF EXISTS (SELECT * FROM sys.server_principals WHERE name = 'upds_ventas_admin')
BEGIN
    DROP LOGIN upds_ventas_admin;
END
GO
CREATE LOGIN upds_ventas_admin WITH PASSWORD = 'admin123', CHECK_POLICY = OFF;
GO
USE upds_ventas;
DROP USER IF EXISTS upds_ventas_admin;
GO
CREATE USER upds_ventas_admin FOR LOGIN upds_ventas_admin;
GO
ALTER USER upds_ventas_admin WITH DEFAULT_SCHEMA = [dbo];
ALTER ROLE [db_owner] ADD MEMBER upds_ventas_admin;
GO
