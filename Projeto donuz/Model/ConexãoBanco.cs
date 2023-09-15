using Microsoft.EntityFrameworkCore;

namespace Projeto_donuz.Model
{
    public class ConexãoBanco : DbContext
    {
        public ConexãoBanco(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Cliente> cadastros { get; set;}
    }
}
