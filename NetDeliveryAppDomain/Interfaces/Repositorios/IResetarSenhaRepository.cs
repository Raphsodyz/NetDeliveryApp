using NetDeliveryAppDominio.Identity;
using NetDeliveryAppDominio.Identity.Usuarios;

namespace NetDeliveryAppDominio.Interfaces.Repositorios
{
    public interface IResetarSenhaRepository : IRepository<ResetarSenha>
    {
        ResetarSenha ResetarSenhaDetalhes(string otp, Usuario usuario);
    }
}
