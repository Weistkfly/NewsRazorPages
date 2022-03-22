using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace NewsRazor.Models
{
    public partial class NewsAppContext : DbContext
    {
        public NewsAppContext(DbContextOptions<NewsAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<News> News { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=NewsApp;Trusted_Connection=True;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.HasIndex(e => e.AuthorId, "IX_News_AuthorId");

                entity.HasIndex(e => e.CategoryId, "IX_News_CategoryId");

                entity.Property(e => e.Content).IsRequired();

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.AuthorId);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.CategoryId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
