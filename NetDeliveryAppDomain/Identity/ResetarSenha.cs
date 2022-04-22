using Microsoft.AspNetCore.Identity;
using NetDeliveryAppDominio.Identity.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDeliveryAppDominio.Identity
{
    public class ResetarSenha
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string OTP { get; set; }
        public DateTime Data { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
