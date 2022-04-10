using AutoMapper;
using NetDeliveryAppAplicacao.DTOs;
using NetDeliveryAppAplicacao.Interfaces;
using NetDeliveryAppDominio.Entidades;
using NetDeliveryAppDominio.Interfaces.Repositorios;


namespace NetDeliveryAppAplicacao
{
    public class EnderecoAplicacao : IEnderecoAplicacao
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;
        public EnderecoAplicacao(IEnderecoRepository enderecoRepository, IMapper mapper)
        {
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
        }

        public List<EnderecoDTO> Listar()
        {
            return _mapper.Map<List<EnderecoDTO>>(_enderecoRepository.Listar());
        }
        public EnderecoDTO Encontrar(int id)
        {
            if (_enderecoRepository.Existe(id))
            {
                return _mapper.Map<EnderecoDTO>(_enderecoRepository.Encontrar(id));
            }
            else
                throw new Exception("Endereco não existe.");
        }

        public void Editar(EnderecoDTO enderecoDTO)
        {
            if (_enderecoRepository.Existe(enderecoDTO.Id))
            {
                _enderecoRepository.Editar(_mapper.Map<Endereco>(enderecoDTO));
                _enderecoRepository.Salvar();
            }
            else
                throw new Exception("Endereco não existe.");
        }

        public void Adicionar(EnderecoDTO enderecoDTO)
        {
            _enderecoRepository.Adicionar(_mapper.Map<Endereco>(enderecoDTO));
            _enderecoRepository.Salvar();
        }

        public void Deletar(int id)
        {
            if (_enderecoRepository.Existe(id))
            {
                var enderecoDTO = _mapper.Map<Endereco>(_enderecoRepository.Encontrar(id));

                _enderecoRepository.Deletar(enderecoDTO);
                _enderecoRepository.Salvar();
            }
            else
                throw new Exception("Endereco não existe.");
        }
    }
}
