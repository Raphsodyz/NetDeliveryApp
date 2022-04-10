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
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(NetDeliveryAppContext netDeliveryAppContext) : base(netDeliveryAppContext)
        {

        }

        public override List<Categoria> Listar()
        {
            return _netDeliveryAppContext.Categorias.ToList();
        }

        public override Categoria Encontrar(int id)
        {
            return _netDeliveryAppContext.Categorias.Where(c => c.Id == id).First();
        }

        public override void Deletar(Categoria entidade)
        {
            base.Deletar(entidade);
        }

        public override bool Existe(int id)
        {
            return _netDeliveryAppContext.Categorias.Any(c => c.Id == id);
        }
    }
}
