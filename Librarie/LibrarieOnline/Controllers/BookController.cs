using LibrarieOnline.Model;
using LibrarieOnline.Model.DTO;
using System;
using System.IO;
using System.Linq;
using System.Web;
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
        [Authorize(Roles = "admin")]
        public ActionResult UploadFiless()
        {
            HttpFileCollectionBase files = Request.Files;
            HttpPostedFileBase file = files[0];
            BinaryReader binaryReader = new BinaryReader(file.InputStream);
            byte[] imageInBinaryFormat = binaryReader.ReadBytes(file.ContentLength);

            try
            {
                Book book = DB.Book.Create();

                book.Title = Request.Form["Title"];
                book.Price = Convert.ToDouble(Request.Form["Price"]);
                book.CategoryId = Convert.ToInt32(Request.Form["DropDownCategoryId"]);
                book.AuthorId = Convert.ToInt32(Request.Form["DropDownAuthorId"]);
                book.PublisherId = Convert.ToInt32(Request.Form["DropDownPublisherId"]);
                book.Description = Request.Form["Description"];
                book.Image = imageInBinaryFormat;
                book.DateWhenWasAdded = DateTime.Now;

                DB.Book.Add(book);
                DB.SaveChanges();

            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }

            return Json("Succes", JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetBooks()
        {
            var Books = DB.Book.ToList();

            return View(Books);
        }
    }
}