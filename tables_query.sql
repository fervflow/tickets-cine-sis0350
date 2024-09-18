SELECT * FROM persona
SELECT * FROM usuario
GO

-- USUARIOS
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

-- PROVEEDORES
SELECT *
FROM proveedor