using System.Web.Mvc;
using System.Linq;
using LibrarieOnline.Model;
using System.Web.Security;

namespace LibrarieOnline.Controllers
{
    public class AuthController : Controller
    {
        public readonly LibrarieEntities DB;
        public AuthController()
        {
            DB = new LibrarieEntities();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User data)
        {
            var check = DB.Users.FirstOrDefault(u => u.UserName.Equals(data.UserName));
            FormsAuthentication.SetAuthCookie(data.UserName, false);
            if (check!=null)
            {
                return RedirectToAction("Index","Home");
            }
            
            return View();
        }


        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Registration(User data)
        {
            User obj = new User();
            obj.UserName = data.UserName;
            obj.Password = data.Password;
            obj.RoleId = data.RoleId;

            DB.Users.Add(obj);
            DB.SaveChanges();

            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {

            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Auth");
            
        }

        
    }
}

