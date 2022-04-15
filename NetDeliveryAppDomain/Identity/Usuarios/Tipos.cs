using Microsoft.AspNetCore.Identity;

namespace NetDeliveryAppDominio.Identity.Usuarios
{
    public class Tipos : IdentityRole<int>
    {
        public List<UsuarioTipo> UsuariosTipo { get; set; }
    }
}
