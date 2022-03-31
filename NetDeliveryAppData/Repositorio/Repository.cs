using NetDeliveryAppData.Contexto;
using NetDeliveryAppDominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public virtual void Deletar(T entidade)
        {
            _netDeliveryAppContext.Remove(entidade);
        }

        public bool Salvar()
        {
            return _netDeliveryAppContext.SaveChanges() > 0;
        }

        public abstract bool Existe(int id);
        public abstract T Encontrar(int id);
        public abstract List<T> Listar();

    }
}
