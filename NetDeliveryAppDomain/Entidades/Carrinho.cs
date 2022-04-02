using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDeliveryAppDominio.Entidades
{
    public class Carrinho
    {
        public ICollection<Hamburguer> Hamburguers { get; set; } = null!;
        public ICollection<Bebida> Bebidas { get; set; } = null!;
        public decimal Valor { get; set; }
    }
}
