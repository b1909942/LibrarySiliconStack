namespace TestInternSiliconStack.Data
{
    public class BookSeeding
    {
        public static void SeedAsync(AppDbContext context)
        {
            if (!context.Books.Any())
            {
                var books = new List<Book>
                {
                    new Book{Id=1, Title = "Act like a Lady, Think like a Man",Topic="relationship",PublishYear=2009,AuthorId=1,Price=20.05m,Rating=1 },
                    new Book{Id=2, Title = "As a Man Thinketh",Topic="positive thinking",PublishYear=1902,AuthorId=2,Price=50.00m,Rating=2 },
                    new Book{Id=3, Title = "Women Who Love Too Much",Topic="trelationship",PublishYear=1985,AuthorId=3,Price=15.40m,Rating=3 },
                    new Book{Id=4, Title = "I Will Teach You To Be Rich",Topic="success",PublishYear=2009,AuthorId=4,Price=20.00m,Rating=4 },
                    new Book{Id=5, Title = "Codependent No More",Topic="relationship",PublishYear=1986,AuthorId=5,Price=32.00m,Rating=2 },
                    new Book{Id=6, Title = "How to Stop Worrying and Start Living",Topic="optimism",PublishYear=1948,AuthorId=6,Price=50.00m,Rating=4 },

                    };
                context.Books.AddRange(books);
                context.SaveChanges();
            }
        }
    }
}
