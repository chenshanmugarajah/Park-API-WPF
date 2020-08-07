using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.Models
{
    public partial class SafariParkDBContext : DbContext
    {
        public SafariParkDBContext()
        {
        }

        public SafariParkDBContext(DbContextOptions<SafariParkDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Animal> Animal { get; set; }
        public virtual DbSet<Park> Park { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source = (localdb)\\mssqllocaldb;Initial Catalog = SafariParkDB;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>(entity =>
            {
                entity.Property(e => e.AnimalDiet).HasMaxLength(50);

                entity.Property(e => e.AnimalFact).HasMaxLength(255);

                entity.Property(e => e.AnimalName).HasMaxLength(50);

                entity.Property(e => e.AnimalWeightTons).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Park)
                    .WithMany(p => p.Animal)
                    .HasForeignKey(d => d.ParkId)
                    .HasConstraintName("FK__Animal__ParkId__25869641");
            });

            modelBuilder.Entity<Park>(entity =>
            {
                entity.Property(e => e.ParkDescription).HasMaxLength(50);

                entity.Property(e => e.ParkLocation).HasMaxLength(50);

                entity.Property(e => e.ParkName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
