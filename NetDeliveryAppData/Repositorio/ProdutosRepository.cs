using Microsoft.EntityFrameworkCore;
using NetDeliveryAppData.Contexto;
using NetDeliveryAppDominio.Entidades;
using NetDeliveryAppDominio.Interfaces.Repositorios;

namespace NetDeliveryAppData.Repositorio
{
    public class ProdutosRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutosRepository(NetDeliveryAppContext netDeliveryAppContext) : base(netDeliveryAppContext)
        {

        }

        public override List<Produto> Listar()
        {
            return _netDeliveryAppContext.Produtos.Include(a => a.Categoria).ToList();
        }

        public override Produto Encontrar(int id)
        {
            return _netDeliveryAppContext.Produtos.Include(a => a.Categoria).Where(c => c.Id == id).First();
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
