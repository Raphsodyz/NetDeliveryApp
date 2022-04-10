﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDeliveryAppAplicacao.Comandos.Cliente
{
    public class DeleteCliente : IRequest<string>
    {
        public string Id { get; set; } = null!;
    }
}
