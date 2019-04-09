using System.Web.Mvc;
using System.Linq;
using LibrarieOnline.Model;
using System.Web.Security;
using System.Collections.Generic;
using System.Web;

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
            FormsAuthentication.SetAuthCookie(data.UserName, false);
            var check = DB.User.FirstOrDefault(u => u.UserName.Equals(data.UserName) && u.Password == data.Password);
            if (check!=null)
            {
                return RedirectToAction("Index","Home",data);
            }
            
            return View();
        }


        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        

        [HttpPost]
        [AllowAnonymous]
        public JsonResult GetRoles()
        {
            List<UserRole> result = new List<UserRole>();
            List<UserRole> toateRolurileExtraseDinDB = DB.UserRole.ToList();
            foreach (UserRole role in toateRolurileExtraseDinDB)
            {
                result.Add(new UserRole()
                {
                    Role = role.Role,
                    RoleId = role.RoleId
                });
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Registration(User data)
        {
            User obj = new User();
            obj.UserName = data.UserName;
            obj.Password = data.Password;
            obj.RoleId = data.RoleId;

            DB.User.Add(obj);
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

