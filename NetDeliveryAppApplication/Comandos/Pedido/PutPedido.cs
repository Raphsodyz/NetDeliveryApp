using MediatR;
using NetDeliveryAppAplicacao.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDeliveryAppAplicacao.Comandos.Pedido
{
    public class PutPedido : IRequest<string>
    {
        public int Id { get; set; }
        public int? Quantidade { get; set; }
        public decimal Valor { get; set; }
        public string? Observacao { get; set; }
        public DateTime DataPedido { get; set; }
        public string Itens { get; set; } = null!;
        public string Pagamento { get; set; } = null!;
        public string Troco { get; set; } = null!;
        public bool Entregue { get; set; }
        public virtual int ClienteId { get; set; }
        public virtual ClienteDTO? Cliente { get; set; } = null!;
    }
}
