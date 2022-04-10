using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDeliveryAppAplicacao.Comandos.Bebida
{
    public class PostBebida : IRequest<string>
    {
        public string Nome { get; set; } = null!;
        public string? Sabor { get; set; } = null!;
        public string Volume { get; set; } = null!;
        public decimal Valor { get; set; }
        public string? Foto { get; set; } = null!;
    }
}
