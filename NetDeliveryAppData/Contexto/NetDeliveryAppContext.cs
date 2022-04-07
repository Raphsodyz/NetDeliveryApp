using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NetDeliveryAppDominio.Entidades;

namespace NetDeliveryAppData.Contexto
{
    public partial class NetDeliveryAppContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public NetDeliveryAppContext(IConfiguration configuration)
        {
            _configuration = configuration;
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
                var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

                string connection = _configuration.GetSection("ConnectionStrings").GetSection("default").Value;
                optionsBuilder.UseMySql(connection, ServerVersion.AutoDetect(connection));
            }
        }
    }
}
