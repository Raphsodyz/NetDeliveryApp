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

        public override async Task<List<Endereco>> Listar()
        {
            return await _netDeliveryAppContext.Enderecos.ToListAsync();
        }

        public override async Task<Endereco> Encontrar(int id)
        {
            return await _netDeliveryAppContext.Enderecos
                .Where(p => p.Id == id)
                .FirstAsync();
        }

        public override async void Deletar(int id)
        {
            var entidade = await _netDeliveryAppContext.Enderecos.FindAsync(id);
            _netDeliveryAppContext.Enderecos.Remove(entidade);
        }

        public override bool Existe(int id)
        {
            return _netDeliveryAppContext.Enderecos.Any(e => e.Id == id);
        }

        public override async Task<Endereco> Achar(int id)
        {
            return await _netDeliveryAppContext.Enderecos.FindAsync(id);
        }
    }
}
