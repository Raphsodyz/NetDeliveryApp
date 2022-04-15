using Microsoft.AspNetCore.Identity;
using NetDeliveryAppDominio.Entidades;
using System.ComponentModel.DataAnnotations;


namespace NetDeliveryAppDominio.Identity.Usuarios
{
    public class Usuario : IdentityUser<int>
    {
        public override string UserName { get; set; }
        public virtual string PhoneNumber { get; set; }
        public override string Email { get; set; }
        public override string PasswordHash { get; set; }
        public string? Foto { get; set; } = null!;
        public int? EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
        public List<UsuarioTipo> UsuariosTipo { get; set; }
    }
}
