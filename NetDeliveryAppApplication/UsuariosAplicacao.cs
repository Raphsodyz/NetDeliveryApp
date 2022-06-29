using AutoMapper;
using Microsoft.AspNetCore.Identity;
using NetDeliveryAppAplicacao.DTOs.IdentityDTO;
using NetDeliveryAppAplicacao.Interfaces.Identity;
using NetDeliveryAppDominio.Identity.Usuarios;
using NetDeliveryAppDominio.Interfaces.Identity;

namespace NetDeliveryAppAplicacao
{
    public class UsuariosAplicacao : IUsuariosAplicacao
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuariosAplicacao(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<IdentityResult> Registrar(UsuarioDTO usuarioDTO)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDTO);
            var registrar = await _usuarioRepository.Registrar(usuario);

            if (registrar.Succeeded)
            {
                return IdentityResult.Success;
            }
            else
                throw new Exception("Não podemos criar a sua conta no momento.");
        }

        public async Task<Usuario> UsuarioExiste(string email)
        {
            return await _usuarioRepository.UsuarioExiste(email);
        }

        public async Task<SignInResult> Login(LoginDTO loginDTO)
        {
            var usuario = await _usuarioRepository.UsuarioExiste(_mapper.Map<Usuario>(loginDTO).Email);
            if(usuario == null)
            {
                throw new Exception("Email ou senha incorreta.");
            }
            var acesso = await _usuarioRepository.Login(usuario, _mapper.Map<Usuario>(loginDTO).PasswordHash);

            if (acesso.Succeeded)
            {
                return SignInResult.Success;
            }
             throw new Exception("Email ou senha incorreta.");
        }

        public Usuario EmailNormalizado(LoginDTO loginDTO)
        {
            return _usuarioRepository.EmailNormalizado(_mapper.Map<Usuario>(loginDTO));
        }

        public async Task<string> JWT(Usuario usuario)
        {
            return await _usuarioRepository.JWT(usuario);
        }

        public async Task<IdentityResult> ResetarSenha(Usuario usuario, string otp, string novaSenha)
        {
            var reset = await _usuarioRepository.ResetarSenha(_mapper.Map<Usuario>(usuario), otp, novaSenha);

            if (reset.Succeeded)
            {
                return IdentityResult.Success;
            }
            else
                throw new Exception("Seu código OTP expirou. Por gentileza, solicite um novo na opção 'Esqueci minha senha'.");
        }

        public async Task OTPEmail(Usuario usuario, string email)
        {
            await _usuarioRepository.OTPEmail(_mapper.Map<Usuario>(usuario), email);
        }
    }
}
