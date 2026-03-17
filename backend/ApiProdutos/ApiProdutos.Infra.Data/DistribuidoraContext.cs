using ApiProdutos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiProdutos.Infra.Data
{
    public class DistribuidoraContext : DbContext
    {

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DistribuidoraContext(DbContextOptions<DistribuidoraContext> options) : base(options)
        {

        }
        public static DistribuidoraContext GetDbCotext()
        {
            var options = new DbContextOptionsBuilder<DistribuidoraContext>()
            .UseInMemoryDatabase(databaseName: "DistribuidoraDb")
            .Options;

            return new DistribuidoraContext(options);

        }
    }
}
