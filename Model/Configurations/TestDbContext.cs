using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Model.Configurations; 

public class TestDbContext : DbContext {

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }


    public TestDbContext(DbContextOptions<TestDbContext> options) : base(options) {
        
    }

    protected override void OnModelCreating(ModelBuilder builder) {
        builder.Entity<Book>()
            .HasIndex(b => b.Title)
            .IsUnique();
        
        builder.Entity<Book>()
            .Property(b=>b.BookType)
            .HasConversion<string>();

        builder.Entity<BookAuthor>().HasKey(m => new {
            m.AuthorId,
            m.BookId
        });

        builder.Entity<BookAuthor>()
            .HasOne(m => m.Book)
            .WithMany()
            .HasForeignKey(m => m.BookId);

        builder.Entity<BookAuthor>()
            .HasOne(m => m.Author)
            .WithMany()
            .HasForeignKey(m => m.AuthorId);
        
        builder.Entity<BookAuthor>()
            .HasOne(m => m.Book)
            .WithMany(a => a.BookAuthorList)
            .HasForeignKey(m => m.BookId);

        builder.Entity<Author>()
            .HasDiscriminator<string>("GENDER")
            .HasValue<WomanAuthor>("FEMALE")
            .HasValue<MaleAuthor>("MALE");
    }
}
