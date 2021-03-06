using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetDeliveryAppAplicacao.DTOs.IdentityDTO;
using NetDeliveryAppAplicacao.Interfaces.Identity;

namespace NetDeliveryAppServicos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosAplicacao _usuariosAplicacao;
        public UsuariosController(IUsuariosAplicacao usuariosAplicacao)
        {
            _usuariosAplicacao = usuariosAplicacao;
        }

        [HttpGet("Encontrar")]
        public IActionResult Usuario()
        {
            return Ok(new UsuarioDTO());
        }

        [HttpPost("Cadastro")]
        [AllowAnonymous]
        public async Task<IActionResult> Registrar(UsuarioDTO usuarioDTO)
        {
            try
            {
                var registrar = await _usuariosAplicacao.Registrar(usuarioDTO);
                if (registrar.Succeeded)
                {
                    return Created("Usuario", usuarioDTO.Email);
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
                var resultado = await _usuariosAplicacao.Login(loginDTO);
                if (resultado.Succeeded)
                {
                    var tokenUsuario = _usuariosAplicacao.EmailNormalizado(loginDTO);
                    return Ok(new
                    {
                        token = _usuariosAplicacao.JWT(tokenUsuario).Result,
                        usuario = tokenUsuario.UserName
                    });
                }
                    return Unauthorized("Email ou senha incorreta.");
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Criação de contas indisponível.\b{ex.Message}");
            }
        }

        [HttpPost("EnviarCodigo")]
        [AllowAnonymous]
        public async Task<IActionResult>EnviarCodigo(string email)
        {
            try
            {
                if(email == null)  
                {
                    return BadRequest("O campo não pode estar vazio.");
                }

                var usuario = await _usuariosAplicacao.UsuarioExiste(email);
                if(usuario == null)
                {
                    return NotFound("Esta conta não existe.");
                }
                await _usuariosAplicacao.OTPEmail(usuario, email);
                return Ok("Token Enviado com sucesso no e-mail.");
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{ex.Message}");
            }
        }

        [HttpPost("ResetarSenha")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetarSenha(string email, string otp, string novaSenha)
        {
            try
            {
                var usuario = await _usuariosAplicacao.UsuarioExiste(email);
                if (usuario == null)
                {
                    return BadRequest("Usuário não encontrado.");
                }
                var reset = await _usuariosAplicacao.ResetarSenha(email, otp, novaSenha);

                if (!reset.Succeeded)
                {
                    return BadRequest("Seu código OTP é inválido ou está expirado. Por favor, gere um novo em 'Esqueci minha senha'.");
                }
                return Ok("Senha resetada com sucesso!");
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Reset de senhas indisponível.\b{ex.Message}");
            }
            
        }
    }
}
