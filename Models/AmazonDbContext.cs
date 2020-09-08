using Microsoft.EntityFrameworkCore;

namespace _02_asp_net_web_api_02lsc10v.Models
{
  public class AmazonDbContext : DbContext
  {
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite("Data Source=Db/amazonbooks.db");
      base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Book>(book =>
      {
        book.HasOne(b => b.Category)
          .WithMany(c => c.Books)
          .HasForeignKey(b => b.CategoryId);

        book.Property(p => p.Id).HasColumnName("id");
        book.Property(p => p.Filename).HasColumnName("filename");
        book.Property(p => p.ImageUrl).HasColumnName("image_url");
        book.Property(p => p.Title).HasColumnName("title");
        book.Property(p => p.Author).HasColumnName("author");
      });

      modelBuilder.Entity<Category>(cat =>
      {
        cat.HasMany(c => c.Books)
          .WithOne(b => b.Category);

        cat.Property(p => p.Id).HasColumnName("id");
        cat.Property(p => p.Name).HasColumnName("name");
      });

      base.OnModelCreating(modelBuilder);
    }

  }
}