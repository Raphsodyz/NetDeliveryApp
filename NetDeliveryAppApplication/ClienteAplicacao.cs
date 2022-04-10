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
            var cliente = _clienteRepository.Listar();

            return _mapper.Map<List<ClienteDTO>>(cliente);
        }
        public ClienteDTO Encontrar(int id)
        {
            if (_clienteRepository.Existe(id))
            {
                var cliente = _clienteRepository.Encontrar(id);
                return _mapper.Map<ClienteDTO>(cliente);    
            }
            else
                throw new Exception("Cliente não existe.");
        }

        public void Editar(ClienteDTO clientedto)
        {
            var clienteMap = _mapper.Map<Cliente>(clientedto);

            if (_clienteRepository.Existe(clientedto.Id))
            {
                _clienteRepository.Editar(clienteMap);
                _clienteRepository.Salvar();
            }
            else
                throw new Exception("Cliente não existe.");
        }

        public void Adicionar(ClienteDTO clientedto)
        {
            var clienteMap = _mapper.Map<Cliente>(clientedto);

            _clienteRepository.Adicionar(clienteMap);
            _clienteRepository.Salvar();
        }

        public void Deletar(int id)
        {
            if (_clienteRepository.Existe(id))
            {
                var cliente = _clienteRepository.Encontrar(id);
                var clienteMap = _mapper.Map<Cliente>(cliente);

                _clienteRepository.Deletar(clienteMap);
                _clienteRepository.Salvar();
            }
            else
                throw new Exception("Cliente não existe.");
        }
    }
}
