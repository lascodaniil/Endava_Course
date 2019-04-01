using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibrarieOnline.Controllers
{
    public class BookController : Controller
    {
        [Authorize(Roles ="admin")]
        public ActionResult UploadFiles()
        {
            return View();
        }
    }
}