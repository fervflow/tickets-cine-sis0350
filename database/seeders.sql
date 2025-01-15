USE tickets_cine;

-- Carga de datos iniciales
INSERT INTO Persona
VALUES
    ('1234 PO', 'Erick Fernando Velasco Flores'),
    ('2345 OR', 'Ani Melon'),
    ('333 CBB', 'Mar Apollo Guerrero'),
    ('444 AR', 'Nicki Nicole'),
    ('555 CO', 'Test Foo')
GO

INSERT INTO Usuario
VALUES
    (1, 'erick', ENCRYPTBYPASSPHRASE('upds', '123'), 'ADMINISTRADOR', 1),
    (2, 'anime', ENCRYPTBYPASSPHRASE('upds', 'anime'), 'VENDEDOR', 1),
    (5, 'test', ENCRYPTBYPASSPHRASE('upds', 'test'), 'VENDEDOR', 1)
GO

INSERT INTO Cliente
VALUES
    (3),
    (4)
GO

