USE master;

-- Creacion de la base de datos y usuario
DECLARE @DatabaseName NVARCHAR(128) = 'tickets_cine';
DECLARE @LoginName NVARCHAR(128) = 'tickets_admin';
DECLARE @Password NVARCHAR(128) = 'admin123';

IF EXISTS (SELECT name
FROM sys.databases
WHERE name = @DatabaseName)
BEGIN
    USE master;
    EXEC('ALTER DATABASE [' + @DatabaseName + '] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;');
    EXEC('DROP DATABASE [' + @DatabaseName + '];');
END

EXEC('CREATE DATABASE [' + @DatabaseName + '];');

-- Creacion del usuario para login correspondiente a la cadena de conexion
IF EXISTS (SELECT *
FROM sys.server_principals
WHERE name = @LoginName)
BEGIN
    EXEC('DROP LOGIN [' + @LoginName + '];');
END

EXEC('CREATE LOGIN [' + @LoginName + '] WITH PASSWORD = ''' + @Password + ''', CHECK_POLICY = OFF;');

EXEC('USE [' + @DatabaseName + '];');

EXEC('IF EXISTS (SELECT * FROM sys.database_principals WHERE name = ''' + @LoginName + ''') DROP USER [' + @LoginName + '];');

EXEC('CREATE USER [' + @LoginName + '] FOR LOGIN [' + @LoginName + '];');

EXEC('ALTER USER [' + @LoginName + '] WITH DEFAULT_SCHEMA = [dbo];');
EXEC('ALTER ROLE [db_owner] ADD MEMBER [' + @LoginName + '];');
GO

USE tickets_cine;

CREATE TABLE Persona
(
    id_persona INT         PRIMARY KEY IDENTITY(1, 1),
    ci         VARCHAR(20) UNIQUE,
    nombre     VARCHAR(30) NOT NULL,
    ap_paterno VARCHAR(30) NOT NULL,
    ap_materno VARCHAR(30),
);
GO

CREATE TABLE Cliente
(
    id_cliente INT         PRIMARY KEY,
    nit        VARCHAR(20) UNIQUE,
    FOREIGN KEY(id_cliente) REFERENCES Persona(id_persona),
);

CREATE TABLE Usuario
(
    id_usuario     INT            PRIMARY KEY,
    nombre_usuario VARCHAR(30)    UNIQUE,
    pass           VARBINARY(256) NOT NULL,
    tipo           VARCHAR(15)    CHECK(tipo IN('VENDEDOR', 'ADMINISTRADOR')),
    -- activo: 1, inactivo: 0
    estado         BIT            NOT NULL,
    FOREIGN KEY(id_usuario) REFERENCES Persona(id_persona),
);
GO

-- Tabla Peliculas
CREATE TABLE Peliculas
(
    pelicula_id   INT          PRIMARY KEY IDENTITY(1, 1),
    titulo        VARCHAR(100) NOT NULL,
    duracion      INT          NOT NULL,
    -- en minutos
    clasificacion VARCHAR(10)  NOT NULL
);
GO

-- Tabla Horarios
CREATE TABLE Horarios
(
    horario_id  INT           PRIMARY KEY IDENTITY(1, 1),
    pelicula_id INT           NOT NULL,
    fecha       DATE          NOT NULL,
    hora_inicio TIME          NOT NULL,
    precio      DECIMAL(8, 2) NOT NULL,
    FOREIGN KEY (pelicula_id) REFERENCES Peliculas (pelicula_id)
);

-- Tabla Asientos
CREATE TABLE Asientos
(
    asiento_id INT     PRIMARY KEY IDENTITY(1, 1),
    fila       CHAR(1) NOT NULL,
    -- Por ejemplo: 'A', 'B', 'C', etc.
    columna    INT     NOT NULL,
    -- Número de columna
    sala       INT     NOT NULL
);
GO

-- Tabla Tickets
CREATE TABLE Tickets
(
    ticket_id    INT           PRIMARY KEY IDENTITY(1, 1),
    cliente_id   INT           NOT NULL,
    -- Referencia al cliente que compró el ticket
    usuario_id   INT           NOT NULL,
    -- Usuario que vendió el ticket
    horario_id   INT           NOT NULL,
    asiento_id   INT           NOT NULL,
    fecha_compra DATETIME      DEFAULT CURRENT_TIMESTAMP,
    precio_total DECIMAL(8, 2) NOT NULL,
    FOREIGN KEY (cliente_id) REFERENCES Cliente (id_cliente),
    FOREIGN KEY (usuario_id) REFERENCES Usuario (id_usuario),
    FOREIGN KEY (horario_id) REFERENCES Horarios (horario_id),
    FOREIGN KEY (asiento_id) REFERENCES Asientos (asiento_id)
);
GO

-- Carga de datos iniciales
INSERT INTO Persona
VALUES
    ('1234 PO', 'Erick Fernando', 'Velasco', 'Flores'),
    ('2345 OR', 'Ani', 'Melon', NULL),
    ('333 CBB', 'Mar', 'Apollo', 'Guerrero'),
    ('444 AR', 'Nicki', 'Nicole', NULL)
GO
INSERT INTO Usuario
VALUES
    (1, 'erick', ENCRYPTBYPASSPHRASE('upds', '123'), 'ADMINISTRADOR', 1),
    (2, 'anime', ENCRYPTBYPASSPHRASE('upds', 'anime'), 'VENDEDOR', 1)
GO
INSERT INTO Cliente
VALUES
    (3, '333010'),
    (4, '444018')
GO

