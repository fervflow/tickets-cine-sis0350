USE tickets_cine;

-- Carga de datos iniciales
INSERT INTO Persona
VALUES
    ('1234 PO', 'Erick Fernando Velasco Flores'),
    ('2345 OR', 'Ani Melon'),
    ('333 CBB', 'Mar Apollo Guerrero'),
    ('444 AR', 'Nicki Nicole'),
    ('555 CO', 'Test Foo');
GO

INSERT INTO Usuario
VALUES
    (1, 'erick', ENCRYPTBYPASSPHRASE('upds', '123'), 'ADMINISTRADOR', 1),
    (2, 'anime', ENCRYPTBYPASSPHRASE('upds', 'anime'), 'VENDEDOR', 1),
    (5, 'test', ENCRYPTBYPASSPHRASE('upds', 'test'), 'VENDEDOR', 1);
GO

INSERT INTO Cliente
VALUES
    (3),
    (4);
GO

INSERT into Salas
VALUES
    (24, 22, 3),
    (20, 12, 1);
GO

INSERT INTO Peliculas
VALUES
    ('Interestelar', '169', 'Ciencia Ficción', 'PG-13'),
    ('Sueño de Fuga', '142', 'Drama', 'R'),
    ('El Rey León', '88', 'Animación', 'G'),
    ('Parásitos', '132', 'Suspenso', 'R'),
    ('El Caballero de la Noche', '152', 'Acción', 'PG-13'),
    ('El Viaje de Chihiro', '125', 'Fantasía', 'PG');
GO

INSERT INTO Horarios
VALUES
    -- Película 1: Interestelar
    (1, 1, CAST( GETDATE() AS DATE ), '14:30', 45.0),
    (1, 1, CAST( GETDATE() AS DATE ), '18:30', 45.0),
    (1, 1, CAST( GETDATE() AS DATE ), '22:30', 45.0),
    -- Película 2: Sueño de Fuga
    (1, 2, CAST( GETDATE() AS DATE ), '15:00', 50.0),
    (1, 2, CAST( GETDATE() AS DATE ), '19:00', 50.0),
    (1, 2, CAST( GETDATE() AS DATE ), '23:00', 50.0),
    -- Película 3: El Rey León
    (1, 3, CAST( GETDATE() AS DATE ), '10:30', 40.0),
    (1, 3, CAST( GETDATE() AS DATE ), '14:30', 40.0),
    (1, 3, CAST( GETDATE() AS DATE ), '18:30', 40.0),
    -- Película 4: Parásitos
    (2, 4, CAST( GETDATE() AS DATE ), '13:00', 55.0),
    (2, 4, CAST( GETDATE() AS DATE ), '17:00', 55.0),
    (2, 4, CAST( GETDATE() AS DATE ), '21:00', 55.0),
    -- Película 5: El Caballero de la Noche
    (2, 5, CAST( GETDATE() AS DATE ), '12:00', 60.0),
    (2, 5, CAST( GETDATE() AS DATE ), '16:00', 60.0),
    (2, 5, CAST( GETDATE() AS DATE ), '20:00', 60.0),
    -- Película 6: El Viaje de Chihiro
    (2, 6, CAST( GETDATE() AS DATE ), '11:30', 45.0),
    (2, 6, CAST( GETDATE() AS DATE ), '15:30', 45.0),
    (2, 6, CAST( GETDATE() AS DATE ), '19:30', 45.0);
GO

-- INSERTAR ASIENTOS de la SALA 1
EXEC sp_insertar_asientos_sala @sala_id = 1;

-- INSERTAR ASIENTOS de la SALA 2
EXEC sp_insertar_asientos_sala @sala_id = 2;
GO

