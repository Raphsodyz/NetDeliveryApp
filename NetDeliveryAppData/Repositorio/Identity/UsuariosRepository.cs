using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using NetDeliveryAppDominio.Identity.Usuarios;
using NetDeliveryAppDominio.Interfaces.Identity;
using NetDeliveryAppDominio.Interfaces.Repositorios;

namespace NetDeliveryAppData.Repositorio.Identity
{
    public class UsuariosRepository : IdentityRepository, IUsuarioRepository
    {
        public UsuariosRepository(IConfiguration configuration,
                                  UserManager<Usuario> userManager,
                                  SignInManager<Usuario> signInManager,
                                  IEmailSender emailSender,
                                  IResetarSenhaRepository resetarSenhaRepository) :
            base(configuration, userManager, signInManager, emailSender, resetarSenhaRepository)
        {

        }
    }
}
