using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestInternSiliconStack.Models.Book
{
    public class AddBookModel
    {
        [Required]
        public string Title { get; set; }
        public string Topic { get; set; }

        public int PublishYear { get; set; }
        [ForeignKey("AuthorId")]
        [Required]
        public int AuthorId { get; set; }
        [Precision(10, 2)]
        public decimal Price { set; get; }

        public Byte Rating { get; set; }
    }
}
