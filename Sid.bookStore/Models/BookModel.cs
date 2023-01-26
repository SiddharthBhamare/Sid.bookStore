using Sid.bookStore.Helpers;
using System.ComponentModel.DataAnnotations;
namespace Sid.bookStore.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [AppValidations( ErrorMessage = "Please Enter the title")]
        public string Title { get; set; }
        [AppValidations(ErrorMessage = "Please Enter the Author Name")]       
        public string Author { get; set; }
        public string Description { get; set; }
        [AppValidations(ErrorMessage = "Please Enter the Book Pages")]
        public double? TotalPages { get; set; }
        [AppValidations(ErrorMessage = "Please Enter the Book Language")]
        public string Language { get; set; }
        [AppValidations(ErrorMessage = "Please Enter the Book Category")]
        public string Category { get; set; }
    }
}
