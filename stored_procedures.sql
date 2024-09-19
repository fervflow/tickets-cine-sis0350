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
CREATE OR ALTER PROC sp_buscar_proveedor
    @nombre VARCHAR(30)
AS
SELECT *
FROM proveedor
WHERE LOWER(nombre) LIKE '%'+@nombre+'%'
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
        FROM usuario
        WHERE nombre_usuario = @usuario
    )
    BEGIN
        DECLARE @id_usuario INT = (
            SELECT id_usuario
            FROM usuario
            WHERE nombre_usuario = @usuario
        );
        IF (SELECT estado
            FROM usuario
            WHERE id_usuario = @id_usuario
        ) = 1
        BEGIN
            IF (
                SELECT DECRYPTBYPASSPHRASE('upds2024', pass)
                FROM usuario
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

-- procedimiento almacenado para mostrar usuario logeado
CREATE OR ALTER PROC sp_obtener_usuario_logueado
    @usuario VARCHAR(30)
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
WHERE u.nombre_usuario = @usuario
GO

-- reporte de productos con sus proveedores
--
CREATE OR ALTER PROC sp_reporte_producto
AS
SELECT
    pro.nombre,
    pro.stock,
    pro.precio_venta,
    prove.nombre AS proveedor,
    prove.ciudad
FROM producto pro INNER JOIN proveedor prove
    ON pro.id_proveedor=prove.id_proveedor
GO



-- 2
-- CARGAR PROVEEDORES
CREATE OR ALTER PROC sp_nombres_proveedor
AS
SELECT
    id_proveedor,
    nombre + ' - ' + nit AS nombre
FROM proveedor
GO

SELECT 
    id_proveedor,
    nombre + ' - ' + nit AS nombre
FROM proveedor
GO

-- REGISTRAR PRODUCTO
CREATE OR ALTER PROC sp_nuevo_producto
    @nombre VARCHAR(30),
    @stock INT,
    @precio_compra DECIMAL(10,2),
    @precio_venta DECIMAL(10,2),
    @estado BIT,
    @id_proveedor INT
AS
INSERT INTO producto
    (nombre, stock, precio_compra, precio_venta, estado, id_proveedor)
VALUES
    (@nombre, @stock, @precio_compra, @precio_venta, @estado, @id_proveedor)
GO

----prueba
SELECT *
FROM producto
SELECT *
FROM proveedor
GO

-- listar producto
CREATE OR ALTER PROC sp_listar_productos
    @filter BIT
AS
SELECT
    p.id_producto,
    p.id_proveedor,
    p.nombre,
    p.stock,
    p.precio_compra,
    p.precio_venta,
    prov.nombre AS proveedor,
    p.estado
FROM producto p INNER JOIN proveedor prov
    ON p.id_proveedor=prov.id_proveedor
WHERE @filter = 0 OR p.estado = 1
GO

--verificamos
SELECT *
FROM producto
GO

-- procedimiento almacenado para modificar producto
CREATE OR ALTER PROC sp_modificar_producto
    @id_producto INT,
    @nombre VARCHAR(30),
    @stock INT,
    @precio_compra DECIMAL(10,2),
    @precio_venta DECIMAL(10,2),
    @estado BIT,
    @id_proveedor INT
AS
UPDATE producto SET
    nombre=@nombre,
    stock=@stock,
    precio_compra=@precio_compra,
    precio_venta=@precio_venta,
    estado=@estado,
    id_proveedor=@id_proveedor
WHERE id_producto=@id_producto
GO

-- Deshabilitar producto
CREATE OR ALTER PROC sp_deshabilitar_producto
    @id_producto INT
AS
UPDATE producto SET estado=0
WHERE id_producto=@id_producto
GO

-- INSERTAR CLIENTE
CREATE OR ALTER PROC sp_insertar_cliente
    @ci VARCHAR(20),
    @nombre VARCHAR(30),
    @ap_paterno VARCHAR(30),
    @ap_materno VARCHAR(30),
    @nit VARCHAR(20)
AS
DECLARE @id_persona INT;
INSERT INTO persona
    (ci, nombre, ap_paterno, ap_materno)
VALUES
    (@ci, @nombre, @ap_paterno, @ap_materno);
SET @id_persona=SCOPE_IDENTITY();
INSERT INTO cliente
    (id_cliente, nit)
VALUES
    (@id_persona, @nit)
GO

-- LISTAR CLIENTES
CREATE OR ALTER PROC sp_listar_clientes
AS
SELECT
    c.id_cliente,
    p.ci,
    p.nombre,
    p.ap_paterno,
    p.ap_materno,
    c.nit
FROM persona p INNER JOIN cliente c
    ON p.id_persona=c.id_cliente
GO

-- MODIFICAR CLIENTE
CREATE OR ALTER PROC sp_modificar_cliente
    @id_cliente INT,
    @ci VARCHAR(20),
    @nombre VARCHAR(30),
    @ap_paterno VARCHAR(30),
    @ap_materno VARCHAR(30),
    @nit VARCHAR(20)
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
        WHERE id_persona = @id_cliente;

        UPDATE cliente SET nit = @nit
        WHERE id_cliente = @id_cliente;

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


-- 3
-- BUSCAR CLIENTE
CREATE OR ALTER PROC sp_buscar_cliente
    @nit VARCHAR(20)
AS
SELECT
    p.nombre,
    p.ap_paterno,
    p.ap_materno,
    p.ci,
    c.nit,
    c.id_cliente
FROM persona p INNER JOIN cliente c
    ON p.id_persona=c.id_cliente
WHERE c.nit=@nit
GO

-- procedimiento almacenado para listar productos para la venta
GO
CREATE PROC listar_productos
AS
SELECT p.id_producto, p.nombre, p.stock, p.precio_v, pro.nombre AS proveedor
FROM producto p INNER JOIN proveedor pro
    ON p.id_proveedor=pro.id_proveedor
WHERE p.estado='ACTIVO'

-- procedimiento para almacenar la venta
GO
CREATE PROC registrar_venta(@total DECIMAL(10,2),
    @id_c INT,
    @id_us INT)
AS
INSERT INTO venta
    (fecha,total,id_cliente,id_usuario)
VALUES(GETDATE(), @total, @id_c, @id_us)

-- procedimiento almacenado para registro de detalle producto
GO
ALTER PROC registrar_detalle(@cant INT,
    @idp INT)
AS
DECLARE @idv INT
SELECT @idv=max(id_venta)
FROM venta
INSERT INTO detatalle_venta
    (cantidad,id_venta,id_producto)
VALUES(@cant, @idv, @idp)
UPDATE producto SET stock=stock-@cant
WHERE id_producto=@idp
-- verificamos

SELECT *
FROM venta
SELECT *
FROM detatalle_venta
SELECT *
FROM producto