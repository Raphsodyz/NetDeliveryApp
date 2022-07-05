using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using NetDeliveryAppDominio.Identity.Usuarios;
using NetDeliveryAppDominio.Interfaces.Identity;
using NetDeliveryAppDominio.Interfaces.Repositorios;

namespace NetDeliveryAppData.Repositorio.Identity
{
    public abstract class IdentityRepository : IIdentityRepository
    {
        protected readonly IConfiguration _configuration;
        protected readonly UserManager<Usuario> _userManager;
        protected readonly SignInManager<Usuario> _signInManager;
        protected readonly IEmailSender _emailSender;
        protected readonly IResetarSenhaRepository _resetarSenhaRepository;

        public IdentityRepository(IConfiguration configuration,
                                  UserManager<Usuario> userManager,
                                  SignInManager<Usuario> signInManager,
                                  IEmailSender emailSender,
                                  IResetarSenhaRepository resetarSenhaRepository)
        {
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _resetarSenhaRepository = resetarSenhaRepository;
        }

        public async Task<IdentityResult> Registrar(Usuario usuario)
        {
            return await _userManager.CreateAsync(usuario, usuario.PasswordHash);
        }

        public async Task<Usuario> UsuarioExiste(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<SignInResult> Login(Usuario usuario, string senha)
        {
            return await _signInManager.CheckPasswordSignInAsync(usuario, senha, true);
        }

        public Usuario EmailNormalizado(Usuario usuario)
        {
            return _userManager.Users.FirstOrDefault(u => u.NormalizedEmail == usuario.Email.ToUpper());
        }

        public abstract Task<string> JWT(Usuario usuario);
        public abstract Task<IdentityResult> ResetarSenha(Usuario usuario, string otp, string novaSenha);
        public abstract Task OTPEmail(Usuario usuario, string email);
    }
}
