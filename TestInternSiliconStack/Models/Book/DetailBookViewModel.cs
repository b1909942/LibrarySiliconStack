using Microsoft.EntityFrameworkCore;
using TestInternSiliconStack.Models.Author;

namespace TestInternSiliconStack.Models.Book
{
    public class DetailBookViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Topic { get; set; }
        public int PublishYear { get; set; }
        public AuthorViewModel? Author { get; set; }
        [Precision(10, 2)]
        public decimal Price { set; get; }

        public Byte Rating { get; set; }
    }
}
