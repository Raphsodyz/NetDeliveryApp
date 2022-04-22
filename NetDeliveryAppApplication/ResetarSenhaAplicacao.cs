using AutoMapper;
using NetDeliveryAppAplicacao.DTOs;
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

        public List<ResetarSenhaDTO> Listar()
        {
            return _mapper.Map<List<ResetarSenhaDTO>>(_resetarSenhaRepository.Listar());
        }
        public ResetarSenhaDTO Encontrar(int id)
        {
            if (_resetarSenhaRepository.Existe(id))
            {
                return _mapper.Map<ResetarSenhaDTO>(_resetarSenhaRepository.Encontrar(id));
            }
            else
                throw new Exception("Produto não existe.");
        }

        public void Editar(ResetarSenhaDTO resetarSenhaDTO)
        {
            if (_resetarSenhaRepository.Existe(resetarSenhaDTO.Id))
            {
                _resetarSenhaRepository.Editar(_mapper.Map<ResetarSenha>(resetarSenhaDTO));
                _resetarSenhaRepository.Salvar();
            }
            else
                throw new Exception("Produto não existe.");
        }

        public void Adicionar(ResetarSenhaDTO resetarSenhaDTO)
        {
            _resetarSenhaRepository.Adicionar(_mapper.Map<ResetarSenha>(resetarSenhaDTO));
            _resetarSenhaRepository.Salvar();
        }

        public void Deletar(int id)
        {
            if (_resetarSenhaRepository.Existe(id))
            {
                var resetarSenhaDTO = _mapper.Map<ResetarSenha>(_resetarSenhaRepository.Encontrar(id));

                _resetarSenhaRepository.Deletar(resetarSenhaDTO);
                _resetarSenhaRepository.Salvar();
            }
            else
                throw new Exception("Produto não existe.");
        }

        public ResetarSenhaDTO ResetarSenhaDetalhes(string otp, UsuarioDTO usuario)
        {
            return _mapper.Map<ResetarSenhaDTO>(_resetarSenhaRepository.ResetarSenhaDetalhes(otp, _mapper.Map<Usuario>(usuario)));
        }
    }
}
