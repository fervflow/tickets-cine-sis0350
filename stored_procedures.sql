--creacion de los procedimientos almacenados

-- procedimiento almacenado para insertar proveedor
CREATE PROC insertar_proveedor
    (@nom VARCHAR(30),
    @cel VARCHAR(20),
    @nit VARCHAR(20),
    @dir VARCHAR(30),
    @ciu VARCHAR(20))
AS
INSERT INTO proveedor
    (nombre,telefono,nit,direccion,ciudad)
VALUES(@nom, @cel, @nit, @dir, @ciu)
-- verificamos 
SELECT*
FROM proveedor
-- procedimiento almacenado para listar proveedores
GO
CREATE PROC listar_proveedor
AS
SELECT *
FROM proveedor
-- procedimiento almacenado para modificar proveedor
GO
CREATE PROC modificar_proveedor
    (@nom VARCHAR(30),
    @cel VARCHAR(20),
    @nit VARCHAR(20),
    @dir VARCHAR(30),
    @ciu VARCHAR(20),
    @id_pro INT)
AS
UPDATE proveedor SET nombre=@nom,telefono=@cel,nit=@nit,direccion=@dir,ciudad=@ciu
WHERE id_proveedor=@id_pro
--- ´probamos
SELECT *
FROM proveedor
-- procedimiento almacenado para buscar proveedor
GO
CREATE PROC buscar_proveedor(@nom VARCHAR(30))
AS
SELECT *
FROM proveedor
WHERE nombre LIKE '%'+@nom+'%'
GO

-- PROCEDIMIENTO ALMACENADO PARA INSERTAR USUARIO
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

-- verificamos usuario
SELECT*
FROM persona
SELECT *
FROM usuario
GO

-- procediemiento almacenado para lista usuarios
CREATE PROC listar_usuarios
AS
SELECT p.id_persona, p.nombre, p.ap_paterno, p.ap_materno, p.ci, u.nombre_usuario, CONVERT(VARCHAR(30),DECRYPTBYPASSPHRASE('upds2024',u.pass)) AS contraseña, u.tipo, u.estado
FROM persona p INNER JOIN usuario u
    ON p.id_persona=u.id_usuario
-- procedimiento para modificar usuaro
GO
ALTER PROC modificar_usuario
    @ci VARCHAR(20),
    @nom VARCHAR(30),
    @ap_paterno VARCHAR(30),
    @ap_materno VARCHAR(30),
    @usuario VARCHAR(30),
    @pass VARCHAR(30),
    @tipo VARCHAR(15),
    @id_us INT
AS
DECLARE @error INT
BEGIN TRAN
UPDATE persona SET nombre=@nom,ap_paterno=@ap_paterno,ap_materno=@ap_materno,ci=@ci
WHERE id_persona=@id_us
SET @error=@@ERROR
IF(@error<>0)
ROLLBACK TRAN
ELSE
BEGIN
    UPDATE usuario SET nombre_usuario=@usuario,pass=ENCRYPTBYPASSPHRASE('upds2024',@pass),tipo=@tipo
WHERE id_usuario=@id_us
    COMMIT TRAN
END
-- procedimiento almacenado para dar de baja usuario
GO
ALTER PROC baja_usuarios(@id_us INT,
    @est VARCHAR(20))
AS
IF(@est='BAJA')
UPDATE usuario SET estado='BAJA' WHERE id_usuario=@id_us
ELSE
UPDATE usuario SET estado='ACTIVO'WHERE id_usuario=@id_us
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