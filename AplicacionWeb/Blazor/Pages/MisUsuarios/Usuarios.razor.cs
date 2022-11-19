using Blazor.Interfaces;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace Blazor.Pages.MisUsuarios
{
    public partial class Usuarios
    {
        //Injeccion de la clase program
        [Inject] private IUsuarioServicio usuarioServicio { get; set; }

        private IEnumerable<Usuario> lista { get; set; }

        protected override async Task OnInitializedAsync()
        {
            lista = await usuarioServicio.GetLista();
        }
    }
}
