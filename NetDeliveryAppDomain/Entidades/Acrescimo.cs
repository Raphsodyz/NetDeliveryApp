using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDeliveryAppDominio.Entidades
{
    public class Acrescimo
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public decimal Valor { get; set; }
        public int? CategoriaId { get; set; }
        public Categoria? Categoria { get; set; } = null!;
    }
}
