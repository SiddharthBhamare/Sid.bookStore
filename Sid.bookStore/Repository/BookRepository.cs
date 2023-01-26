using Microsoft.EntityFrameworkCore;
using Sid.bookStore.Data;
using Sid.bookStore.Models;

namespace Sid.bookStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;   
        public BookRepository(BookStoreContext aobjContext)
        {
            _context= aobjContext;
        }
        public async Task<int> AddNewBook(BookModel aBookModel)
        {
            var lBook = new Book()
            {
                Author = aBookModel.Author,
                CreatedDate = DateTime.UtcNow,
                Description = aBookModel.Description,
                Title = aBookModel.Title,
                TotalPages = (int?)(aBookModel.TotalPages.HasValue?aBookModel.TotalPages:0),
                ModifiedDate = DateTime.UtcNow,
                Category = aBookModel.Category,
                Language = aBookModel.Language
            };
            await _context.Book.AddAsync(lBook);
            await _context.SaveChangesAsync();
            return lBook.Id;
        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            return await DataSource();
        }
        public async Task<BookModel> GetBookById(int aIntId)
        {
            var book = await _context.Book.FindAsync(aIntId);
            if(book != null)
            {
                var bookDetails = new BookModel()
                {
                    Author = book.Author,
                    Title = book.Title,
                    Category = book.Category,
                    Description = book.Description,
                    Id = book.Id,
                    Language = book.Language,
                    TotalPages = book.TotalPages
                };
                return bookDetails;
            }            
            return null;
        }
        public async Task<List<BookModel>> SearchBook(string astrTitle, string astrAuthorName)
        {
            var lListBookModels = await DataSource();
            if (lListBookModels?.Any() == true)
            {
               return lListBookModels.Where(lobjModel => lobjModel.Title.Contains(astrTitle) ||
               lobjModel.Author.Contains(astrAuthorName)).ToList();                    
            }
            return new List<BookModel>();
        }
        private async  Task<List<BookModel>> DataSource()
        {
            List<BookModel> books = new List<BookModel>();
            var AllBooks = await _context.Book.ToListAsync();
            if (AllBooks?.Any()==true)
            {
                foreach (var book in AllBooks)
                {
                    books.Add(new BookModel
                    {
                        Author = book.Author,
                        Title = book.Title,
                        Category = book.Category,
                        Description = book.Description,
                        Id = book.Id,
                        Language = book.Language,
                        TotalPages = book.TotalPages
                    });
                }
            }
            return books;
        }
    }
}
