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

        public List<AcrescimoDTO> Listar()
        {
            return _mapper.Map<List<AcrescimoDTO>>(_acrescimoRepository.Listar());
        }
        public AcrescimoDTO Encontrar(int id)
        {
            if (_acrescimoRepository.Existe(id))
            {
                return _mapper.Map<AcrescimoDTO>(_acrescimoRepository.Encontrar(id));
            }
            else
                throw new Exception("Acrescimo não existe.");
        }

        public void Editar(AcrescimoDTO acrescimoDTO)
        {
            if (_acrescimoRepository.Existe(acrescimoDTO.Id))
            {
                _acrescimoRepository.Editar(_mapper.Map<Acrescimo>(acrescimoDTO));
                _acrescimoRepository.Salvar();
            }
            else
                throw new Exception("Acrescimo não existe.");
        }

        public void Adicionar(AcrescimoDTO acrescimoDTO)
        {
            _acrescimoRepository.Adicionar(_mapper.Map<Acrescimo>(acrescimoDTO));
            _acrescimoRepository.Salvar();
        }

        public void Deletar(int id)
        {
            if (_acrescimoRepository.Existe(id))
            {
                var acrescimoMap = _mapper.Map<Acrescimo>(_acrescimoRepository.Encontrar(id));

                _acrescimoRepository.Deletar(acrescimoMap);
                _acrescimoRepository.Salvar();
            }
            else
                throw new Exception("Acrescimo não existe.");
        }
    }
}
