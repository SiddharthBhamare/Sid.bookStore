using Microsoft.AspNetCore.Mvc;
using Sid.bookStore.Models;
using Sid.bookStore.Repository;

namespace Sid.bookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        public BookController()
        {
            _bookRepository = new BookRepository(); 
        }
        public ActionResult GetAllBooks()
        {
            var data= _bookRepository.GetAllBooks();
            return View();
        }
        public BookModel GetBook(int aIntBookId)
        {
            return _bookRepository.GetBookById(aIntBookId); 
        }
        public List<BookModel> SearchBook(string astrBookName,string astrAuthorName)
        {
            return _bookRepository.SearchBook(astrBookName, astrAuthorName);
        }
    }
}
