using Lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion;

[TestClass]
public class Planes_SedesPrueba
{
    private readonly IConexion? iConexion;
    private List<Planes_Sedes>? lista;
    private Planes_Sedes? entidad;

    public Planes_SedesPrueba()
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
        this.lista = this.iConexion!.Planes_Sedes!.ToList();
        return lista.Count > 0;
    }



    public bool Guardar()
    {
        this.entidad = EntidadesNucleo.Planes_Sedes()!;
        this.iConexion!.Planes_Sedes!.Add(this.entidad);
        this.iConexion!.SaveChanges();
        return true;
    }

    public bool Modificar()
    {
        this.entidad!.tipo_acceso = "Limitado";

        var entry = this.iConexion!.Entry<Planes_Sedes>(this.entidad);
        entry.State = EntityState.Modified;
        this.iConexion!.SaveChanges();
        return true;
    }

    public bool Borrar()
    {
        this.iConexion!.Planes_Sedes!.Remove(this.entidad!);
        this.iConexion!.SaveChanges();
        return true;
    }
}

