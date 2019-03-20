using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibrarieOnline.Models;

namespace LibrarieOnline.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Books()
        {
            var books = new List<Book>() {
                new Book()
                {
                    ID = 1,
                    Name = "Song of Ice and Fire",
                    Description = "Action Fantasy",
                    auth = new Author
                    {
                        NR_carti = 1,
                        Name ="Nicolae ",
                        LastName = "Dabija"
                    }
                }
            };
            return View(books);
        }
    }
}