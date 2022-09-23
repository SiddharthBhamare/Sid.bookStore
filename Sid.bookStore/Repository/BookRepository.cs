using Sid.bookStore.Models;

namespace Sid.bookStore.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }
        public BookModel GetBookById(int aIntId)
        {
            BookModel lobjBookModel  = DataSource().Where(lobjBook => lobjBook.Id == aIntId).FirstOrDefault();
            if(lobjBookModel == null)
            {
                lobjBookModel = new BookModel();
            }
            return lobjBookModel;
        }
        public List<BookModel> SearchBook(string astrTitle, string astrAuthorName)
        {
            return DataSource().Where(lobjBook => lobjBook.Title.Contains(astrTitle)
            || lobjBook.Author.Contains(astrAuthorName)).ToList();
        }
        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel() { Id = 1, Title = "Java", Author = "Mahesh" },
                new BookModel() { Id = 2, Title = "C#", Author = "Rakesh" },
                new BookModel() { Id = 3, Title = "SQL", Author = "Shahrukh" },
                new BookModel() { Id = 1, Title = "React", Author = "Akshay" },
                new BookModel() { Id = 1, Title = "MongoDb", Author = "Avani" },
                new BookModel() { Id = 1, Title = "Angular", Author = "Ganesh" }
            };
        }
    }
}
