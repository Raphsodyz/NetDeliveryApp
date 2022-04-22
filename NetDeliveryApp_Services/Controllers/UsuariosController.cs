using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NetDeliveryAppAplicacao.DTOs;
using NetDeliveryAppAplicacao.Interfaces;
using NetDeliveryAppData.Contexto;
using NetDeliveryAppDominio.Email;
using NetDeliveryAppDominio.Identity;
using NetDeliveryAppDominio.Identity.Usuarios;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NetDeliveryAppServicos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly IMapper _mapper;
        private readonly IResetarSenhaAplicacao _resetarSenhaAplicacao;
        private readonly IEmailSender _emailSender;
        public UsuariosController(IConfiguration configuration,
                                  UserManager<Usuario> userManager,
                                  SignInManager<Usuario> signInManager,
                                  IMapper mapper,
                                  IResetarSenhaAplicacao resetarSenhaAplicacao,
                                  IEmailSender emailSender)
        {
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _resetarSenhaAplicacao = resetarSenhaAplicacao;
            _emailSender = emailSender;
        }

        [HttpGet("Encontrar")]
        public IActionResult Usuario()
        {
            return Ok(new UsuarioDTO());
        }

        [HttpPost("Registro")]
        [AllowAnonymous]
        public async Task<IActionResult> Registrar(UsuarioDTO usuarioDTO)
        {
            try
            {
                var usuario = _mapper.Map<Usuario>(usuarioDTO);
                var registrar = await _userManager.CreateAsync(usuario, usuarioDTO.PasswordHash);

                if (registrar.Succeeded)
                {
                    return Created("Usuario", _mapper.Map<UsuarioDTO>(usuario));
                }
                else
                {
                    return BadRequest(registrar.Errors);
                }
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Criação de contas indisponível.\b {ex.Message}");
            }
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            try
            {
                var usuario = await _userManager.FindByEmailAsync(loginDTO.Email);
                var resultado = await _signInManager.CheckPasswordSignInAsync(usuario, loginDTO.PasswordHash, true);
                if (resultado.Succeeded)
                {
                    var appUsuario = await _userManager.Users
                        .FirstOrDefaultAsync(u => u.NormalizedEmail == loginDTO.Email.ToUpper());

                    var retorno = _mapper.Map<LoginDTO>(appUsuario);
                    return Ok(new
                    {
                        token = GerarJWT(appUsuario).Result,
                        usuario = retorno
                    });
                }
                    return Unauthorized();
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Criação de contas indisponível.\b{ex.Message}");
            }
        }

        [HttpPost("Codigo")]
        [AllowAnonymous]
        public async Task<IActionResult>EnviarCodigo(string email)
        {
            try
            {
                if(email == null)
                {
                    return BadRequest("O campo não pode estar vazio.");
                }

                var usuario = await _userManager.FindByEmailAsync(email);
                var token = await _userManager.GeneratePasswordResetTokenAsync(usuario);
                var chave = new SymmetricSecurityKey(Encoding.ASCII
                .GetBytes(_configuration.GetSection("AppSettings:Token").Value));

                var otp = new SigningCredentials(chave, SecurityAlgorithms.HmacSha512Signature);

                var resetarSenha = new ResetarSenhaDTO()
                {
                    Email = email,
                    OTP = otp.ToString(),
                    Token = token,
                    UsuarioId = usuario.Id,
                    Data = DateTime.Now
                };

                var retorno = _mapper.Map<ResetarSenhaDTO>(resetarSenha);

                _resetarSenhaAplicacao.Adicionar(retorno);

                await _emailSender.SendEmailAsync(email, "NetDeliveryApp - Resetar Senha", "Olá" +
                    email + "<br><br> Seu token para resetar a senha se encontra abaixo: <br><br><b>"
                    + otp + "</b><br><br>Obrigado!<br>netdeliveryapp.com");

                return Ok("Token Enviado com sucesso no e-mail.");
            }
            catch(Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpPost("ResetarSenha")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetarSenha(string email, string otp, string novaSenha)
        {
            if (email == null)
            {
                return BadRequest("O campo não pode estar vazio.");
            }

            var usuario = await _userManager.FindByEmailAsync(email);
            var detalhes = _resetarSenhaAplicacao.ResetarSenhaDetalhes(otp, _mapper.Map<UsuarioDTO>(usuario));

            var tokenExpirado = detalhes.Data.AddMinutes(15);

            if(tokenExpirado < DateTime.Now)
            {
                return BadRequest("Seu OTP está expirado. por favor, gere um novo.");
            }

            var resultado = await _userManager.ResetPasswordAsync(usuario, detalhes.Token, novaSenha);

            if (!resultado.Succeeded)
            {
                return BadRequest("Falha.");
            }

            return Ok("Senha resetada com sucesso!");


        }

        private async Task<string> GerarJWT(Usuario usuario)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.Email)
            };

            var tipos = await _userManager.GetRolesAsync(usuario);

            foreach(var tipo in tipos)
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
    }
}
