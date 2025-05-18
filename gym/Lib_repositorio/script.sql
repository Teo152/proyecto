CREATE DATABASE db_gym;
go

USE db_gym;
GO
CREATE TABLE [Planes] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nombre] NVARCHAR(50) NOT NULL,
	[Precio] DECIMAL(10,2) NOT NULL,
	[Detalle] NVARCHAR(200),
);

CREATE TABLE [Sedes](
[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
[Nombre] NVARCHAR(50) NOT NULL,
[direccion] NVARCHAR(50)
);

CREATE TABLE [Estados_pagos](
[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
[estado] NVARCHAR(50) NOT NULL,
[metodo_pago] NVARCHAR(50)
);

CREATE TABLE [Estados_Inscripciones](
[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
[estado] NVARCHAR(50) NOT NULL,
[descripcion] NVARCHAR(50)
);



CREATE TABLE [Planes_Sedes](
[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
[sedes] INT  REFERENCES [Sedes]([id]),
[planes] INT  REFERENCES [planes]([id]),
[tipo_acceso] NVARCHAR(50)

);

CREATE TABLE [Personas](
[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
[nombre] NVARCHAR(50),
[cedula] int,
[telefono] int,
[email] NVARCHAR(50),
[planes] INT NULL REFERENCES [planes]([id] )
);

CREATE TABLE [Inscripciones](
[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
[personas] INT REFERENCES [personas]([id]),
[planes_sedes] INT NULL REFERENCES [planes_sedes]([id] ),
[Estados_Inscripciones] INT REFERENCES [Estados_Inscripciones]([id]),
[fecha_inscripcion] datetime,
[fecha_vencimiento] datetime null
);


CREATE TABLE [Pagos](
[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
[inscripciones] INT REFERENCES [Inscripciones]([id]),
[Estados_Pagos] INT REFERENCES [Estados_Inscripciones]([id]),
[monto] decimal (10,2),
[fecha_pago] datetime null
);


CREATE TABLE [Observaciones] (
[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
[inscripciones] INT REFERENCES [Inscripciones]([id]),
[descripcion] NVARCHAR(50)
);


INSERT INTO [Planes] ([Nombre],[Precio],[Detalle])
VALUES ('Plan Premium',90000.00,'Acceso a todas las sedes,entrenadores,derecho a 2 invitados por mes.');

INSERT INTO [Planes] ([Nombre],[Precio],[Detalle])
VALUES ('Plan Básico',70000.00, 'Acceso limitado a ciertas sedes,sin derecho a invitados.');

SELECT * FROM [Planes];


INSERT INTO [Sedes] ([Nombre],[direccion])
VALUES ('Medellin,','calle 123 # 45-67');
INSERT INTO [Sedes] ([Nombre],[direccion])
VALUES ('Bello,','carrera 56 # 12-34');
INSERT INTO [Sedes] ([Nombre],[direccion])
VALUES ('Sabaneta,','avenida 78 # 90-12');

SELECT * FROM Sedes;




INSERT INTO [Estados_pagos] ([estado],[metodo_pago])
VALUES ('Pagado,','Targeta');
INSERT INTO [Estados_pagos] ([estado],[metodo_pago])
VALUES ('Pendiente,','Efectivo');
INSERT INTO [Estados_pagos] ([estado],[metodo_pago])
VALUES ('No aplica,','No aplica');


select * from Estados_pagos





INSERT INTO [Estados_Inscripciones] ([estado],[descripcion])
VALUES ('Inscrito,','Usuario con acceso activo');
INSERT INTO [Estados_Inscripciones] ([estado],[descripcion])
VALUES ('Invitado,','Ucceso temporal');
INSERT INTO [Estados_Inscripciones] ([estado],[descripcion])
VALUES ('Cancelado,','Inscripcion anulada');

SELECT * FROM [Estados_inscripciones]


INSERT INTO [Planes_Sedes] ([sedes],[planes], [tipo_acceso])
VALUES (1,1,'Todas');
INSERT INTO [Planes_Sedes] ([sedes],[planes], [tipo_acceso])
VALUES (2,1,'Todas');
INSERT INTO [Planes_Sedes] ([sedes],[planes], [tipo_acceso])
VALUES (2,2,'Limitada');
INSERT INTO [Planes_Sedes] ([sedes],[planes], [tipo_acceso])
VALUES (3,2,'Limitada');

SELECT * FROM planes_sedes


INSERT INTO [Personas] ([nombre],[cedula], [telefono],email,planes)
VALUES ('juan', 10001234, 30012345,'juan@emqail.com',1);
INSERT INTO [Personas] ([nombre],[cedula], [telefono],email,planes)
VALUES ('maria', 10009876, 30198765,'maria@emqail.com',2);
INSERT INTO [Personas] ([nombre],[cedula], [telefono],email,planes)
VALUES ('carlos', 10004567, 30234567,'carlos@emqail.com',null);
INSERT INTO [Personas] ([nombre],[cedula], [telefono],email,planes)
VALUES ('ana', 10006789, 30345678,'ana@emqail.com',1);
INSERT INTO [Personas] ([nombre],[cedula], [telefono],email,planes)
VALUES ('pedro', 10002345, 30456789,'pedro@emqail.com',1);

SELECT * FROM Personas






INSERT INTO [Inscripciones] ([personas], [planes_Sedes],[estados_inscripciones],[fecha_inscripcion],[fecha_vencimiento])
VALUES (1,1,1,'2025-01-01','2025-06-03')
INSERT INTO [Inscripciones] ([personas], [planes_Sedes],[estados_inscripciones],[fecha_inscripcion],[fecha_vencimiento])
VALUES (2,3,1,'2025-02-10','2025-10-07')
INSERT INTO [Inscripciones] ([personas], [planes_Sedes],[estados_inscripciones],[fecha_inscripcion],[fecha_vencimiento])
VALUES (3,null,2,'2025-01-01',null)
INSERT INTO [Inscripciones] ([personas], [planes_Sedes],[estados_inscripciones],[fecha_inscripcion],[fecha_vencimiento])
VALUES (4,2,1,'2025-01-10','2025-07-10')
INSERT INTO [Inscripciones] ([personas], [planes_Sedes],[estados_inscripciones],[fecha_inscripcion],[fecha_vencimiento])
VALUES (5,4,3,'2025-04-01',null)

select * from Inscripciones




INSERT INTO [Pagos] ([inscripciones], [Estados_Pagos],[monto],[fecha_pago])
VALUES (1,1,90.000,'2025-02-02')
INSERT INTO [Pagos] ([inscripciones], [Estados_Pagos],[monto],[fecha_pago])
VALUES (2,2,70.000,NULL)
INSERT INTO [Pagos] ([inscripciones], [Estados_Pagos],[monto],[fecha_pago])
VALUES (3,3,0,null)
INSERT INTO [Pagos] ([inscripciones], [Estados_Pagos],[monto],[fecha_pago])
VALUES (3,1,90.000,'2025-12-12')
INSERT INTO [Pagos] ([inscripciones], [Estados_Pagos],[monto],[fecha_pago])
VALUES (5,2,0,null)

SELECT * FROM Pagos







INSERT INTO [Observaciones] ([inscripciones], [descripcion])
VALUES (1,'sin novedades')
INSERT INTO [Observaciones] ([inscripciones], [descripcion])
VALUES (2,'pago pendiente')
INSERT INTO [Observaciones] ([inscripciones], [descripcion])
VALUES (3,'acceso limitado')
INSERT INTO [Observaciones] ([inscripciones], [descripcion])
VALUES (3,'renovacion proxima')
INSERT INTO [Observaciones] ([inscripciones], [descripcion])
VALUES (5,'cancelo')

SELECT* FROM [Observaciones]
