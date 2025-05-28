
using Lib_dominio.Entidades;
namespace ut_presentacion.Nucleo
{
    public class EntidadesNucleo
    {
        public static Planes? Planes()
        {
            return new Planes
            {
                nombre = "Plan Gold",
                detalle = "Acceso a todas las sedes, entrenadores personalizados y derecho a 2 invitados por mes.",
                precio = 100000.00M
            };
        }

        public static Sedes? Sedes()
        {
            return new Sedes
            {
                nombre = "Florida",
                direccion = "Calle 23 #55"
            };
        }

        public static Estados_pagos? Estados_pagos()
        {
            return new Estados_pagos
            {
                estado = "Pagado",
                metodo_pago = "Efectivo"
            };
        }

        public static Estados_Inscripciones? Estados_Inscripciones()
        {
            return new Estados_Inscripciones
            {
                estado = "Inscrito",
                descripcion = "Usuario con acceso activo"
            };
        }

        public static Planes_Sedes? Planes_Sedes()
        {
            return new Planes_Sedes
            {
                tipo_acceso = "Todas",
                sedes = 1,
                planes = 1
            };
        }

        public static Personas? Personas()
        {
            return new Personas
            {
                nombre = "Juan Pérez",
                cedula = 1234567890,
                telefono = 2345432,
                email = "juan.perez@example.com",
                planes = 1
            };
        }

        public static Inscripciones? Inscripciones()
        {
            return new Inscripciones
            {
             
                personas = 1,
                estados_inscripciones = 1,
                planes_sedes = 1,
                fecha_inscripcion = DateTime.Now,
                fecha_vencimiento = DateTime.Now.AddMonths(1)
            };
        }

        public static Pagos? Pagos()
        {
            return new Pagos
            {
                inscripciones = 1,
                estados_pagos = 1,
                monto = 70000,
                fecha_pago = new DateTime(2025, 4, 15)
            };
        }

        public static Observaciones? Observaciones()
        {
            return new Observaciones
            {
                inscripciones = 1,
                descripcion = "Inscripción completada."
            };
        }

        //  Seguridad y gestión de usuarios
        public static Roles? Roles()
        {
            return new Roles
            {
                Nombre = "Administrador"
            };
        }

        public static Permisos? Permisos()
        {
            return new Permisos
            {
                Nombre = "AccesoPanelControl"
            };
        }

        public static Roles_Permisos? Roles_Permisos()
        {
            return new Roles_Permisos
            {
                Rol = 1,
                Permiso = 1
            };
        }

        public static Usuarios? Usuarios()
        {
            return new Usuarios
            {
                NombreUsuario = "admin1",
                Contrasena = "123456",
                Rol = 1
            };
        }

        public static Empleados? Empleados()
        {
            return new Empleados
            {
                cedula = 11223344,
                nombre = "Carlos López",
                sedes = 1
            };
        }

        public static Auditoria? Auditoria()
        {
            return new Auditoria
            {
                Usuario = 1,
                FechaHora = DateTime.Now,
                Accion = "Creación de usuario"
            };
        }
    }
}
