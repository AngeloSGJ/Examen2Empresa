Create DATABASE EMPRESAUTC
GO

USE EMPRESAUTC
GO

CREATE TABLE Usuarios(
    UsuarioID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL,
    CorreoElectronico VARCHAR(50),
    Telefono VARCHAR(15)
)
GO

CREATE TABLE Tecnicos(
    TecnicoID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50),
    Especialidad VARCHAR(50)
)
GO

CREATE TABLE Equipos(
    EquipoID INT PRIMARY KEY IDENTITY(1,1),
    TipoEquipo VARCHAR(50) NOT NULL,
    Modelo VARCHAR(50),
    UsuarioID INT,
    CONSTRAINT fk_equipos_usuarioId FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID)
)
GO

CREATE TABLE Reparaciones(
    ReparacionID INT PRIMARY KEY IDENTITY(1,1),
    EquipoID INT,
    FechaSolicitud DATETIME DEFAULT GETDATE(),
    Estado char(20),
    CONSTRAINT fk_reparaciones_equipoId FOREIGN KEY (EquipoID) REFERENCES Equipos(EquipoID)
)
GO

CREATE TABLE Asignaciones(
    AsignacionID INT PRIMARY KEY IDENTITY(1,1),
    ReparacionID INT,
    TecnicoID INT,
    FechaAsignacion DATETIME DEFAULT GETDATE(),
    CONSTRAINT fk_asignaciones_reparacionId FOREIGN KEY (ReparacionID) REFERENCES Reparaciones(ReparacionID),
    CONSTRAINT fk_asignaciones_tecnicoId FOREIGN KEY (TecnicoID) REFERENCES Tecnicos(TecnicoID)
)
GO

CREATE TABLE DetallesReparacion(
    DetalleID INT PRIMARY KEY IDENTITY(1,1),
    ReparacionID INT,
    Descripcion VARCHAR(50),
    FechaInicio DATETIME DEFAULT GETDATE(),
    FechaFin DATETIME,
    CONSTRAINT fk_detallesReparacion_reparacionId FOREIGN KEY (ReparacionID) REFERENCES Reparaciones(ReparacionID)
)
GO

INSERT INTO Usuarios(Nombre, CorreoElectronico, Telefono) VALUES 
('Angelo', 'angelo@stuart.com', '24540000'), 
('Itan', 'itan@jesus.com', '24541675'), 
('Mateo', 'mateo@daniel.com', '24541095')
GO

INSERT INTO Tecnicos(Nombre, Especialidad) VALUES 
('Alex', 'Reparacion de Hardware'), 
('Benjamin', 'Mantenimiento de computadora')
GO

INSERT INTO Equipos(TipoEquipo, Modelo, UsuarioID) VALUES
('PC Gamer', 'Intel', 1),
('Computadora Portatil', 'VAIO', 2),
('Portatil Gamer', 'MSI', 3)
GO

INSERT INTO Reparaciones(EquipoID, Estado) VALUES
(1, 'En revision'),
(2, 'Listo'),
(3, 'Pendiente')
GO

CREATE PROCEDURE INSERTARREPARACION
@EQUIPOID INT,
@ESTADO INT
AS
    BEGIN
        INSERT INTO REPARACIONES(EQUIPOID, ESTADO) VALUES (@EQUIPOID, @ESTADO)
    END
GO

CREATE PROCEDURE CONSULTARREPARACION_ID
@ID INT
AS
    BEGIN
        SELECT * FROM REPARACIONES WHERE REPARACIONID = @ID
    END
GO

CREATE PROCEDURE BORRARREPARACION_ID
@ID INT
AS
    BEGIN
        DELETE FROM REPARACIONES WHERE REPARACIONID = @ID
    END
GO


CREATE PROCEDURE ACTUALIZARREPARACION_ID
@ID INT,
@EQUIPOID VARCHAR(50),
@FECHASOLICITUD VARCHAR(50),
@ESTADO VARCHAR(15)
AS
    BEGIN
        UPDATE REPARACIONES SET @EQUIPOID = @EQUIPOID, @FECHASOLICITUD = @FECHASOLICITUD, @ESTADO = @ESTADO WHERE REPARACIONID = @ID
    END
GO

INSERT INTO Asignaciones(ReparacionID, TecnicoID) VALUES
(1, 1),
(2, 2),
(3, 1)
GO

CREATE PROCEDURE INSERTARASIGNACION
@ReparacionID INT,
@TecnicoID INT
AS
    BEGIN
        INSERT INTO Asignaciones(ReparacionID, TecnicoID) VALUES (@ReparacionID, @TecnicoID)
    END
GO
CREATE PROCEDURE CONSULTARASINACION_ID
@ID INT
AS
    BEGIN
        SELECT * FROM Asignaciones WHERE AsignacionID = @ID
    END
GO

CREATE PROCEDURE BORRARASIGNACION_ID
@ID INT
AS
    BEGIN
        DELETE FROM Asignaciones WHERE AsignacionID = @ID
    END
GO


