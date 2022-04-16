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
    public class AcrescimoRepository : Repository<Acrescimo>, IAcrescimoRepository
    {
        public AcrescimoRepository(NetDeliveryAppContext netDeliveryAppContext) : base(netDeliveryAppContext)
        {

        }

        public override List<Acrescimo> Listar()
        {
            return _netDeliveryAppContext.Acrescimos.Include(a => a.Categoria).ToList();
        }

        public override Acrescimo Encontrar(int id)
        {
            return _netDeliveryAppContext.Acrescimos.Include(a => a.Categoria).Where(c => c.Id == id).First();
        }

        public override void Deletar(Acrescimo entidade)
        {
            base.Deletar(entidade);
        }

        public override bool Existe(int id)
        {
            return _netDeliveryAppContext.Acrescimos.Any(c => c.Id == id);
        }
    }
}
