USE master;
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
    nit        VARCHAR(20) UNIQUE,
    FOREIGN KEY(id_cliente) REFERENCES persona(id_persona),
)

CREATE TABLE usuario
(
    id_usuario     INT            PRIMARY KEY,
    nombre_usuario VARCHAR(30)    UNIQUE,
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
    nombre       VARCHAR(30) NOT NULL,
    telefono     VARCHAR(20) NOT NULL,
    nit          VARCHAR(20) UNIQUE,
    direccion    VARCHAR(30) NOT NULL,
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
    stock         INT            CHECK(stock > 5),
    -- activo: 1, inactivo: 0
    estado        BIT            NOT NULL,
    FOREIGN KEY(id_proveedor) REFERENCES proveedor(id_proveedor),
)

CREATE TABLE detatalle_venta
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
