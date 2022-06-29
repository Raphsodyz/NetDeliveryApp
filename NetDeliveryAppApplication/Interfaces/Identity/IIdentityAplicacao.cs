using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using NetDeliveryAppAplicacao.DTOs.IdentityDTO;
using NetDeliveryAppDominio.Identity.Usuarios;

namespace NetDeliveryAppAplicacao.Interfaces.Identity
{
    public interface IIdentityAplicacao
    {
        Task<IdentityResult> Registrar(UsuarioDTO usuario);
        Task<Usuario> UsuarioExiste(string email);
        Task<SignInResult> Login(LoginDTO usuario);
        Usuario EmailNormalizado(LoginDTO usuario);
        Task<string> JWT(Usuario usuario);
        Task<IdentityResult> ResetarSenha(Usuario usuario, string otp, string novaSenha);
        Task OTPEmail(Usuario usuario, string email);
    }
}
