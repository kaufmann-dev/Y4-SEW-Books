using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("AUTHORS")]
public abstract class Author
{
    [Key]
    [Column("AUTHOR_ID")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AuthorId { get; set; }
    
    [Column("FIRST_NAME")]
    [Required]
    [StringLength(45)]
    public string FirstName { get; set; }
    
    [Column("LAST_NAME")]
    [Required]
    [StringLength(45)]
    public string LastName { get; set; }
}