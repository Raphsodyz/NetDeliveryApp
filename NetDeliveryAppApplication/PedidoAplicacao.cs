using NetDeliveryAppAplicacao.Interfaces;
using NetDeliveryAppDominio.Entidades;
using NetDeliveryAppDominio.Interfaces.Repositorios;

namespace NetDeliveryAppAplicacao
{
    public class PedidoAplicacao : IPedidoAplicacao
    {
        private readonly IPedidoRepository _pedidoRepository;
        public PedidoAplicacao(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public List<Pedido> Listar()
        {
            return _pedidoRepository.Listar();
        }
        public Pedido Encontrar(int id)
        {
            if (_pedidoRepository.Existe(id))
            {
                return _pedidoRepository.Encontrar(id);
            }
            else
                throw new Exception("Cliente não existe.");
        }

        public void Editar(Pedido pedido)
        {
            if (_pedidoRepository.Existe(pedido.Id))
            {
                _pedidoRepository.Editar(pedido);
                _pedidoRepository.Salvar();
            }
            else
                throw new Exception("Cliente não existe.");
        }

        public void Adicionar(Pedido pedido)
        {
            _pedidoRepository.Adicionar(pedido);
            _pedidoRepository.Salvar();
        }

        public void Deletar(int id)
        {
            if (_pedidoRepository.Existe(id))
            {
                var pedido = _pedidoRepository.Encontrar(id);

                _pedidoRepository.Deletar(pedido);
                _pedidoRepository.Salvar();
            }
            else
                throw new Exception("Cliente não existe.");
        }
    }
}
