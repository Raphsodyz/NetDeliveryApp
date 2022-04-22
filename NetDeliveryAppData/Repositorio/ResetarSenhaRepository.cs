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

        public override List<ResetarSenha> Listar()
        {
            return _netDeliveryAppContext.ResetarSenhas.ToList();
        }

        public override ResetarSenha Encontrar(int id)
        {
            return _netDeliveryAppContext.ResetarSenhas.Where(c => c.Id == id).First();
        }

        public override void Deletar(ResetarSenha entidade)
        {
            base.Deletar(entidade);
        }

        public override bool Existe(int id)
        {
            return _netDeliveryAppContext.ResetarSenhas.Any(c => c.Id == id);
        }

        public ResetarSenha ResetarSenhaDetalhes(string otp, Usuario usuario)
        {
            return _netDeliveryAppContext.ResetarSenhas.Where(r => r.OTP == otp && r.UsuarioId == usuario.Id)
                .OrderByDescending(r => r.Data)
                .FirstOrDefault();
        }
    }
}
