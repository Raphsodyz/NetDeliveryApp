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
    public class BebidaRepository : Repository<Bebida>, IBebidaRepository
    {
        public BebidaRepository(NetDeliveryAppContext netDeliveryAppContext) : base(netDeliveryAppContext)
        {

        }

        public override List<Bebida> Listar()
        {
            return _netDeliveryAppContext.Bebidas.ToList();
        }

        public override Bebida Encontrar(int id)
        {
            return _netDeliveryAppContext.Bebidas.Where(c => c.Id == id).First();
        }

        public override void Deletar(Bebida entidade)
        {
            base.Deletar(entidade);
        }

        public override bool Existe(int id)
        {
            return _netDeliveryAppContext.Bebidas.Any(c => c.Id == id);
        }
    }
}
