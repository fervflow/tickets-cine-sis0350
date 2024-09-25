USE master;
GO
USE upds_ventas;
GO

--USUARIOS
--
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

-- EXEC dbo.sp_modificar_usuario 2, '12129090 CBB', 'nando', 'Vel', 'Flowers', 'fervflow', 'asd', 'VENDEDOR', 1;
-- GO

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

-- REPORTES
-- reporte de productos con sus proveedores
--
CREATE OR ALTER PROC sp_reporte_producto
AS
SELECT
    pro.nombre,
    pro.stock,
    pro.precio_venta,
    prove.nombre AS proveedor,
    prove.ciudad,
    pro.estado
FROM producto pro INNER JOIN proveedor prove
    ON pro.id_proveedor=prove.id_proveedor
ORDER BY proveedor
GO

CREATE OR ALTER PROC sp_reporte_clientes
AS
SELECT
    p.ci,
    c.nit,
    p.nombre,
    p.ap_paterno,
    p.ap_materno
FROM cliente c INNER JOIN persona p
    ON c.id_cliente = p.id_persona
GO

CREATE OR ALTER PROC sp_reporte_usuarios
AS
SELECT
    p.ci,
    p.nombre,
    p.ap_paterno,
    p.ap_materno,
    u.nombre_usuario,
    u.tipo,
    u.estado
FROM persona p INNER JOIN usuario u
    ON p.id_persona=u.id_usuario
GO

CREATE OR ALTER PROC sp_reporte_proveedores
AS
SELECT nit, nombre, direccion, telefono, ciudad
FROM proveedor
GO

-- REPORTE VENTA
-- CREATE OR ALTER PROC sp_registrar_venta

CREATE OR ALTER PROC sp_reporte_venta
    @id_venta INT
AS
BEGIN
    SELECT 
        v.id_venta,
        v.fecha,
        v.total,
        
        c.nit AS cliente_nit,
        p_cliente.ci AS cliente_ci,
        p_cliente.nombre AS cliente_nombre,
        p_cliente.ap_paterno AS cliente_ap_paterno,
        p_cliente.ap_materno AS cliente_ap_materno,
        
        u.nombre_usuario AS usuario_nombre,
        p_usuario.ci AS usuario_ci,
        p_usuario.nombre AS usuario_nombre_real,
        p_usuario.ap_paterno AS usuario_ap_paterno,
        p_usuario.ap_materno AS usuario_ap_materno,
        
        dv.id_detalle_venta,
        dv.id_producto,
        dv.cantidad,
        dv.sub_total
    FROM venta v
    INNER JOIN cliente c ON v.id_cliente = c.id_cliente
    INNER JOIN persona p_cliente ON c.id_cliente = p_cliente.id_persona
    INNER JOIN usuario u ON v.id_usuario = u.id_usuario
    INNER JOIN persona p_usuario ON u.id_usuario = p_usuario.id_persona
    LEFT JOIN detalle_venta dv ON v.id_venta = dv.id_venta
    WHERE v.id_venta = @id_venta;
END;
GO
    -- REPORTE DE VENTAS
CREATE OR ALTER PROC sp_reporte_ventas
AS
BEGIN
    SELECT 
        v.id_venta,
        v.fecha,
        v.total,
        
        -- Usuario
        u.tipo AS usuario_tipo,
        p_usuario.ci AS usuario_ci,
        p_usuario.nombre AS usuario_nombre,
        p_usuario.ap_paterno AS usuario_ap_paterno,
        p_usuario.ap_materno AS usuario_ap_materno,

        -- Cliente
        c.nit AS cliente_nit,
        p_cliente.nombre AS cliente_nombre,
        p_cliente.ap_paterno AS cliente_ap_paterno,
        p_cliente.ap_materno AS cliente_ap_materno

    FROM venta v
    INNER JOIN cliente c ON v.id_cliente = c.id_cliente
    INNER JOIN persona p_cliente ON c.id_cliente = p_cliente.id_persona
    INNER JOIN usuario u ON v.id_usuario = u.id_usuario
    INNER JOIN persona p_usuario ON u.id_usuario = p_usuario.id_persona;
END;
GO

CREATE OR ALTER PROC sp_reporte_detalle_venta
    @id_venta INT
AS
BEGIN
    SELECT 
        dv.id_detalle_venta,
        dv.id_producto,
        p.nombre AS nombre_producto,
        p.precio_venta,
        dv.cantidad,
        dv.sub_total
    FROM detalle_venta dv
    INNER JOIN producto p ON dv.id_producto = p.id_producto
    WHERE dv.id_venta = @id_venta;
END;
GO

EXEC sp_reporte_detalle_venta 1;
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

-- REGISTRAR VENTA
CREATE OR ALTER PROC sp_registrar_venta
    @id_ususario INT,
    @id_cliente INT,
    @total DECIMAL(10,2)
AS
INSERT INTO venta
    (fecha,total,id_cliente,id_usuario)
OUTPUT INSERTED.id_venta
VALUES (GETDATE(), @total, @id_cliente, @id_ususario)
GO

-- REGISTRO DETALLE
CREATE OR ALTER PROC sp_registrar_detalle
    @id_venta INT,
    @id_producto INT,
    @cantidad INT,
    @sub_total DECIMAL(10,2)
AS
INSERT INTO detalle_venta
    (id_venta, id_producto, cantidad, sub_total)
VALUES  (@id_venta, @id_producto, @cantidad, @sub_total)
UPDATE producto SET stock=stock-@cantidad
WHERE id_producto=@id_producto
GO

