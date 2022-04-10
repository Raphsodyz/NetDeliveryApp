using AutoMapper;
using NetDeliveryAppAplicacao.DTOs;
using NetDeliveryAppAplicacao.Interfaces;
using NetDeliveryAppDominio.Entidades;
using NetDeliveryAppDominio.Interfaces.Repositorios;

namespace NetDeliveryAppAplicacao
{
    public class ClienteAplicacao : IClienteAplicacao
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        public ClienteAplicacao(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public List<ClienteDTO> Listar()
        {
            return _mapper.Map<List<ClienteDTO>>(_clienteRepository.Listar());
        }
        public ClienteDTO Encontrar(int id)
        {
            if (_clienteRepository.Existe(id))
            {
                return _mapper.Map<ClienteDTO>(_clienteRepository.Encontrar(id));    
            }
            else
                throw new Exception("Cliente não existe.");
        }

        public void Editar(ClienteDTO clienteDTO)
        {
            if (_clienteRepository.Existe(clienteDTO.Id))
            {
                _clienteRepository.Editar(_mapper.Map<Cliente>(clienteDTO));
                _clienteRepository.Salvar();
            }
            else
                throw new Exception("Cliente não existe.");
        }

        public void Adicionar(ClienteDTO clienteDTO)
        {
            _clienteRepository.Adicionar(_mapper.Map<Cliente>(clienteDTO));
            _clienteRepository.Salvar();
        }

        public void Deletar(int id)
        {
            if (_clienteRepository.Existe(id))
            {
                var clienteDTO = _mapper.Map<Cliente>(_clienteRepository.Encontrar(id));

                _clienteRepository.Deletar(clienteDTO);
                _clienteRepository.Salvar();
            }
            else
                throw new Exception("Cliente não existe.");
        }
    }
}
