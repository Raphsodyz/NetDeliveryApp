using AutoMapper;
using NetDeliveryAppAplicacao.DTOs;
using NetDeliveryAppAplicacao.Interfaces;
using NetDeliveryAppDominio.Entidades;
using NetDeliveryAppDominio.Interfaces.Repositorios;

namespace NetDeliveryAppAplicacao
{
    public class AcrescimoAplicacao : IAcrescimoAplicacao
    {
        private readonly IAcrescimoRepository _acrescimoRepository;
        private readonly IMapper _mapper;
        public AcrescimoAplicacao(IAcrescimoRepository acrescimoRepository, IMapper mapper)
        {
            _acrescimoRepository = acrescimoRepository;
            _mapper = mapper;
        }

        public async Task<List<AcrescimoDTO>> Listar()
        {
            return _mapper.Map<List<AcrescimoDTO>>(await _acrescimoRepository.Listar());
        }
        public async Task<AcrescimoDTO> Encontrar(int id)
        {
            if (_acrescimoRepository.Existe(id))
            {
                return _mapper.Map<AcrescimoDTO>(await _acrescimoRepository.Encontrar(id));
            }
            else
                throw new Exception("Acrescimo não existe.");
        }

        public async Task Editar(AcrescimoDTO acrescimoDTO)
        {
            var acrescimo = await _acrescimoRepository.Achar(acrescimoDTO.Id);
            if (acrescimo == null)
            {
                throw new Exception("Acrescimo não encontrado.");
            }
            else
                _acrescimoRepository.Editar(_mapper.Map<Acrescimo>(acrescimoDTO));
        }

        public async Task<bool> Salvar()
        {
            return await _acrescimoRepository.Salvar();
        }

        public void Adicionar(AcrescimoDTO acrescimoDTO)
        {
            _acrescimoRepository.Adicionar(_mapper.Map<Acrescimo>(acrescimoDTO));
        }

        public async Task Deletar(int id)
        {
            var acrescimo = await _acrescimoRepository.Achar(id);
            if (acrescimo == null)
            {
                throw new Exception("Acrescimo não existe.");
            }
            else
            {
                var acrescimoDTO = _mapper.Map<Acrescimo>(acrescimo);
                _acrescimoRepository.Deletar(acrescimoDTO.Id);
            }
        }
    }
}
