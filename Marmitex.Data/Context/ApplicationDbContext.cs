using System.Linq;
using Marmitex.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Marmitex.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt) { }
        public virtual DbSet<Acompanhamento> Acompanhamentos { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<ItensPedido> ItensPedidos { get; set; }
        public virtual DbSet<Marmita> Marmitas { get; set; }
        public virtual DbSet<Mistura> Misturas { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Salada> Saladas { get; set; }
        //public virtual DbSet<MarmitaAcompanhamento> MarmitaAcompanhamentos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ItensPedido>()
                .HasKey(ip => new { ip.PedidoId, ip.MarmitaId });

            modelBuilder.Entity<Pedido>()
                .HasMany(m => m.Marmitas);

            modelBuilder.Entity<Marmita>()
                .HasMany(a => a.Acompanhamentos);

            modelBuilder.Entity<Cliente>()
                .HasIndex(p => new { p.Telefone, p.Celular })
                .IsUnique();
        }
    }
}