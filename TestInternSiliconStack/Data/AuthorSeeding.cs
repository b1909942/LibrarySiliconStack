namespace TestInternSiliconStack.Data
{
    public class AuthorSeeding
    {
        public static void SeedAsync(AppDbContext context)
        {
            if (!context.Authors.Any())
            {
                var authors = new List<Author>
                {
                    new Author{Id=1, Name = "Steve Harvey",Female=false,Born=1957,Died=null},
                    new Author{Id=2, Name = "James Allen",Female=false,Born=1864,Died=1912},
                    new Author{Id=3, Name = "Robin Norwood",Female=true,Born=1945,Died=null},
                    new Author{Id=4, Name = "Ramit Sethi",Female=false,Born=1982,Died=null},
                    new Author{Id=5, Name = "Melody Beattie",Female=true,Born=1948,Died=null},
                    new Author{Id=6, Name = "Dale Carnegie",Female=false,Born=1888,Died=1955},

                    };
                context.Authors.AddRange(authors);
                context.SaveChanges();
            }
        }
    }
}
