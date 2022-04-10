﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDeliveryAppAplicacao.Comandos.Acrescimo
{
    public class PutAcrescimo : IRequest<string>
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public decimal Valor { get; set; }
    }
}
