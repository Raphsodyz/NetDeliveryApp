using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDeliveryAppDominio.Identity.Usuarios
{
    public class UsuarioTipo : IdentityUserRole<int>
    {
        public Usuario Usuario { get; set; }
        public Tipos Tipo { get; set; }
    }
}
