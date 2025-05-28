using Asp_servicio.Controllers;
using lib_aplicaciones.Implementaciones;
using lib_aplicaciones.Interfaces;
using Lib_dominio.Entidades;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.AspNetCore.Server.Kestrel.Core;
namespace asp_servicios
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public static IConfiguration? Configuration { set; get; }
        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection services)
        {
            services.Configure<KestrelServerOptions>(x => {
                x.AllowSynchronousIO =
           true;
            });
            services.Configure<IISServerOptions>(x => {
                x.AllowSynchronousIO = true;
            });
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            //services.AddSwaggerGen();
            // Repositorios
            services.AddScoped<IConexion, Conexion>();
            // Aplicaciones
            services.AddScoped<ISedesAplicacion, SedesAplicacion>();
            services.AddScoped<IInscripcionesAplicacion, InscripcionesAplicacion>();
            services.AddScoped<IEstados_InscripcionesAplicacion, Estados_InscripcionesAplicacion>();
            services.AddScoped<IEstados_pagosAplicacion, Estados_pagosAplicacion>();
            services.AddScoped<IObservacionesAplicacion, ObservacionesAplicacion>();
            services.AddScoped<IPagosAplicacion, PagosAplicacion>();
            services.AddScoped<IPersonasAplicacion, PersonasAplicacion>();
            services.AddScoped<IPlanes_SedesAplicacion, Planes_SedesAplicacion>();
            services.AddScoped<IPlanesAplicacion, PlanesAplicacion>();
            services.AddScoped<IAuditoriaAplicacion, AuditoriaAplicacion>();
            services.AddScoped<IUsuariosAplicacion, UsuariosAplicacion>();
            services.AddScoped<IRolesAplicacion, RolesAplicacion>();
            services.AddScoped<IEmpleadosAplicacion, EmpleadosAplicacion>();
            services.AddScoped<IPermisosAplicacion, PermisosAplicacion>();
            services.AddScoped<IRoles_PermisosAplicacion, Roles_PermisosAplicacion>();

            // Controladores
            services.AddScoped<TokenController, TokenController>();
            services.AddCors(o => o.AddDefaultPolicy(b => b.AllowAnyOrigin()));
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseSwagger();
                //app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
            app.UseRouting();
            app.UseCors();
        }
    }
}