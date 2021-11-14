using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HomeLIbrary
{
    public partial class HomeLibraryDBContext : DbContext
    {
        public HomeLibraryDBContext()
        {
        }

        public HomeLibraryDBContext(DbContextOptions<HomeLibraryDBContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasIndex(e => e.NameBook, "UQ__Books__FFD74EF01EEC2DF6")
                    .IsUnique();

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Contents).HasColumnType("xml");

                entity.Property(e => e.Datebirth).HasColumnType("date");

                entity.Property(e => e.NameBook)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
