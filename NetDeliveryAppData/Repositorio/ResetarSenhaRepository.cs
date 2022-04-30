using Microsoft.EntityFrameworkCore;
using NetDeliveryAppData.Contexto;
using NetDeliveryAppDominio.Identity;
using NetDeliveryAppDominio.Identity.Usuarios;
using NetDeliveryAppDominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDeliveryAppData.Repositorio
{
    public class ResetarSenhaRepository : Repository<ResetarSenha>, IResetarSenhaRepository
    {
        public ResetarSenhaRepository(NetDeliveryAppContext netDeliveryAppContext) : base(netDeliveryAppContext)
        {

        }

        public override async Task<List<ResetarSenha>> Listar()
        {
            return await _netDeliveryAppContext.ResetarSenhas.ToListAsync();
        }

        public override async Task<ResetarSenha> Encontrar(int id)
        {
            return await _netDeliveryAppContext.ResetarSenhas.Where(c => c.Id == id).FirstAsync();
        }

        public override async void Deletar(int id)
        {
            var entidade = await _netDeliveryAppContext.ResetarSenhas.FindAsync(id);
            _netDeliveryAppContext.ResetarSenhas.Remove(entidade);
        }

        public override bool Existe(int id)
        {
            return _netDeliveryAppContext.ResetarSenhas.Any(c => c.Id == id);
        }

        public async Task<ResetarSenha> ResetarSenhaDetalhes(string otp, Usuario usuario)
        {
            return await _netDeliveryAppContext.ResetarSenhas.Where(r => r.OTP == otp && r.UsuarioId == usuario.Id)
                .OrderByDescending(r => r.Data)
                .FirstOrDefaultAsync();
        }

        public override async Task<ResetarSenha> Achar(int id)
        {
            return await _netDeliveryAppContext.ResetarSenhas.FindAsync(id);
        }
    }
}
