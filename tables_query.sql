SELECT * FROM persona
SELECT * FROM usuario
GO

-- USUARIOS
    -- Login
EXEC dbo.sp_login 'qwe', 'qwe';
EXEC dbo.sp_obtener_usuario_logueado 'qwe';

UPDATE usuario
SET estado = 1
WHERE id_usuario = 1;

SELECT 1
FROM usuario
WHERE nombre_usuario = 'qwe'
    AND CONVERT(VARCHAR(30), DECRYPTBYPASSPHRASE('upds2024', pass)) = 'qwe'
    AND estado = 1

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
WHERE u.nombre_usuario = 'qwe' AND pass = 'qwe'
GO

-- PROVEEDORES
SELECT *
FROM proveedor

SELECT * FROM producto;