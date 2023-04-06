namespace TestInternSiliconStack.Models.Book
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Topic { get; set; }
        public int PublishYear { get; set; }
        public string AuthorName { get; set; }
        public decimal Price { set; get; }

        public Byte Rating { get; set; }
    }
}
