using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NetDeliveryAppDominio.Entidades;

namespace NetDeliveryAppData.Contexto
{
    public partial class NetDeliveryAppContext : DbContext
    {
        public NetDeliveryAppContext()
        {
            
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Endereco> Enderecos { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;
        public virtual DbSet<Hamburguer> Hamburguers { get; set; } = null!;
        public virtual DbSet<Bebida> Bebidas { get; set; } = null!;
        public virtual DbSet<Acrescimo> Acrescimos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connection = "server=localhost;database=netdeliveryapp;user id=root;password=akamarus94";
                optionsBuilder.UseMySql(connection, ServerVersion.AutoDetect(connection));
            }
        }
    }
}
