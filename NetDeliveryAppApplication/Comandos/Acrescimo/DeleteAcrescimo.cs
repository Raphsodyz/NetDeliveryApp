using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDeliveryAppAplicacao.Comandos.Acrescimo
{
    public class DeleteAcrescimo : IRequest<string>
    {
        public string Id { get; set; } = null!;
    }
}
