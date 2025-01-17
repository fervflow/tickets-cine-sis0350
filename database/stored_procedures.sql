USE master;
GO
USE tickets_cine;
GO


-- PROCEDIMIENTO ALMACENADO PARA IDENTIFICARSE
CREATE OR ALTER PROC sp_login
    @usuario VARCHAR(30),
    @pass VARCHAR(30)
AS
BEGIN
    -- 0: Success, 1: Usuario no encontrado, 2: Usuario Deshabilitado, 3: Password incorrecto
    IF EXISTS (
        SELECT 1
    FROM Usuario
    WHERE nombre_usuario = @usuario
    )
    BEGIN
        DECLARE @id_usuario INT = (
            SELECT id_usuario
        FROM Usuario
        WHERE nombre_usuario = @usuario
        );
        IF (SELECT estado
        FROM Usuario
        WHERE id_usuario = @id_usuario
        ) = 1
        BEGIN
            IF (
                SELECT DECRYPTBYPASSPHRASE('upds', pass)
            FROM Usuario
            WHERE id_usuario = @id_usuario
            ) = @pass
                SELECT 0;
            ELSE SELECT 3;
        END
        ELSE SELECT 2;
    END
    ELSE SELECT 1;
END;
GO

-- procedimiento almacenado para mostrar Usuario logeado
CREATE OR ALTER PROC sp_obtener_usuario_logueado
    @usuario VARCHAR(30)
AS
SELECT
    p.id_persona,
    p.ci,
    p.nombre,
    u.nombre_usuario,
    CONVERT(VARCHAR(30), DECRYPTBYPASSPHRASE('upds',u.pass)) AS pass,
    u.tipo,
    u.estado
FROM Persona p INNER JOIN Usuario u
    ON p.id_persona=u.id_usuario
WHERE u.nombre_usuario = @usuario
GO

--USUARIOS
--
-- INSERTAR USUARIO
CREATE OR ALTER PROC sp_insertar_usuario
    @ci VARCHAR(20),
    @nombre VARCHAR(30),
    @usuario VARCHAR(30),
    @pass VARCHAR(30),
    @tipo VARCHAR(15),
    @estado BIT
AS
DECLARE @id_persona INT
INSERT INTO Persona
    (ci, nombre)
VALUES
    (@ci, @nombre);
SET @id_persona=SCOPE_IDENTITY();
INSERT INTO Usuario
    (id_usuario, nombre_usuario, pass, tipo, estado)
VALUES
    (@id_persona, @usuario, ENCRYPTBYPASSPHRASE('upds',@pass), @tipo, @estado)
GO

-- LISTAR USUARIOS
CREATE OR ALTER PROC sp_listar_usuarios
AS
SELECT
    p.id_persona,
    p.ci,
    p.nombre,
    u.nombre_usuario,
    CONVERT(VARCHAR(30), DECRYPTBYPASSPHRASE('upds',u.pass)) AS pass,
    u.tipo,
    u.estado
FROM Persona p INNER JOIN Usuario u
    ON p.id_persona=u.id_usuario
GO

-- procedimiento para modificar usuaro
CREATE OR ALTER PROC sp_modificar_usuario
    @id_usuario INT,
    @ci VARCHAR(20),
    @nombre VARCHAR(30),
    @usuario VARCHAR(30),
    @pass VARCHAR(30),
    @tipo VARCHAR(15),
    @estado BIT
AS
BEGIN
    SET XACT_ABORT ON;

    BEGIN TRY
        BEGIN TRANSACTION;
        UPDATE Persona
        SET
            nombre = @nombre,
            ci = @ci
        WHERE id_persona = @id_usuario;

        UPDATE Usuario
        SET
            nombre_usuario = @usuario,
            pass = ENCRYPTBYPASSPHRASE('upds', @pass),
            tipo = @tipo,
            estado = @estado
        WHERE id_usuario = @id_usuario;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0
        BEGIN
        ROLLBACK TRANSACTION;
    END
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        THROW 50000, @ErrorMessage, 1; -- Rethrow the error to the client
    END CATCH
END;
GO

-- BAJA a USUARIO
CREATE OR ALTER PROC sp_deshabilitar_usuario
    @id_usuario INT,
    @estado BIT
AS
UPDATE Usuario SET estado=0 WHERE id_usuario=@id_usuario;
GO

-- INSERTAR CLIENTE
CREATE OR ALTER PROC sp_insertar_cliente
    @ci VARCHAR(20),
    @nombre VARCHAR(30)
