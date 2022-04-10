using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDeliveryAppAplicacao.Comandos.Hamburguer
{
    public class PostHamburguer : IRequest<string>
    {
        public string Nome { get; set; } = null!;
        public string? Ingredientes { get; set; }
        public decimal Valor { get; set; }
        public string? Foto { get; set; } = null!;
    }
}
