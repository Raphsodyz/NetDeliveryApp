using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDeliveryAppDominio.Entidades
{
    public class Carrinho
    {
        public virtual ICollection<Acrescimo>? Acrescimos { get; set; } = null!;
        public virtual ICollection<Produto>? Produtos { get; set; } = null!;
        public decimal Valor { get; set; }
    }
}
