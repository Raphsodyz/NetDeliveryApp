using Microsoft.EntityFrameworkCore;
using NetDeliveryAppData.Contexto;
using NetDeliveryAppDominio.Entidades;
using NetDeliveryAppDominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDeliveryAppData.Repositorio
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(NetDeliveryAppContext netDeliveryAppContext) : base(netDeliveryAppContext)
        {

        }

        public override List<Pedido> Listar()
        {
            return _netDeliveryAppContext.Pedidos
                .Include(p => p.Cliente)
                .ToList();
        }

        public override Pedido Encontrar(int id)
        {
            return _netDeliveryAppContext.Pedidos
                .Include(p => p.Cliente).
                Where(p => p.Id == id)
                .First();
        }

        public override void Deletar(Pedido entidade)
        {
            _netDeliveryAppContext.Pedidos.Remove(entidade);
        }

        public override bool Existe(int id)
        {
            return _netDeliveryAppContext.Pedidos.Any(p => p.Id == id);
        }
    }
}
