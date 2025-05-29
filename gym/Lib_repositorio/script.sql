CREATE DATABASE db_gym1;
GO
 
USE db_gym1;
GO
 
-- TABLAS PRINCIPALES -----------------------------------------
 
CREATE TABLE [Planes] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nombre] NVARCHAR(50) NOT NULL,
	[Precio] DECIMAL(10,2) NOT NULL,
	[Detalle] NVARCHAR(200)
);
 
CREATE TABLE [Sedes] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nombre] NVARCHAR(50) NOT NULL,
	[direccion] NVARCHAR(50)
);
 
CREATE TABLE [Estados_pagos] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[estado] NVARCHAR(50) NOT NULL,
	[metodo_pago] NVARCHAR(50)
);
 
CREATE TABLE [Estados_Inscripciones] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[estado] NVARCHAR(50) NOT NULL,
	[descripcion] NVARCHAR(50)
);
 
CREATE TABLE [Planes_Sedes] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[sedes] INT REFERENCES [Sedes]([Id]),
	[planes] INT REFERENCES [Planes]([Id]),
	[tipo_acceso] NVARCHAR(50)
);
 
CREATE TABLE [Personas] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[nombre] NVARCHAR(50),
	[cedula] INT,
	[telefono] INT,
	[email] NVARCHAR(50),
	[planes] INT NULL REFERENCES [Planes]([Id])
);
 
CREATE TABLE [Inscripciones] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[codigo] NVARCHAR(50),
	[personas] INT REFERENCES [Personas]([Id]),
	[planes_sedes] INT NULL REFERENCES [Planes_Sedes]([Id]),
	[Estados_Inscripciones] INT REFERENCES [Estados_Inscripciones]([Id]),
	[fecha_inscripcion] DATETIME,
	[fecha_vencimiento] DATETIME NULL
);
 
CREATE TABLE [Pagos] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[codigo] NVARCHAR(50),
	[inscripciones] INT REFERENCES [Inscripciones]([Id]),
	[Estados_Pagos] INT REFERENCES [Estados_pagos]([Id]),
	[monto] DECIMAL(10,2),
	[fecha_pago] DATETIME NULL
);
 
CREATE TABLE [Observaciones] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[inscripciones] INT REFERENCES [Inscripciones]([Id]),
	[descripcion] NVARCHAR(50)
);
 
CREATE TABLE [Empleados] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[cedula] INT NOT NULL,
	[Nombre] NVARCHAR(50) NOT NULL,
	[sedes] INT REFERENCES [Sedes]([Id])
);
 
-- NUEVAS TABLAS DE SEGURIDAD ---------------------------------
 
CREATE TABLE [Roles] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nombre] NVARCHAR(50)
);
 
CREATE TABLE [Permisos] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nombre] NVARCHAR(50)
);
 
CREATE TABLE [Usuarios] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[NombreUsuario] NVARCHAR(50),
	[Contrasena] NVARCHAR(50),
	[Rol] INT REFERENCES [Roles]([Id])
);
 
CREATE TABLE [Roles_Permisos] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[codigo] NVARCHAR(50),
	[Rol] INT REFERENCES [Roles]([Id]),
	[Permiso] INT REFERENCES [Permisos]([Id])
);
 
CREATE TABLE [Auditoria] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Usuario] INT REFERENCES [Usuarios]([Id]),
	[FechaHora] DATETIME,
	[Accion] NVARCHAR(100)
);
 
-- INSERTS -----------------------------------------------------
 
-- PLANES
INSERT INTO [Planes] ([Nombre],[Precio],[Detalle])
VALUES 
('Plan Premium',90000.00,'Acceso a todas las sedes,entrenadores,derecho a 2 invitados por mes.'),
('Plan Básico',70000.00, 'Acceso limitado a ciertas sedes,sin derecho a invitados.');
 
-- SEDES
INSERT INTO [Sedes] ([Nombre],[direccion])
VALUES 
('Medellin','calle 123 # 45-67'),
('Bello','carrera 56 # 12-34'),
('Sabaneta','avenida 78 # 90-12');
 
-- ESTADOS DE PAGO
INSERT INTO [Estados_pagos] ([estado],[metodo_pago])
VALUES 
('Pagado','Tarjeta'),
('Pendiente','Efectivo'),
('No aplica','No aplica');
 
-- ESTADOS DE INSCRIPCIÓN
INSERT INTO [Estados_Inscripciones] ([estado],[descripcion])
VALUES 
('Inscrito','Usuario con acceso activo'),
('Invitado','Acceso temporal'),
('Cancelado','Inscripción anulada');
 
-- PLANES_SEDES
INSERT INTO [Planes_Sedes] ([sedes],[planes], [tipo_acceso])
VALUES 
(1,1,'Todas'),
(2,1,'Todas'),
(2,2,'Limitada'),
(3,2,'Limitada');
 
-- PERSONAS
INSERT INTO [Personas] ([nombre],[cedula], [telefono],[email],[planes])
VALUES 
('juan', 10001234, 30012345,'juan@emqail.com',1),
('maria', 10009876, 30198765,'maria@emqail.com',2),
('carlos', 10004567, 30234567,'carlos@emqail.com',NULL),
('ana', 10006789, 30345678,'ana@emqail.com',1),
('pedro', 10002345, 30456789,'pedro@emqail.com',1);
 
-- INSCRIPCIONES
INSERT INTO [Inscripciones] ([personas],[codigo], [planes_Sedes],[estados_inscripciones],[fecha_inscripcion],[fecha_vencimiento])
VALUES 
(1,'i1',1,1,'2025-01-01','2025-06-03'),
(2,'i2',3,1,'2025-02-10','2025-10-07'),
(3,'i3',NULL,2,'2025-01-01',NULL),
(4,'i4',2,1,'2025-01-10','2025-07-10'),
(5,'i5',4,3,'2025-04-01',NULL);
 
-- PAGOS
INSERT INTO [Pagos] ([inscripciones],[codigo], [Estados_Pagos],[monto],[fecha_pago])
VALUES 
(1,'m1',1,90000.00,'2025-02-02'),
(2,'m2',2,70000.00,NULL),
(3,'m3',3,0,NULL),
(3,'m4',1,90000.00,'2025-12-12'),
(5,'m5',2,0,NULL);
 
-- OBSERVACIONES
INSERT INTO [Observaciones] ([inscripciones], [descripcion])
VALUES 
(1,'sin novedades'),
(2,'pago pendiente'),
(3,'acceso limitado'),
(3,'renovacion proxima'),
(5,'cancelo');
 
-- EMPLEADOS
INSERT INTO [Empleados] ([cedula], [nombre], [sedes])
VALUES 
(1234,'Alejandro',1),
(3214,'Estefania',2),
(5678,'Sara',3);
 
INSERT INTO Roles (Nombre) VALUES ('Admin'), ('Empleado');
INSERT INTO Permisos (Nombre) VALUES ('Crear'), ('Leer'), ('Actualizar'), ('Eliminar');
INSERT INTO Usuarios (NombreUsuario, Contrasena, Rol) VALUES ('admin', '1234', 1);
INSERT INTO Roles_Permisos (Rol, Permiso,codigo) VALUES (1,1,'1'), (1,2,'22');
INSERT INTO Auditoria (Usuario, FechaHora, Accion) VALUES (1, GETDATE(), 'Inicio de sesión');
 
select * from Pagos
select * from roles
select * from permisos