using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Sid.bookStore.Data
{
    public class BookStoreContext:DbContext
    {
        protected readonly IConfiguration Configuration;
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {

        }
        public DbSet<Book> Book{ get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
