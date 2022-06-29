using NetDeliveryAppAplicacao.DTOs;
using NetDeliveryAppAplicacao.DTOs.IdentityDTO;
using NetDeliveryAppDominio.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDeliveryAppAplicacao.Interfaces
{
    public interface IResetarSenhaAplicacao : IAplicacao<ResetarSenhaDTO>
    {
        ResetarSenhaDTO ResetarSenhaDetalhes(string otp, UsuarioDTO usuario);
    }
}
