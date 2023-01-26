using Microsoft.EntityFrameworkCore;

namespace Sid.bookStore.Data
{
    public class BookStoreContext:DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {

        }
        public DbSet<Book> Book{ get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.Database=BookStore;Integrated Security=True;");
        //    base.OnConfiguring(optionsBuilder); 
        //}
    }
}
