using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata;
using WebApplication1.DomainModels;
using WebApplication1.Interfaces;


namespace WebApplication1.Repository
{
    public class RepoContext : DbContext
    {

        public RepoContext()
        {
        }

        public RepoContext(DbContextOptions<RepoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> UserTable { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Email);

                entity.ToTable("");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DOB)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                   .HasMaxLength(100)
                   .IsUnicode(false);




            });

        }
    }
}
