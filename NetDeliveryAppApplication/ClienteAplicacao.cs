using NetDeliveryAppData.Repositorio;
using NetDeliveryAppDominio.Entidades;
using NetDeliveryAppDominio.Interfaces.Aplicacao;
using NetDeliveryAppDominio.Interfaces.Repositorios;

namespace NetDeliveryAppAplicacao
{
    public class ClienteAplicacao : IClienteAplicacao
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteAplicacao(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public List<Cliente> Listar()
        {
            return _clienteRepository.Listar();
        }
        public Cliente Encontrar(int id)
        {
            if (_clienteRepository.Existe(id))
            {
                return _clienteRepository.Encontrar(id);
            }
            else
                throw new Exception("Cliente não existe.");
        }

        public void Editar(Cliente cliente)
        {
            if (_clienteRepository.Existe(cliente.Id))
            {
                _clienteRepository.Editar(cliente);
                _clienteRepository.Salvar();
            }
            else
                throw new Exception("Cliente não existe.");
        }

        public void Adicionar(Cliente cliente)
        {
            _clienteRepository.Adicionar(cliente);
            _clienteRepository.Salvar();
        }

        public void Deletar(int id)
        {
            if (_clienteRepository.Existe(id))
            {
                var cliente = _clienteRepository.Encontrar(id);

                _clienteRepository.Deletar(cliente);
                _clienteRepository.Salvar();
            }
            else
                throw new Exception("Cliente não existe.");
        }
    }
}