AS
DECLARE @id_persona INT;
INSERT INTO Persona
    (ci, nombre)
VALUES
    (@ci, @nombre);
SET @id_persona=SCOPE_IDENTITY();
INSERT INTO Cliente
    (id_cliente)
VALUES
    (@id_persona)
GO

-- LISTAR CLIENTES
CREATE OR ALTER PROC sp_listar_clientes
AS
SELECT
    c.id_cliente,
    p.ci,
    p.nombre
FROM Persona p INNER JOIN Cliente c
    ON p.id_persona=c.id_cliente
GO

-- MODIFICAR CLIENTE
CREATE OR ALTER PROC sp_modificar_cliente
    @id_cliente INT,
    @ci VARCHAR(20),
    @nombre VARCHAR(30)
AS
BEGIN
    SET XACT_ABORT ON;

    BEGIN TRY
        BEGIN TRANSACTION;
        UPDATE Persona
        SET
            nombre = @nombre,
            ci = @ci
        WHERE id_persona = @id_cliente;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0
        BEGIN
        ROLLBACK TRANSACTION;
    END
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        THROW 50000, @ErrorMessage, 1; -- Rethrow the error to the client
    END CATCH
END;
GO

-- BUSCAR CLIENTE
CREATE OR ALTER PROC sp_buscar_cliente
    @ci VARCHAR(20)
AS
SELECT
    p.nombre,
    p.ci,
    c.id_cliente
FROM Persona p INNER JOIN Cliente c
    ON p.id_persona=c.id_cliente
WHERE p.ci=@ci
GO


-- PELICULAS

-- INSERTAR PELICULA
CREATE OR ALTER PROCEDURE sp_insertar_pelicula
    @titulo NVARCHAR(100),
    @duracion INT,
    @genero NVARCHAR(20),
    @clasificacion NVARCHAR(10)
AS
BEGIN
    INSERT INTO Peliculas (titulo, duracion, genero, clasificacion)
    VALUES (@titulo, @duracion, @genero, @clasificacion);

    SELECT SCOPE_IDENTITY() AS pelicula_id;
END;
GO

-- LISTAR PELICULAS
CREATE OR ALTER PROCEDURE sp_listar_peliculas
AS
BEGIN
    SELECT 
        pelicula_id,
        titulo,
        duracion,
        genero,
        clasificacion
    FROM Peliculas;
END;
GO





-- SALAS
-- LISTAR SALAS
CREATE OR ALTER PROCEDURE sp_listar_salas
AS
SELECT
    sala_id,
    filas,
    columnas,
    bloques
FROM Salas;
GO


DROP PROCEDURE sp_listar_salas;
GO

-- INSERTAR ASIENTOS para SALAS
CREATE OR ALTER PROCEDURE sp_insertar_asientos_sala
    @sala_id INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @filas INT;
    DECLARE @columnas INT;

    SELECT @filas = filas, @columnas = columnas
    FROM Salas
    WHERE sala_id = @sala_id;

    IF @filas IS NULL OR @columnas IS NULL
    BEGIN
        PRINT 'Sala ID not found.';
        RETURN;
    END;

    WITH
        FilaCTE
        AS
        (
            SELECT TOP (@filas)
                CHAR(ASCII('A') - 1 + ROW_NUMBER() OVER (ORDER BY (SELECT NULL))) AS Fila
            FROM master.dbo.spt_values
        ),
        ColumnaCTE
        AS
        (
            SELECT TOP (@columnas)
                FORMAT(ROW_NUMBER() OVER (ORDER BY (SELECT NULL)), '00') AS Columna
            FROM master.dbo.spt_values
        )
    INSERT INTO Asientos
        (sala_id, codigo)
    SELECT
        @sala_id AS sala_id,
        Fila + '-' + Columna AS codigo
    FROM
        FilaCTE, ColumnaCTE;

    PRINT 'Asientos successfully inserted for Sala ID: ' + CAST(@sala_id AS VARCHAR(10));
END;
GO

-- OBTENER ASIENTOS DE UNA SALA
CREATE OR ALTER PROCEDURE sp_obtener_asientos
    @sala_id INT
AS
SELECT
    asiento_id,
    codigo,
    ocupado
FROM Asientos
WHERE sala_id = @sala_id;
GO


-- HORARIOS

