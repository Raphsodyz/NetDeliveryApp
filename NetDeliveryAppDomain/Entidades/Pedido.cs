using System;
using System.Collections.Generic;

namespace NetDeliveryAppDominio.Entidades
{
    public partial class Pedido
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public string? Observacao { get; set; }
        public DateTime DataPedido { get; set; }
        public int ClienteId { get; set; }
        public int HamburguerId { get; set; }
        public int BebidaId { get; set; }
        public virtual Cliente Cliente { get; set; } = null!;
        public virtual Hamburguer Hamburguer { get; set; } = null!;
        public virtual Bebida Bebida { get; set; } = null!;
    }
}
