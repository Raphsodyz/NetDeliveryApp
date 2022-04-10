using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDeliveryAppAplicacao.Comandos.Hamburguer
{
    public class DeleteHamburguer : IRequest<string>
    {
        public int Id { get; set; }
    }
}