-- LISTAR HORARIOS
CREATE PROCEDURE sp_listar_horarios
AS
BEGIN
    BEGIN TRY
        SELECT
            H.horario_id,
            H.sala_id,
            H.pelicula_id,
            H.fecha,
            H.hora_inicio,
            H.precio,
            P.titulo AS pelicula_titulo,
            P.duracion AS pelicula_duracion,
            P.genero AS pelicula_genero,
            P.clasificacion AS pelicula_clasificacion
    FROM Horarios H
        JOIN Salas S ON H.sala_id = S.sala_id
        JOIN Peliculas P ON H.pelicula_id = P.pelicula_id
    ORDER BY H.fecha, H.hora_inicio;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO

-- INSERTAR HORARIOS
CREATE OR ALTER PROCEDURE sp_insertar_horario
    @sala_id INT,
    @pelicula_id INT,
    @fecha DATE,
    @hora_inicio TIME,
    @precio DECIMAL(8, 2)
AS
BEGIN
    INSERT INTO Horarios (sala_id, pelicula_id, fecha, hora_inicio, precio)
    VALUES (@sala_id, @pelicula_id, @fecha, @hora_inicio, @precio);

    SELECT SCOPE_IDENTITY() AS horario_id;
END;
GO


-- PELICULAS
-- INSERTAR PELICULAS
CREATE OR ALTER PROCEDURE sp_insertar_pelicula
    @titulo NVARCHAR(100),
    @duracion INT,
    @genero NVARCHAR(20),
    @clasificacion NVARCHAR(10)
AS
BEGIN
    INSERT INTO Peliculas (titulo, duracion, genero, clasificacion)
    VALUES (@titulo, @duracion, @genero, @clasificacion);

    SELECT SCOPE_IDENTITY() AS pelicula_id;
END;
GO

-- LISTAR PELICULAS
CREATE OR ALTER PROCEDURE sp_listar_peliculas
AS
BEGIN
    SELECT 
        pelicula_id,
        titulo,
        duracion,
        genero,
        clasificacion
    FROM Peliculas;
END;
GO


-- TICKETS

-- INSERTAR TICKET
CREATE OR ALTER PROCEDURE sp_insertar_ticket
    @cliente_id INT,
    @usuario_id INT,
    @horario_id INT,
    @asiento_id INT,
    @precio_total DECIMAL(8, 2)
AS
BEGIN
    BEGIN TRY
        UPDATE Asientos
        SET ocupado = 1
        WHERE asiento_id = @asiento_id;

        INSERT INTO Tickets (cliente_id, usuario_id, horario_id, asiento_id, precio_total)
        VALUES (@cliente_id, @usuario_id, @horario_id, @asiento_id, @precio_total);

        SELECT SCOPE_IDENTITY() AS ticket_id;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO

-- OBTENER TICKET
CREATE OR ALTER PROCEDURE sp_obtener_ticket
    @ticket_id INT
AS
BEGIN
    SELECT 
        t.ticket_id,
        t.fecha_compra,
        t.precio_total,

        -- Cliente
        c.id_cliente AS cliente_id,
        p.ci AS cliente_ci,
        p.nombre AS cliente_nombre,

        -- Usuario
        u.id_usuario AS usuario_id,
        u.nombre_usuario AS usuario_nombre_usuario,

        -- Horario
        h.horario_id,
        h.sala_id AS sala_id,
        h.fecha AS horario_fecha,
        h.hora_inicio AS horario_hora_inicio,
        h.precio AS horario_precio,

        -- Pelicula
        pel.pelicula_id,
        pel.titulo AS pelicula_titulo,
        pel.duracion AS pelicula_duracion,
        pel.genero AS pelicula_genero,
        pel.clasificacion AS pelicula_clasificacion
    FROM 
        Tickets t
    INNER JOIN Cliente c ON t.cliente_id = c.id_cliente
    INNER JOIN Persona p ON c.id_cliente = p.id_persona
    INNER JOIN Usuario u ON t.usuario_id = u.id_usuario
    INNER JOIN Horarios h ON t.horario_id = h.horario_id
    INNER JOIN Peliculas pel ON h.pelicula_id = pel.pelicula_id
    WHERE 
        t.ticket_id = @ticket_id;
END;
GO



-- REPORTES
CREATE OR ALTER PROC sp_reporte_usuarios
AS
SELECT
    p.ci,
    p.nombre,
    u.nombre_usuario,
    u.tipo,
    u.estado
FROM persona p INNER JOIN usuario u
    ON p.id_persona=u.id_usuario
GO