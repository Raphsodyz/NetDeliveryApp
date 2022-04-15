using Microsoft.AspNetCore.Identity;
using NetDeliveryAppDominio.Identity.Usuarios;
using System;
using System.Collections.Generic;

namespace NetDeliveryAppDominio.Entidades
{
    public partial class Pedido
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
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
