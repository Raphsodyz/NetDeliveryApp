using System;
using System.Collections.Generic;

namespace NetDeliveryAppDominio.Entidades
{
    public partial class Pedido
    {
        public int Id { get; set; }
        public string Item { get; set; } = null!;
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public string? Observacao { get; set; }
        public DateTime DataPedido { get; set; }
    }
}
