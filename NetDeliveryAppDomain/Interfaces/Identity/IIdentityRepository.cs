﻿using Microsoft.AspNetCore.Identity;
using NetDeliveryAppDominio.Identity.Usuarios;

namespace NetDeliveryAppDominio.Interfaces.Identity
{
    public interface IIdentityRepository
    {
        Task<IdentityResult> Registrar(Usuario usuario);
        Task<Usuario> UsuarioExiste(string email);
        Task<SignInResult> Login(Usuario usuario, string senha);
        Usuario EmailNormalizado(Usuario usuario);
        Task<string> JWT(Usuario usuario);
        Task<IdentityResult> ResetarSenha(Usuario usuario, string otp, string novaSenha);
        Task OTPEmail(Usuario usuario, string email);
    }
}
