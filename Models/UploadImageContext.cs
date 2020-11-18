using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BinaryImage.Models
{
    public partial class UploadImageContext : DbContext
    {
        public UploadImageContext()
        {
        }

        public UploadImageContext(DbContextOptions<UploadImageContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblImage> TblImages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-8KOARQS;Database=UploadImage;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblImage>(entity =>
            {
                entity.ToTable("TblImage");

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
