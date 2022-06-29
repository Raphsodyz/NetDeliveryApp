using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDeliveryAppDominio.Entidades
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Ingredientes { get; set; }
        public decimal Valor { get; set; }
        public string? Sabor { get; set; }
        public string? Volume { get; set; }
        public string? Foto { get; set; }
        public int? CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
    }
}
