using LibrarieOnline.Model;
using System;
using System.Collections.Generic;
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


        [Authorize(Roles ="admin")]
        public ActionResult UploadFiles()
        {
            

            return View();
        }
        
        

    }
}