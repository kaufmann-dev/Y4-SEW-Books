using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("BOOKS")]
public class Book
{
    [Key]
    [Column("BOOK_ID")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BookId { get; set; }
    
    [Column("TITLE")]
    [Required]
    [StringLength(45)]
    public string Title { get; set; }
    
    [Column("TYPE")]
    [Required]
    public EBookType BookType { get; set; }
    
    public List<BookAuthor> BookAuthorList { get; set; } = new List<BookAuthor>();
}