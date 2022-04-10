using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDeliveryAppAplicacao.Comandos.Acrescimo
{
    public class PostAcrescimo : IRequest<string>
    {
        public string Nome { get; set; } = null!;
        public decimal Valor { get; set; }
    }
}
