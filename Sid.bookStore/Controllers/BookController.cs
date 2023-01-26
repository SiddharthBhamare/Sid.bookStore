using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sid.bookStore.Models;
using Sid.bookStore.Repository;

namespace Sid.bookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        public BookController(BookRepository aObjBookRepository)
        {
            _bookRepository = aObjBookRepository;
        }
        public async Task<IActionResult> GetAllBooks()
        {
            var data = await _bookRepository.GetAllBooks();
            return View(data);
        }
        public async Task<IActionResult> GetBook(int aIntBookId)
        {
            BookModel data = await _bookRepository.GetBookById(aIntBookId);
            return View(data);
        }
        public async Task<List<BookModel>> SearchBook(string astrBookName, string astrAuthorName)
        {
            return await _bookRepository.SearchBook(astrBookName, astrAuthorName);
        }
        [HttpPost]
        public async Task<IActionResult> AddBook(BookModel aObjBookModel)
        {
            if (ModelState.IsValid)
            {
                int lintId = await _bookRepository.AddNewBook(aObjBookModel);
                if (lintId > 0)
                {
                    return RedirectToAction(nameof(AddBook), new { isSuccess = true, aintBookId = lintId });
                }
            }
            else
            {
                TempData["IsSuccess"] = false;
                TempData["BookId"] = 0;
            }
            return View();
        }
        public ActionResult AddBook(bool isSuccess = false, int aintBookId = 0)
        {
            if (TempData["IsSuccess"] == null)
            {
                TempData["IsSuccess"] = isSuccess;
                TempData["BookId"] = aintBookId;
                ViewBag.Languages = GetLanguages();
            }
            return View();
        }
        private List<SelectListItem> GetLanguages()
        {
            SelectListGroup lGroup1 = new SelectListGroup() { Name = "Group1" };
            SelectListGroup lGroup2 = new SelectListGroup() { Name = "Group2" };
            SelectListGroup lGroup3 = new SelectListGroup() { Name = "Group3", Disabled = true };
            return new List<SelectListItem>()
            {
                new SelectListItem() {Text="Hindi",Value="1",Group=lGroup1},
                new SelectListItem() {Text="Marathi",Value="2",Group=lGroup1},
                new SelectListItem() {Text="Sanskrit",Value="3",Group=lGroup1},
                new SelectListItem() {Text="English",Value="4",Group=lGroup1},
                new SelectListItem() {Text="Chinese",Value="5",Group=lGroup2},
                new SelectListItem() {Text="Japanese",Value="6",Group=lGroup2},
                new SelectListItem() {Text="Korean",Value="7",Group=lGroup2},
                new SelectListItem() {Text="French",Value="8",Group=lGroup3},
                new SelectListItem() {Text="German",Value="10",Group=lGroup3},
                new SelectListItem() {Text="Dutch",Value="11",Group=lGroup3}
            };
        }
    }
}
