﻿using System;
using System.Collections.Generic;

namespace NetDeliveryAppDominio.Entidades
{
    public partial class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Telefone { get; set; } = null!;
        public DateTime? DataCriacao { get; set; }
    }
}
