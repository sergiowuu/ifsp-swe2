using GerenciadorBLContainer.Models;
using Microsoft.EntityFrameworkCore;

// Sérgio Wu (CB3025691)
// Leonardo de Lima (CB3026655)
namespace GerenciadorBLContainer
{
    public class GerenciadorBLContext : DbContext
    {
        public GerenciadorBLContext(DbContextOptions<GerenciadorBLContext> options)
            : base(options)
        {
        }

        public DbSet<BL> BLs { get; set; }
        public DbSet<Container> Containers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BL>().ToTable("BL");
            modelBuilder.Entity<Container>().ToTable("Container");
        }
    }
}
