using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDeliveryAppAplicacao.Comandos.Bebida
{
    public class DeleteCategoria : IRequest<string>
    {
        public int Id { get; set; }
    }
}
