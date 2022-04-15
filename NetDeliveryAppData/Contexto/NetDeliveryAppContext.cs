using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NetDeliveryAppDominio.Entidades;
using NetDeliveryAppDominio.Identity.Usuarios;

namespace NetDeliveryAppData.Contexto
{
    public partial class NetDeliveryAppContext : IdentityDbContext<Usuario, Tipos, int,
                                                                    IdentityUserClaim<int>, UsuarioTipo,
                                                                    IdentityUserLogin<int>, IdentityRoleClaim<int>,
                                                                    IdentityUserToken<int>>
    {
        private readonly IConfiguration _configuration;
        public NetDeliveryAppContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public virtual DbSet<Endereco> Enderecos { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;
        public virtual DbSet<Acrescimo> Acrescimos { get; set; } = null!;
        public virtual DbSet<Produto> Produtos { get; set; } = null!;
        public virtual DbSet<Categoria> Categorias { get; set; } = null!;

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
