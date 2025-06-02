using lib_dominio.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using lib_presentaciones.Implementaciones;

namespace asp_presentacion.Pages
{
    public class IndexModel : PageModel
    {
        public bool EstaLogueado = false;
        [BindProperty] public string? Email { get; set; }
        [BindProperty] public string? Contrasena { get; set; }

       
        public void OnGet()
        {
            var variable_session = HttpContext.Session.GetString("Usuario");
            if (!String.IsNullOrEmpty(variable_session))
            {
                EstaLogueado = true;
                return;
            }
        }
        public void OnPostBtClean()
        {
            try
            {
                Email = string.Empty;
                Contrasena = string.Empty;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
        public void OnPostBtEnter()
        {
            try
            {
                if (string.IsNullOrEmpty(Email) &&
                string.IsNullOrEmpty(Contrasena))
                {
                    OnPostBtClean();
                    return;
                }
                 if (!validar(Email!,Contrasena!))
                 {
                     OnPostBtClean();
                     return;
                 }
                ViewData["Logged"] = true;
                HttpContext.Session.SetString("Usuario", Email!);
                EstaLogueado = true;
                OnPostBtClean();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
        public void OnPostBtClose()
        {
            try
            {
                HttpContext.Session.Clear();
                HttpContext.Response.Redirect("/");
                EstaLogueado = false;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public bool validar(string email, string contrasena)
        {
            try
            {
                var usariospresentacion = new UsuariosPresentacion();
                var usuarios = usariospresentacion.Listar().Result;
                var usuario = usuarios.FirstOrDefault(u => u.nombreUsuario == email && u.Contrasena == contrasena);

               
                return usuario != null;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                return false;
            }
        }

       
    }
}