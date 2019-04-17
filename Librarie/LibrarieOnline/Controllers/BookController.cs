using LibrarieOnline.Model;
using LibrarieOnline.Model.DTO;
using System;
using System.Linq;
using System.Web.Mvc;


namespace LibrarieOnline.Controllers
{
    public class BookController : Controller
    {
        public readonly LibrarieEntities DB;
        public BookController()
        {
            DB = new LibrarieEntities();
        }

        [Authorize(Roles = "admin")]
        public ActionResult UploadFiles()
        {
            BookViewModel obj = new BookViewModel();

            obj.author = DB.Author.ToList();
            obj.category = DB.Category.ToList();
            obj.publisher = DB.Publisher.ToList();
            return View(obj);
        }

        [HttpPost]
        public ActionResult UploadFiles(BookViewModel book)
        {
            Book n_book = new Book();
            n_book.AuthorId = book.AuthorId;
            n_book.CategoryId = book.CategoryId;
            n_book.DateWhenWasAdded = DateTime.Now;
            n_book.Description = "hgfds";
            n_book.Price = book.Price;
            n_book.PublisherId = book.PublisherId;
            n_book.Title = book.Title;

            DB.Book.Add(n_book);
            DB.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}