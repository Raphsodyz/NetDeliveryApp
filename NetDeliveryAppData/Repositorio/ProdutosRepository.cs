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
    public class ProdutosRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutosRepository(NetDeliveryAppContext netDeliveryAppContext) : base(netDeliveryAppContext)
        {

        }

        public override List<Produto> Listar()
        {
            return _netDeliveryAppContext.Produtos.ToList();
        }

        public override Produto Encontrar(int id)
        {
            return _netDeliveryAppContext.Produtos.Where(c => c.Id == id).First();
        }

        public override void Deletar(Produto entidade)
        {
            base.Deletar(entidade);
        }

        public override bool Existe(int id)
        {
            return _netDeliveryAppContext.Produtos.Any(c => c.Id == id);
        }
    }
}
