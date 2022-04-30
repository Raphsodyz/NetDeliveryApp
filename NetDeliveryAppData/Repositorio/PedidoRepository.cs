using Microsoft.EntityFrameworkCore;
using NetDeliveryAppData.Contexto;
using NetDeliveryAppDominio.Entidades;
using NetDeliveryAppDominio.Interfaces.Repositorios;

namespace NetDeliveryAppData.Repositorio
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(NetDeliveryAppContext netDeliveryAppContext) : base(netDeliveryAppContext)
        {

        }

        public override async Task<List<Pedido>> Listar()
        {
            return await _netDeliveryAppContext.Pedidos
                .Include(p => p.Usuario)
                .ToListAsync();
        }

        public override async Task<Pedido> Encontrar(int id)
        {
            return await _netDeliveryAppContext.Pedidos
                .Include(p => p.Usuario).
                Where(p => p.Id == id)
                .FirstAsync();
        }

        public override async void Deletar(int id)
        {
            var entidade = await _netDeliveryAppContext.Pedidos.FindAsync(id);
            _netDeliveryAppContext.Pedidos.Remove(entidade);
        }

        public override bool Existe(int id)
        {
            return _netDeliveryAppContext.Pedidos.Any(p => p.Id == id);
        }

        public override async Task<Pedido> Achar(int id)
        {
            return await _netDeliveryAppContext.Pedidos.FindAsync(id);
        }
    }
}
