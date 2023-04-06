using Microsoft.EntityFrameworkCore;

namespace TestInternSiliconStack.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
            builder.UseInMemoryDatabase(databaseName: "Lirbary");
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }


    }
}
