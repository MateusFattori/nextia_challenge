using Microsoft.EntityFrameworkCore;
using nextia_challenge.Models;
namespace nextia_challenge.Data

{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Cliente> MVC_Clientes { get; set; }

        public DbSet<Produto> MVC_Produtos { get; set; }

        public DbSet<Promocao> MVC_Promocoes { get; set; }
    }
}
