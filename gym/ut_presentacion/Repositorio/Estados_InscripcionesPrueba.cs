using Lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion;

[TestClass]
public class Estados_InscripcionesPrueba
{
    private readonly IConexion? iConexion;
    private List<Estados_Inscripciones>? lista;
    private Estados_Inscripciones? entidad;

    public Estados_InscripcionesPrueba()
    {
        iConexion = new Conexion();
        iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");


    }

    [TestMethod]
    public void Ejecutar()
    {
        Assert.AreEqual(true, Guardar());
        Assert.AreEqual(true, Modificar());
        Assert.AreEqual(true, Listar());
        Assert.AreEqual(true, Borrar());
    }

    public bool Listar()
    {
        this.lista = this.iConexion!.Estados_Inscripciones!.ToList();
        return lista.Count > 0;
    }



    public bool Guardar()
    {
        this.entidad = EntidadesNucleo.Estados_Inscripciones()!;
        this.iConexion!.Estados_Inscripciones!.Add(this.entidad);
        this.iConexion!.SaveChanges();
        return true;
    }

    public bool Modificar()
    {
        this.entidad!.descripcion = "Inscripción pendiente de verificación";

        var entry = this.iConexion!.Entry<Estados_Inscripciones>(this.entidad);
        entry.State = EntityState.Modified;
        this.iConexion!.SaveChanges();
        return true;
    }

    public bool Borrar()
    {
        this.iConexion!.Estados_Inscripciones!.Remove(this.entidad!);
        this.iConexion!.SaveChanges();
        return true;
    }
}

