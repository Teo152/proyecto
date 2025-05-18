
using Lib_dominio.Entidades;
namespace ut_presentacion.Nucleo
{
    public class EntidadesNucleo
    {
        public static Planes? Planes()
        {
            var entidad = new Planes();

            entidad.nombre = " Plan Gold";
            entidad.detalle = "Acceso a todas las sedes, entrenadores personalizados y derecho a 2 invitados por mes.";
            entidad.precio = 100000.00M; ;


            return entidad;
        }

        public static Sedes? Sedes()
        {
            var entidad = new Sedes();

            entidad.nombre = "Florida";
            entidad.direccion="calle 23 55";


            return entidad;
        }

        public static Estados_pagos? Estados_pagos()
        {
            var entidad = new Estados_pagos();

            entidad.estado = "Pagado";
            entidad.metodo_pago = "Efectivo";


            return entidad;
        }

        public static Estados_Inscripciones? Estados_Inscripciones()
        {
            var entidad = new Estados_Inscripciones();

            entidad.estado = "Inscrito";
            entidad.descripcion = "Usuario con acceso activo";


            return entidad;
        }

        public static Planes_Sedes? Planes_Sedes()
        {
            var entidad = new Planes_Sedes();
            entidad.tipo_acceso = "Todas";
            entidad.sedes = 1;
            entidad.planes = 1;
           

            return entidad;
        }

        public static Personas? Personas()
        {
            var entidad = new Personas();
            entidad.nombre = "Juan Pérez";
            entidad.cedula = 1234567890;
            entidad.telefono = 2345432;
            entidad.email = "juan.perez@example.com";
            entidad.planes = 1;


            return entidad;
        }

        public static Inscripciones? Inscripciones()
        {
            var entidad = new Inscripciones();
            entidad.personas = 1;
            entidad.estados_inscripciones = 1;
            entidad.planes_sedes = 1 ;
            entidad.fecha_inscripcion = DateTime.Now;
            entidad.fecha_vencimiento = DateTime.Now.AddMonths(1);
            return entidad;
        }

        public static Pagos? Pagos()
        {
            var entidad = new Pagos();
            entidad.inscripciones = 1;
            entidad.estados_pagos= 1;
            entidad.monto = 70000;
            entidad.fecha_pago = new DateTime(2025, 4, 15);


            return entidad;
        }

        public static Observaciones? Observaciones()
        {
            var entidad = new Observaciones();
            entidad.inscripciones = 1;
            entidad.descripcion = "Inscripción completada.";


            return entidad;
        }



    }
}
