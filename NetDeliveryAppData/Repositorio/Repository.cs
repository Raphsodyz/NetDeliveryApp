using NetDeliveryAppData.Contexto;
using NetDeliveryAppDominio.Interfaces.Repositorios;


namespace NetDeliveryAppData.Repositorio
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly NetDeliveryAppContext _netDeliveryAppContext;
        public Repository(NetDeliveryAppContext netDeliveryAppContext)
        {
            _netDeliveryAppContext = netDeliveryAppContext;
        }

        public void Adicionar(T entidade)
        {
           _netDeliveryAppContext.Add(entidade);
        }

        public void Editar(T entidade)
        {
            _netDeliveryAppContext.Update(entidade);
        }

        public virtual void Deletar(int id)
        {
           _netDeliveryAppContext.Remove(id);
        }

        public async Task<bool> Salvar()
        {
            return await _netDeliveryAppContext.SaveChangesAsync() > 0;
        }

        public abstract bool Existe(int id);
        public abstract Task<T> Encontrar(int id);
        public abstract Task<List<T>> Listar();
        public abstract Task<T> Achar(int id);

    }
}