CREATE PROCEDURE ACTUALIZARASIGNACION_ID
@ID INT,
@ReparacionID INT,
@TecnicoID INT,
@FECHAASIGNACION VARCHAR(15)
AS
    BEGIN
        UPDATE Asignaciones SET @EQUIPOID = @EQUIPOID, @FECHASOLICITUD = @FECHASOLICITUD, @ESTADO = @ESTADO WHERE ASIGNACIONID = @ID
    END
GO

INSERT INTO DetallesReparacion(ReparacionID, Descripcion) VALUES
(1, 'Limpieza profunda del equipo'),
(2, 'Los fps de la tarjeta gráfica se caen'),
(3, 'Revisión del estado de la batería')
GO

CREATE PROCEDURE CONSULTARUSUARIOS
AS
    BEGIN
        SELECT * FROM Usuarios
    END
GO

CREATE PROCEDURE CONSULTARUSUARIOS_ID
@ID INT
AS
    BEGIN
        SELECT * FROM Usuarios WHERE UsuarioID = @ID
    END
GO

CREATE PROCEDURE BORRARUSUARIOS_ID
@ID INT
AS
    BEGIN
        DELETE FROM Usuarios WHERE UsuarioID = @ID
    END
GO

CREATE PROCEDURE INSERTARUSUARIO
@NOMBRE VARCHAR(50),
@CORREO VARCHAR(50),
@TELEFONO VARCHAR(15)
AS
    BEGIN
        INSERT INTO Usuarios(Nombre, CorreoElectronico, Telefono) VALUES (@NOMBRE, @CORREO, @TELEFONO)
    END
GO

CREATE PROCEDURE ACTUALIZARUSUARIO_ID
@ID INT,
@NOMBRE VARCHAR(50),
@CORREO VARCHAR(50),
@TELEFONO VARCHAR(15)
AS
    BEGIN
        UPDATE Usuarios SET Nombre = @NOMBRE, CorreoElectronico = @CORREO, Telefono = @TELEFONO WHERE UsuarioID = @ID
    END
GO

CREATE PROCEDURE CONSULTARTECNICOS
AS
    BEGIN
        SELECT * FROM Tecnicos
    END
GO

CREATE PROCEDURE CONSULTARTECNICOS_ID
@ID INT
AS
    BEGIN
        SELECT * FROM Tecnicos WHERE TecnicoID = @ID
    END
GO

CREATE PROCEDURE BORRARTECNICOS_ID
@ID INT
AS
    BEGIN
        DELETE FROM Tecnicos WHERE TecnicoID = @ID
    END
GO

CREATE PROCEDURE INSERTARTECNICO
@NOMBRE VARCHAR(50),
@ESPECIALIDAD VARCHAR(50)
AS
    BEGIN
        INSERT INTO Tecnicos(Nombre, Especialidad) VALUES (@NOMBRE, @ESPECIALIDAD)
    END
GO

CREATE PROCEDURE ACTUALIZARTECNICO_ID
@ID INT,
@NOMBRE VARCHAR(50),
@ESPECIALIDAD VARCHAR(50)
AS
    BEGIN
        UPDATE Tecnicos SET Nombre = @NOMBRE, Especialidad = @ESPECIALIDAD WHERE TecnicoID = @ID
    END
GO

CREATE PROCEDURE CONSULTAREQUIPOS
AS
    BEGIN
        SELECT * FROM Equipos
    END
GO

CREATE PROCEDURE CONSULTAREQUIPOS_ID
@ID INT
AS
    BEGIN
        SELECT * FROM Equipos WHERE EquipoID = @ID
    END
GO

CREATE PROCEDURE BORRAREQUIPOS_ID
@ID INT
AS
    BEGIN
        DELETE FROM Equipos WHERE EquipoID = @ID
    END
GO

CREATE PROCEDURE INSERTAREQUIPO
@TIPOEQUIPO VARCHAR(50),
@MODELO VARCHAR(50),
@USUARIOID INT
AS
    BEGIN
        INSERT INTO Equipos(TipoEquipo, Modelo, UsuarioID) VALUES (@TIPOEQUIPO, @MODELO, @USUARIOID)
    END
GO

CREATE PROCEDURE ACTUALIZAREQUIPO_ID
@ID INT,
@TIPOEQUIPO VARCHAR(50),
@MODELO VARCHAR(50),
@USUARIOID INT
AS
    BEGIN
        UPDATE Equipos SET TipoEquipo = @TIPOEQUIPO, Modelo = @MODELO, UsuarioID = @USUARIOID WHERE EquipoID = @ID
    END
GO





SELECT Usuarios.Nombre, Usuarios.Telefono, Equipos.Modelo, Tecnicos.Nombre
from Usuarios
inner join Equipos on Usuarios.UsuarioID = Equipos.UsuarioID
inner join Reparaciones on Reparaciones.EquipoID = Equipos.EquipoID
inner join Asignaciones on Asignaciones.ReparacionID = Reparaciones.ReparacionID
inner join Tecnicos on Tecnicos.TecnicoID = Asignaciones.TecnicoID

Create table Estados 
(
	id CHAR(1) PRIMARY KEY,
	DESCRIPCION VARCHAR(100)
)

CREATE procedure consultaestados
as
  begin
select Descripcion as estado from estados
end 

exec consultaestados

INSERT INTO Estados VALUES('En revicion'),('Listo'),('Pendiente'),('Testeando')