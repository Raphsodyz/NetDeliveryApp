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

        public override async Task<List<Produto>> Listar()
        {
            return await _netDeliveryAppContext.Produtos.Include(a => a.Categoria).ToListAsync();
        }

        public override async Task<Produto> Encontrar(int id)
        {
            return await _netDeliveryAppContext.Produtos.Include(a => a.Categoria).Where(c => c.Id == id).FirstAsync();
        }

        public override async void Deletar(int id)
        {
            var entidade = await _netDeliveryAppContext.Produtos.FindAsync(id);
            _netDeliveryAppContext.Produtos.Remove(entidade);
        }

        public override bool Existe(int id)
        {
            return _netDeliveryAppContext.Produtos.Any(c => c.Id == id);
        }

        public override async Task<Produto> Achar(int id)
        {
            return await _netDeliveryAppContext.Produtos.FindAsync(id);
        }
    }
}
