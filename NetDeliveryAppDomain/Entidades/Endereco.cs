using System;
using System.Collections.Generic;

namespace NetDeliveryAppDominio.Entidades
{
    public partial class Endereco
    {
        public int Id { get; set; }
        public string Rua { get; set; } = null!;
        public sbyte Numero { get; set; }
        public string Bairro { get; set; } = null!;
        public string? Cidade { get; set; }
        public string? Observacao { get; set; }
        public int? ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;
    }
}
