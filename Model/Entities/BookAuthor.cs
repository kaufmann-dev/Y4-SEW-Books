using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("BOOK_HAS_AUTHORS_JT")]
public class BookAuthor
{
    [Column("BOOK_ID")]
    public int BookId { get; set; }
    public Book Book { get; set; }
    
    [Column("AUTHOR_ID")]
    public int AuthorId { get; set; }
    public Author Author { get; set; }
}