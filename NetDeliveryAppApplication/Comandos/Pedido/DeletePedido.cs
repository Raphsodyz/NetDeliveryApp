using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDeliveryAppAplicacao.Comandos.Pedido
{
    public class DeletePedido : IRequest<string>
    {
        public int Id { get; set; }
    }
}
