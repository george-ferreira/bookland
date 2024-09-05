using Microsoft.EntityFrameworkCore;

namespace bookland
{
    public class LivroContext : DbContext
    {
        public LivroContext(){}

        public LivroContext(DbContextOptions<LivroContext> options) : base(options) { }

        public DbSet<Livro> Livros { get; set; }
    }
}