using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDeliveryAppAplicacao.Comandos.Bebida
{
    public class PostCategoria : IRequest<string>
    {
        public string Nome { get; set; } = null!;
    }
}
