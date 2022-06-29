using AutoMapper;
using NetDeliveryAppAplicacao.DTOs;
using NetDeliveryAppAplicacao.DTOs.IdentityDTO;
using NetDeliveryAppAplicacao.Interfaces;
using NetDeliveryAppDominio.Identity;
using NetDeliveryAppDominio.Identity.Usuarios;
using NetDeliveryAppDominio.Interfaces.Repositorios;

namespace NetDeliveryAppAplicacao
{
    public class ResetarSenhaAplicacao : IResetarSenhaAplicacao
    {
        private readonly IResetarSenhaRepository _resetarSenhaRepository;
        private readonly IMapper _mapper;
        public ResetarSenhaAplicacao(IResetarSenhaRepository resetarSenhaRepository, IMapper mapper)
        {
            _resetarSenhaRepository = resetarSenhaRepository;
            _mapper = mapper;
        }

        public async Task<List<ResetarSenhaDTO>> Listar()
        {
            return _mapper.Map<List<ResetarSenhaDTO>>(await _resetarSenhaRepository.Listar());
        }
        public async Task<ResetarSenhaDTO> Encontrar(int id)
        {
            if (_resetarSenhaRepository.Existe(id))
            {
                return _mapper.Map<ResetarSenhaDTO>(await _resetarSenhaRepository.Encontrar(id));
            }
            else
                throw new Exception("Senha não existente.");
        }

        public async Task Editar(ResetarSenhaDTO resetarSenhaDTO)
        {
            var resetarSenha = await _resetarSenhaRepository.Achar(resetarSenhaDTO.Id);
            if (resetarSenha == null)
            {
                throw new Exception("Senha não encontrada.");
            }
            else
                _resetarSenhaRepository.Editar(_mapper.Map<ResetarSenha>(resetarSenhaDTO));
        }

        public async Task<bool> Salvar()
        {
            return await _resetarSenhaRepository.Salvar();
        }

        public void Adicionar(ResetarSenhaDTO resetarSenhaDTO)
        {
            _resetarSenhaRepository.Adicionar(_mapper.Map<ResetarSenha>(resetarSenhaDTO));
        }

        public async Task Deletar(int id)
        {
            var resetarSenha = await _resetarSenhaRepository.Achar(id);
            if (resetarSenha == null)
            {
                throw new Exception("Senha não existe.");
            }
            else
            {
                var resetarSenhaDTO = _mapper.Map<ResetarSenhaDTO>(resetarSenha);
                _resetarSenhaRepository.Deletar(resetarSenhaDTO.Id);
            }
        }

        public ResetarSenhaDTO ResetarSenhaDetalhes(string otp, UsuarioDTO usuario)
        {
            return _mapper.Map<ResetarSenhaDTO>( _resetarSenhaRepository.ResetarSenhaDetalhes(otp, _mapper.Map<Usuario>(usuario)));
        }
    }
}
