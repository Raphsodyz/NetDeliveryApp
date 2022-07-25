using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using MimeKit.Text;
using NetDeliveryAppDominio.Identity;
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
                                  IResetarSenhaRepository resetarSenhaRepository) :
            base(configuration, userManager, signInManager, resetarSenhaRepository)
        {

        }

        public override async Task<string> JWT(Usuario usuario)
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
                .GetBytes(_configuration.GetSection("Token").Value));

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

        public override async Task<IdentityResult> ResetarSenha(string email, string otp, string novaSenha)
        {
            var usuario = await UsuarioExiste(email);

            var detalhes = await _resetarSenhaRepository.ResetarSenhaDetalhes(otp, usuario);
            if(detalhes == null)
            {
                return IdentityResult.Failed();
            }

            var token = detalhes.Data.AddMinutes(15);

            if (token < DateTime.Now)
            {
                return IdentityResult.Failed();
            }

            return await _userManager.ResetPasswordAsync(usuario, detalhes.Token, novaSenha);
        }

        public override async Task<IdentityResult> OTPEmail(Usuario usuario, string email)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(usuario);

            var rng = new Random();
            var otp = rng.Next(10000, 99999);

            var senhaResetada = new ResetarSenha()
            {
                Email = email,
                OTP = otp.ToString(),
                Token = token,
                UsuarioId = usuario.Id,
                Data = DateTime.Now
            };

            _resetarSenhaRepository.Adicionar(senhaResetada);
            await _resetarSenhaRepository.Salvar();

            await EnviarCodigoReset(email, senhaResetada.OTP);
            return IdentityResult.Success;
        }

        private async Task EnviarCodigoReset(string email, string otp)
        {
            var enviar = new MimeMessage();
            enviar.From.Add(MailboxAddress.Parse(_configuration.GetSection("NetDeliveryApp_email").
                GetSection("Email").Value));
            enviar.To.Add(MailboxAddress.Parse(email));
            enviar.Subject = "[NetDeliveryApp] Seu código de reset de senha";
            string mensagem = "Olá" +
                    email + "<br> Seu token para resetar a senha se encontra abaixo: <br><br><b>"
                    + "<h2>" + otp + "</h2>" + "</b><br>Obrigado!<br>netdeliveryapp.com";
            enviar.Body = new TextPart(TextFormat.Html) { Text = mensagem };

            using var smtp = new SmtpClient();
            smtp.CheckCertificateRevocation = false;
            smtp.Connect(_configuration.GetSection("NetDeliveryApp_email").GetSection("Host").Value, 587);
            smtp.Authenticate(_configuration.GetSection("NetDeliveryApp_email").GetSection("Email").Value, 
                _configuration.GetSection("NetDeliveryApp_email").GetSection("Senha").Value);
            await smtp.SendAsync(enviar);
            smtp.Disconnect(true);
        }
    }
}
