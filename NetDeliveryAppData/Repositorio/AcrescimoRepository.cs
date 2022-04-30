using Microsoft.EntityFrameworkCore;
using NetDeliveryAppData.Contexto;
using NetDeliveryAppDominio.Entidades;
using NetDeliveryAppDominio.Interfaces.Repositorios;

namespace NetDeliveryAppData.Repositorio
{
    public class AcrescimoRepository : Repository<Acrescimo>, IAcrescimoRepository
    {
        public AcrescimoRepository(NetDeliveryAppContext netDeliveryAppContext) : base(netDeliveryAppContext)
        {

        }

        public override async Task<List<Acrescimo>> Listar()
        {
            return await _netDeliveryAppContext.Acrescimos.Include(a => a.Categoria).ToListAsync();
        }

        public override async Task<Acrescimo> Encontrar(int id)
        {
            return await _netDeliveryAppContext.Acrescimos.Include(a => a.Categoria).Where(c => c.Id == id).FirstAsync();
        }

        public override async void Deletar(int id)
        {
            var entidade = await _netDeliveryAppContext.Acrescimos.FindAsync(id);
            _netDeliveryAppContext.Acrescimos.Remove(entidade);
        }

        public override bool Existe(int id)
        {
            return _netDeliveryAppContext.Acrescimos.Any(c => c.Id == id);
        }
        public override async Task<Acrescimo> Achar(int id)
        {
            return await _netDeliveryAppContext.Acrescimos.FindAsync(id);
        }
    }
}
