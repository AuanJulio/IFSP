using Microsoft.EntityFrameworkCore;
using TP03.Models;

namespace TP03.Data
{
    public class ArmazemContext : DbContext
    {
        public ArmazemContext(DbContextOptions<ArmazemContext> options)
            : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>(entidade =>
            {
                entidade.ToTable("Produtos");
                entidade.Property(p => p.Preco).HasPrecision(18, 2);

                entidade.HasData(
                    new Produto
                    {
                        Id = 1,
                        Nome = "Teclado mecânico ABNT2",
                        Descricao = "Teclado com switches azuis e iluminação LED.",
                        Preco = 289.90m,
                        QuantidadeEstoque = 15
                    },
                    new Produto
                    {
                        Id = 2,
                        Nome = "Mouse sem fio",
                        Descricao = "Mouse óptico 1600 DPI com receptor USB.",
                        Preco = 59.99m,
                        QuantidadeEstoque = 4
                    },
                    new Produto
                    {
                        Id = 3,
                        Nome = "Monitor 24 polegadas",
                        Descricao = "Monitor Full HD com painel IPS e entrada HDMI.",
                        Preco = 899.00m,
                        QuantidadeEstoque = 0
                    });
            });
        }
    }
}
