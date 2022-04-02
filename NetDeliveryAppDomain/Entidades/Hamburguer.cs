﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDeliveryAppDominio.Entidades
{
    public partial class Hamburguer
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string? Ingredientes { get; set; }
        public decimal Valor { get; set; }
        public string? Acrescimos { get; set; } = null!;
    }
}
