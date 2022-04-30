using Microsoft.EntityFrameworkCore;
using NetDeliveryAppData.Contexto;
using NetDeliveryAppDominio.Entidades;
using NetDeliveryAppDominio.Interfaces.Repositorios;


namespace NetDeliveryAppData.Repositorio
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(NetDeliveryAppContext netDeliveryAppContext) : base(netDeliveryAppContext)
        {

        }

        public override async Task<List<Categoria>> Listar()
        {
            return await _netDeliveryAppContext.Categorias.ToListAsync();
        }

        public override async Task<Categoria> Encontrar(int id)
        {
            return await _netDeliveryAppContext.Categorias.Where(c => c.Id == id).FirstAsync();
        }

        public override async void Deletar(int id)
        {
            var entidade = await _netDeliveryAppContext.Categorias.FindAsync(id);
            _netDeliveryAppContext.Categorias.Remove(entidade);
        }

        public override bool Existe(int id)
        {
            return _netDeliveryAppContext.Categorias.Any(c => c.Id == id);
        }

        public override async Task<Categoria> Achar(int id)
        {
            return await _netDeliveryAppContext.Categorias.FindAsync(id);
        }
    }
}
