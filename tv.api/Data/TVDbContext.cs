using Microsoft.EntityFrameworkCore;

namespace tv.api.Data
{
    public class TVDbContext : DbContext
    {
        public DbSet<Show> Shows { get; set; }
        public DbSet<Episode> Episodes { get; set; }

        public TVDbContext(DbContextOptions<TVDbContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Episode>(entity =>
                {
                    entity
                        .HasOne(e => e.Show)
                        .WithMany(e => e.Episodes)
                        .HasForeignKey(e => e.ShowId);
                });
        }
    }
}
