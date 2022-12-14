using Blazor.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace Blazor.Pages.MisUsuarios
{
    public partial class EditarUsuario
    {
        [Inject] private IUsuarioServicio usuarioServicio { get; set; }

        [Inject] private NavigationManager navigationManager { get; set; }
        private Usuario user = new Usuario();

        [Inject] SweetAlertService swal { get; set; }

        [Parameter] public string Codigo { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (! string.IsNullOrEmpty(Codigo))
            {
                user = await usuarioServicio.GetPorCodigo(Codigo);
            }
        }

        protected async void Guardar()
        {
            if (string.IsNullOrEmpty(user.Codigo) || string.IsNullOrEmpty(user.Nombre) || string.IsNullOrEmpty(user.Clave)
                || string.IsNullOrEmpty(user.Rol) || user.Rol == "Seleccionar")
            {
                return;
            }
            bool edito = await usuarioServicio.Actualizar(user);

            if (edito)
            {
                await swal.FireAsync("Felicidades", "Usuario Actualizado Correctamente", SweetAlertIcon.Success);
            }
            else
            {
                await swal.FireAsync("Error", "Usuario no se pudo Actualizar", SweetAlertIcon.Warning);
            }

            navigationManager.NavigateTo("/Usuarios");
        }
        protected void Cancelar()
        {
            navigationManager.NavigateTo("/Usuarios");
        }
        //Metodo para eliminar 
        protected async void Eliminar()
        {
            bool elimino = false;

            SweetAlertResult result = await swal.FireAsync(new SweetAlertOptions
            {
                Title = "Seguro que desea eliminar el registro",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
                ConfirmButtonText = "Aceptar",
                CancelButtonText = "Cancelar"
            });

            if (! string.IsNullOrEmpty(result.Value))
            {
                elimino = await usuarioServicio.Eliminar(Codigo);

                if (elimino)
                {
                    await swal.FireAsync("Felicidades", "Usuario Eliminado Correctamente", SweetAlertIcon.Success);
                }
                else
                {
                    await swal.FireAsync("Error", "Usuario no se pudo Eliminado", SweetAlertIcon.Warning);
                }
            }
        }
    }
}
