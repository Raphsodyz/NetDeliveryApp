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

        public async Task<List<EnderecoDTO>> Listar()
        {
            return _mapper.Map<List<EnderecoDTO>>(await _enderecoRepository.Listar());
        }
        public async Task<EnderecoDTO> Encontrar(int id)
        {
            if (_enderecoRepository.Existe(id))
            {
                return _mapper.Map<EnderecoDTO>(await _enderecoRepository.Encontrar(id));
            }
            else
                throw new Exception("Endereco não existe.");
        }

        public async Task Editar(EnderecoDTO enderecoDTO)
        {
            var endereco = await _enderecoRepository.Achar(enderecoDTO.Id);
            if (endereco == null)
            {
                throw new Exception("Endereco não encontrado.");
            }
            else
                _enderecoRepository.Editar(_mapper.Map<Endereco>(enderecoDTO));
        }

        public async Task<bool> Salvar()
        {
            return await _enderecoRepository.Salvar();
        }

        public void Adicionar(EnderecoDTO enderecoDTO)
        {
            _enderecoRepository.Adicionar(_mapper.Map<Endereco>(enderecoDTO));
        }

        public async Task Deletar(int id)
        {
            var endereco = await _enderecoRepository.Achar(id);
            if (endereco == null)
            {
                throw new Exception("Produto não existe.");
            }
            else
            {
                var enderecoDTO = _mapper.Map<EnderecoDTO>(endereco);
                _enderecoRepository.Deletar(enderecoDTO.Id);
            }
        }
    }
}
