using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NetDeliveryAppDominio.Identity;
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

        public async Task<string> JWT(Usuario usuario)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.Email)
            };

            var tipos = await _userManager.GetRolesAsync(usuario);

            foreach (var tipo in tipos)
            {
                claims.Add(new Claim(ClaimTypes.Role, tipo));
            }

            var chave = new SymmetricSecurityKey(Encoding.ASCII
                .GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha512Signature);

            var descricaoToken = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credenciais
            };

            var manipulador = new JwtSecurityTokenHandler();
            var token = manipulador.CreateToken(descricaoToken);

            return manipulador.WriteToken(token);
        }

        public async Task<IdentityResult> ResetarSenha(Usuario usuario, string otp, string novaSenha)
        {
            var detalhes = await _resetarSenhaRepository.ResetarSenhaDetalhes(otp, usuario);
            var token = detalhes.Data.AddMinutes(15);

            if (token < DateTime.Now)
            {
                return IdentityResult.Failed();
            }

            return await _userManager.ResetPasswordAsync(usuario, detalhes.Token, novaSenha);
        }

        public async Task OTPEmail(Usuario usuario, string email)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(usuario);
            var chave = new SymmetricSecurityKey(Encoding.ASCII
                .GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var otp = new SigningCredentials(chave, SecurityAlgorithms.HmacSha512Signature);

            var senhaResetada = new ResetarSenha()
            {
                Email = email,
                OTP = otp.ToString(),
                Token = token,
                UsuarioId = usuario.Id,
                Data = DateTime.Now
            };

            _resetarSenhaRepository.Adicionar(senhaResetada);

            await _emailSender.SendEmailAsync(email, "NetDeliveryApp - Resetar Senha", "Olá" +
                    email + "<br><br> Seu token para resetar a senha se encontra abaixo: <br><br><b>"
                    + otp + "</b><br><br>Obrigado!<br>netdeliveryapp.com");
        }
    }
}
