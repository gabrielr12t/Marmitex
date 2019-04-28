using Marmitex.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Marmitex.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt) { }
        public DbSet<Acompanhamento> Acompanhamentos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ItensPedido> ItensPedidos { get; set; }
        public DbSet<Marmita> Marmitas { get; set; }
        public DbSet<Mistura> Misturas { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Salada> Saladas { get; set; }
        public DbSet<MarmitaAcompanhamento> MarmitaAcompanhamentos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
            .HasIndex(p => new { p.Telefone, p.Celular })
            .IsUnique(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}