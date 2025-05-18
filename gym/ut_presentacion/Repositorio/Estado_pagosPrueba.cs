using Lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion;

[TestClass]
public class Estado_pagosPrueba
{

    private readonly IConexion? iConexion;
    private List<Estados_pagos>? lista;
    private Estados_pagos? entidad;

    public Estado_pagosPrueba()
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
        this.lista = this.iConexion!.Estados_pagos!.ToList();
        return lista.Count > 0;
    }



    public bool Guardar()
    {
        this.entidad = EntidadesNucleo.Estados_pagos()!;
        this.iConexion!.Estados_pagos!.Add(this.entidad);
        this.iConexion!.SaveChanges();
        return true;
    }

    public bool Modificar()
    {
        this.entidad!.estado = "estado modificado";

        var entry = this.iConexion!.Entry<Estados_pagos>(this.entidad);
        entry.State = EntityState.Modified;
        this.iConexion!.SaveChanges();
        return true;
    }

    public bool Borrar()
    {
        this.iConexion!.Estados_pagos!.Remove(this.entidad!);
        this.iConexion!.SaveChanges();
        return true;
    }
}


