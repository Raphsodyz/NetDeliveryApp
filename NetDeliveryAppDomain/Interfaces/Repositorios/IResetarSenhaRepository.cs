using NetDeliveryAppDominio.Identity;
using NetDeliveryAppDominio.Identity.Usuarios;

namespace NetDeliveryAppDominio.Interfaces.Repositorios
{
    public interface IResetarSenhaRepository : IRepository<ResetarSenha>
    {
        Task<ResetarSenha> ResetarSenhaDetalhes(string otp, Usuario usuario);
    }
}
