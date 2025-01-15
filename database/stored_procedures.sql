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

