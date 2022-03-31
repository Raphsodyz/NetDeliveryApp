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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connection = "server=localhost;database=netdeliveryapp;user id=root;password=akamarus94";
                optionsBuilder.UseMySql(connection, ServerVersion.AutoDetect(connection));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("cliente");

                entity.Property(e => e.DataCriacao).HasColumnType("datetime");

                entity.Property(e => e.Nome)
                    .HasMaxLength(120)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Telefone)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.ToTable("endereco");

                entity.Property(e => e.Bairro)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Cidade)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Observacao).HasColumnType("tinytext");

                entity.Property(e => e.Rua).HasMaxLength(180);
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.ToTable("pedido");

                entity.Property(e => e.DataPedido).HasColumnType("datetime");

                entity.Property(e => e.Item).HasColumnType("tinytext");

                entity.Property(e => e.Observacao).HasColumnType("tinytext");

                entity.Property(e => e.Valor).HasPrecision(20, 6);
            });

            OnModelCreatingPartial(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
