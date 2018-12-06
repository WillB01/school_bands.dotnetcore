using Microsoft.EntityFrameworkCore;

namespace FavoriteBand.Models.Scaffold
{
    public partial class ScaffoldContext : DbContext
    {
        public ScaffoldContext()
        {
        }

        public ScaffoldContext(DbContextOptions<ScaffoldContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Albums> Albums { get; set; }
        public virtual DbSet<Band> Band { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //  optionsBuilder.UseLazyLoadingProxies
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Albums>(entity =>
            {
                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.Band)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.BandId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Albums_Band");

            });

            modelBuilder.Entity<Band>(entity =>
            {
                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name).IsRequired();
                
                
               
            });
        }
    }
}