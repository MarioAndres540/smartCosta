-- Creación de la Base de Datos (Opcional, si no existe)
-- CREATE DATABASE PruebaTecnicaDB;
-- GO
-- USE PruebaTecnicaDB;
-- GO

-- 1. Tabla Usuarios
CREATE TABLE Usuarios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE
);
GO

-- 2. Tabla Publicaciones
CREATE TABLE Publicaciones (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Titulo NVARCHAR(200) NOT NULL,
    Contenido NVARCHAR(MAX) NULL,
    FechaPublicacion DATETIME NOT NULL DEFAULT GETDATE(),
    UsuarioId INT NOT NULL,
    CONSTRAINT FK_Publicaciones_Usuarios FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id)
);
GO

-- Datos de prueba opcionales
INSERT INTO Usuarios (Nombre, Email) VALUES ('Juan Perez', 'juan@example.com');
INSERT INTO Usuarios (Nombre, Email) VALUES ('Maria Lopez', 'maria@example.com');

INSERT INTO Publicaciones (Titulo, Contenido, UsuarioId) VALUES ('Primer Post', 'Contenido del primer post', 1);
INSERT INTO Publicaciones (Titulo, Contenido, UsuarioId) VALUES ('Hola Mundo', 'Bienvenido al blog', 2);
