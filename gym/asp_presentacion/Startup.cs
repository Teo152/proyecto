using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace asp_presentacion
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
            // Presentaciones
            services.AddScoped<IPlanesPresentacion, PlanesPresentacion>();
            services.AddScoped<ISedesPresentacion, SedesPresentacion>();
            services.AddScoped<IEstados_InscripcionesPresentacion, Estados_InscripcionesPresentacion>();
            services.AddScoped<IEstados_pagosPresentacion, Estados_pagosPresentacion>();
            services.AddScoped<IPersonasPresentacion, PersonasPresentacion>();
            services.AddScoped<IPlanes_SedesPresentacion, Planes_SedesPresentacion>();
            services.AddScoped<IInscripcionesPresentacion, InscripcionesPresentacion>();
            services.AddScoped<IObservacionesPresentacion, ObservacionesPresentacion>();
            services.AddScoped<IEmpleadosPresentacion, EmpleadosPresentacion>();
            services.AddScoped<IRolesPresentacion, RolesPresentacion>();
            services.AddScoped<IPermisosPresentacion, PermisosPresentacion>();
            services.AddScoped<IRoles_PermisosPresentacion, Roles_PermisosPresentacion>();
            services.AddScoped<IUsuariosPresentacion, UsuariosPresentacion>();
         

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddRazorPages();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();
            app.UseSession();
            app.Run();
        }
    }
}
