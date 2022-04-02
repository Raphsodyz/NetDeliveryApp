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
    public class HamburguerRepository : Repository<Hamburguer>, IHamburguerRepository
    {
        public HamburguerRepository(NetDeliveryAppContext netDeliveryAppContext) : base(netDeliveryAppContext)
        {

        }

        public override List<Hamburguer> Listar()
        {
            return _netDeliveryAppContext.Hamburguers.ToList();
        }

        public override Hamburguer Encontrar(int id)
        {
            return _netDeliveryAppContext.Hamburguers.Where(c => c.Id == id).First();
        }

        public override void Deletar(Hamburguer entidade)
        {
            base.Deletar(entidade);
        }

        public override bool Existe(int id)
        {
            return _netDeliveryAppContext.Hamburguers.Any(c => c.Id == id);
        }
    }
}
