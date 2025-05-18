using Lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion;

[TestClass]
public class ObservacionesPrueba
{
    private readonly IConexion? iConexion;
    private List<Observaciones>? lista;
    private Observaciones? entidad;

    public ObservacionesPrueba()
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
        this.lista = this.iConexion!.Observaciones!.ToList();
        return lista.Count > 0;
    }



    public bool Guardar()
    {
        this.entidad = EntidadesNucleo.Observaciones()!;
        this.iConexion!.Observaciones!.Add(this.entidad);
        this.iConexion!.SaveChanges();
        return true;
    }

    public bool Modificar()
    {
        this.entidad!.descripcion = "Observación modificada sobre la inscripción.";

        var entry = this.iConexion!.Entry<Observaciones>(this.entidad);
        entry.State = EntityState.Modified;
        this.iConexion!.SaveChanges();
        return true;
    }

    public bool Borrar()
    {
        this.iConexion!.Observaciones!.Remove(this.entidad!);
        this.iConexion!.SaveChanges();
        return true;
    }

}
