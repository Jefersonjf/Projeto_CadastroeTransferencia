using Microsoft.EntityFrameworkCore;

namespace Projeto_donuz.Model
{
    public class ClienteContext : DbContext
    {
        public ClienteContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Cliente> cadastros { get; set;}
    }
}
