﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDeliveryAppAplicacao.Comandos.Cliente
{
    public class PostCliente : IRequest<string>
    {
        public string Nome { get; set; } = null!;
        public string Cpf { get; set; } = null!;
        public string Telefone { get; set; } = null!;
        public DateTime? DataCriacao { get; set; }
        public string? Foto { get; set; } = null!;
    }
}
