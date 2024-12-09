CREATE DATABASE BDTEST
GO
use BDTEST
GO

CREATE TABLE EntidadGubernamental
(
nId int identity primary key,
cDescripcion VARCHAR(150),
dFechaRegistro DATETIME,
dFechaActualizacion DATETIME,
bEstado BIT
)

GO
