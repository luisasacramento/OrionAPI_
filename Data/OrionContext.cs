using Microsoft.EntityFrameworkCore;
using Orion_API.Models;

namespace Orion_API.Data
{
    public class OrionContext : DbContext
    {
        public OrionContext(DbContextOptions<OrionContext> options) : base(options)
        {
        }

        public DbSet<Leader> Leaders { get; set; } // <-- ESSA LINHA É NECESSÁRIA
        public DbSet<Team> Teams { get; set; }
        public DbSet<Member> Members { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Caso a tabela no banco seja singular:
            modelBuilder.Entity<Leader>().ToTable("Leader");
            modelBuilder.Entity<Team>().ToTable("Team");
            modelBuilder.Entity<Member>().ToTable("Member");
        }
    }
}
