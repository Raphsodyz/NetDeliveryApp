using MediatR;
using NetDeliveryAppAplicacao.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDeliveryAppAplicacao.Comandos.Endereco
{
    public class PostEndereco : IRequest<string>
    {
        public string Rua { get; set; } = null!;
        public sbyte Numero { get; set; }
        public string Bairro { get; set; } = null!;
        public string? Cidade { get; set; }
        public string? Observacao { get; set; }
    }
}
