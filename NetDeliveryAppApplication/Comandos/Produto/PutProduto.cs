using MediatR;
using NetDeliveryAppAplicacao.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDeliveryAppAplicacao.Comandos.Hamburguer
{
    public class PutProduto : IRequest<string>
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string? Ingredientes { get; set; }
        public decimal Valor { get; set; }
        public string? Sabor { get; set; } = null!;
        public string? Volume { get; set; } = null!;
        public string? Foto { get; set; } = null!;
        public int? CategoriaId { get; set; }
        public CategoriaDTO Categoria { get; set; }
    }
}
