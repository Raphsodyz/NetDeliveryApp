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
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(NetDeliveryAppContext netDeliveryAppContext) : base(netDeliveryAppContext)
        {

        }

        public override List<Cliente> Listar()
        {
            return _netDeliveryAppContext.Clientes.ToList();
        }

        public override Cliente Encontrar(int id)
        {
            return _netDeliveryAppContext.Clientes.Where(c => c.Id == id).First();
        }

        public override void Deletar(Cliente entidade)
        {
            base.Deletar(entidade);
        }

        public override bool Existe(int id)
        {
            return _netDeliveryAppContext.Clientes.Any(c => c.Id == id);
        }
    }
}
