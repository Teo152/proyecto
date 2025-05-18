using Lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion;

[TestClass]
public class InscripcionesPrueba
{

    private readonly IConexion? iConexion;
    private List<Inscripciones>? lista;
    private Inscripciones? entidad;

    public InscripcionesPrueba()
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
        this.lista = this.iConexion!.Inscripciones!.ToList();
        return lista.Count > 0;
    }

    public bool Guardar()
    {
        this.entidad = EntidadesNucleo.Inscripciones()!;
        this.iConexion!.Inscripciones!.Add(this.entidad);
        this.iConexion!.SaveChanges();
        return true;
    }

    public bool Modificar()
    {
        this.entidad!.fecha_vencimiento = new DateTime(2025, 5, 15);

        var entry = this.iConexion!.Entry<Inscripciones>(this.entidad);
        entry.State = EntityState.Modified;
        this.iConexion!.SaveChanges();
        return true;
    }

    public bool Borrar()
    {
        this.iConexion!.Inscripciones!.Remove(this.entidad!);
        this.iConexion!.SaveChanges();
        return true;
    }
}
