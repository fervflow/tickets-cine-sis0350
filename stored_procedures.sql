-- INSERTAR USUARIO
CREATE OR ALTER PROC sp_insertar_usuario
    @ci VARCHAR(20),
    @nombre VARCHAR(30),
    @ap_paterno VARCHAR(30),
    @ap_materno VARCHAR(30),
    @usuario VARCHAR(30),
    @pass VARCHAR(30),
    @tipo VARCHAR(15),
    @estado BIT
AS
DECLARE @id_persona INT
INSERT INTO persona
    (ci, nombre, ap_paterno, ap_materno)
VALUES
    (@ci, @nombre, @ap_paterno, @ap_materno);
SET @id_persona=SCOPE_IDENTITY();
INSERT INTO usuario
    (id_usuario, nombre_usuario, pass, tipo, estado)
VALUES
    (@id_persona, @usuario, ENCRYPTBYPASSPHRASE('upds2024',@pass), @tipo, @estado)
GO

-- LISTAR USUARIOS
CREATE OR ALTER PROC sp_listar_usuarios
AS
SELECT
    p.id_persona,
    p.ci,
    p.nombre,
    p.ap_paterno,
    p.ap_materno,
    u.nombre_usuario,
    CONVERT(VARCHAR(30), DECRYPTBYPASSPHRASE('upds2024',u.pass)) AS pass,
    u.tipo,
    u.estado
FROM persona p INNER JOIN usuario u
    ON p.id_persona=u.id_usuario
GO

-- procedimiento para modificar usuaro
CREATE OR ALTER PROC sp_modificar_usuario
    @id_usuario INT,
    @ci VARCHAR(20),
    @nombre VARCHAR(30),
    @ap_paterno VARCHAR(30),
    @ap_materno VARCHAR(30),
    @usuario VARCHAR(30),
    @pass VARCHAR(30),
    @tipo VARCHAR(15),
    @estado BIT
AS
BEGIN
    SET XACT_ABORT ON;
    
    BEGIN TRY
        BEGIN TRANSACTION;
        UPDATE persona
        SET
            nombre = @nombre,
            ap_paterno = @ap_paterno,
            ap_materno = @ap_materno,
            ci = @ci
        WHERE id_persona = @id_usuario;

        UPDATE usuario
        SET
            nombre_usuario = @usuario,
            pass = ENCRYPTBYPASSPHRASE('upds2024', @pass),
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

EXEC dbo.sp_modificar_usuario 2, '12129090 CBB', 'nando', 'Vel', 'Flowers', 'fervflow', 'asd', 'VENDEDOR', 1;
GO

-- procedimiento almacenado para dar de baja usuario
CREATE OR ALTER PROC sp_deshabilitar_usuario
    @id_usuario INT,
    @estado BIT
AS
    UPDATE usuario SET estado=0 WHERE id_usuario=@id_usuario;
GO

-- procedimiento almacenado para insertar proveedor
CREATE OR ALTER PROC sp_insertar_proveedor
    @nit VARCHAR(20),
    @nombre VARCHAR(30),
    @direccion VARCHAR(30),
    @telefono VARCHAR(20),
    @ciudad VARCHAR(20)
AS
INSERT INTO proveedor
    (nit, nombre, direccion, telefono, ciudad)
VALUES
    (@nit, @nombre, @direccion, @telefono, @ciudad)
GO

-- procedimiento almacenado para listar proveedores
GO
CREATE OR ALTER PROC sp_listar_proveedores
AS
SELECT *
FROM proveedor
GO

-- procedimiento almacenado para modificar proveedor
CREATE OR ALTER PROC sp_modificar_proveedor
    @id_proveedor INT,
    @nit VARCHAR(20),
    @nombre VARCHAR(30),
    @direccion VARCHAR(30),
    @telefono VARCHAR(20),
    @ciudad VARCHAR(20)
AS
UPDATE proveedor
SET
    nit=@nit,
    nombre=@nombre,
    direccion=@direccion,
    telefono=@telefono,
    ciudad=@ciudad
WHERE id_proveedor=@id_proveedor
GO

-- procedimiento almacenado para buscar proveedor
CREATE PROC buscar_proveedor(@nombre VARCHAR(30))
AS
SELECT *
FROM proveedor
WHERE nombre LIKE '%'+@nombre+'%'
GO


-- PROCEDIMIENTO ALMACENADO PARA IDENTIFICARSE
GO
CREATE PROC identificarse(@usuario VARCHAR(30),
    @contra VARCHAR(30),
    @id INT output)
AS
SET @id=0;
SELECT @id=id_usuario
FROM usuario
WHERE nombre_usuario=@usuario AND CONVERT(VARCHAR(30),DECRYPTBYPASSPHRASE('upds2024',pass))=@contra AND estado='ACTIVO'
-- procedimiento almacenado para mostrar usuario logeado
GO
CREATE PROC mostrar_usuario(@id INT,
    @nombre VARCHAR(100) output,
    @cargo VARCHAR(30) output)
AS
SELECT @nombre=p.nombre+' '+p.ap_paterno+' '+p.ap_materno, @cargo=u.tipo
FROM persona p INNER JOIN usuario u
    ON p.id_persona=u.id_usuario
WHERE p.id_persona=@id
-- reporte de productos con sus proveedores
GO
CREATE PROC reporte_producto
AS
SELECT pro.nombre, pro.stock, pro.precio_v, prove.nombre AS proveedor, prove.ciudad
FROM producto pro INNER JOIN proveedor prove
    ON pro.id_proveedor=prove.id_proveedor