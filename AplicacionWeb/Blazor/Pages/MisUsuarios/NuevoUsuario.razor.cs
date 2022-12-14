using Blazor.Interfaces;
using Microsoft.AspNetCore.Components;
using Modelos;
using CurrieTechnologies.Razor.SweetAlert2;

namespace Blazor.Pages.MisUsuarios
{
    public partial class NuevoUsuario
    {
        [Inject] private IUsuarioServicio usuarioServicio { get; set; }

        [Inject] private NavigationManager navigationManager { get; set; }
        private Usuario user = new Usuario();

        [Inject] SweetAlertService swal { get; set; }

        protected async void Guardar()
        {
            if (string.IsNullOrEmpty(user.Codigo) || string.IsNullOrEmpty(user.Nombre) || string.IsNullOrEmpty(user.Clave) 
                || string.IsNullOrEmpty(user.Rol) || user.Rol=="Seleccionar")
            {
                return;
            }
            bool inserto = await usuarioServicio.Nuevo(user);

            if (inserto)
            {
                await swal.FireAsync("Felicidades", "Usuario Guardado Correctamente", SweetAlertIcon.Success);
            }
            else
            {
                await swal.FireAsync("Error", "Usuario no se pudo Guardar", SweetAlertIcon.Warning);
            }

            navigationManager.NavigateTo("/Usuarios");
        }
        protected void Cancelar()
        {
            navigationManager.NavigateTo("/Usuarios");
        }
    }
}
enum Roles
{
    Seleccionar,
    Administrador,
    Usuario
}
