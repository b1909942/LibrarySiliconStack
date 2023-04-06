using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestInternSiliconStack.Data
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Title { get; set; }
        [MaxLength(255)]
        public string Topic { get; set; }
        public int PublishYear { get; set; }
        [ForeignKey("AuthorId")]
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        [Precision(10, 2)]
        public decimal Price { set; get; }

        public Byte Rating { get; set; }

    }
}
