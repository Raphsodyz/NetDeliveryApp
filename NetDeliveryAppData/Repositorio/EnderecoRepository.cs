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
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(NetDeliveryAppContext netDeliveryAppContext) : base(netDeliveryAppContext)
        {

        }

        public override List<Endereco> Listar()
        {
            return _netDeliveryAppContext.Enderecos.Include(p => p.Cliente).ToList();
        }

        public override Endereco Encontrar(int id)
        {
            return _netDeliveryAppContext.Enderecos
                .Include(p => p.Cliente)
                .Where(p => p.Id == id)
                .First();
        }

        public override void Deletar(Endereco entidade)
        {
            _netDeliveryAppContext.Enderecos.Remove(entidade);
        }

        public override bool Existe(int id)
        {
            return _netDeliveryAppContext.Enderecos.Any(e => e.Id == id);
        }
    }
}
