using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MPT.Models;

namespace MPT.Controllers
{
    public class HomeController : Controller
    {
       public ActionResult Login()
        {
            Users model = new Users();
            //User usr = new User();
            if (Request.Cookies["userInfp"] != null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        
        //action after login need to be applied. We have to find in a databe a proped id. Password should be hashed. It could be added, after database creation
        [HttpPost]
        public ActionResult Login(string ID, string HasPassword) // this method could also contain a permissions.
        {
            if (ID == null || HasPassword == null)
            {
                ModelState.AddModelError("", "Enter your login and password");
                return View();
            }
            using (MPTDatabaseEntities db = new MPTDatabaseEntities())
            {
                var database = (from c in db.Users
                                where c.ID == ID select new { c.HasPassword, c.Surname, c.Name }).ToList();

                if (database.Count == 0)
                {
                    ModelState.AddModelError("", "There is no user with this ID");
                }
                else
                {
                    foreach (var c in database)
                    {
                        if(c.HasPassword.Equals(HasPassword.GetHashCode().ToString()))
                        {
                            HttpCookie cookies = new HttpCookie("userInfo"); //cookies

                            cookies["UserName"] = ID;
                            cookies["LoggedNameSurname"] = Server.UrlEncode(c.Name + " " + c.Surname);
                            Response.Cookies.Add(cookies);
                            ModelState.AddModelError("", "Log in successfully");
                            if (Session["PreviousRoute"] != null)
                                return Redirect((string)Session["PreviousRoute"]);
                            else
                                return RedirectToAction("Calendar");
                        }
                    }
                    ModelState.AddModelError("", "Wrong password");

                    return View(); //Bad password

                }
            }
            return View();
        }

        public ActionResult Register()
        {
            //RegisterViewModel model = new RegisterViewModel();
            //return View(model);
            return View();
        }

        [HttpPost]
        public ActionResult Register(Users model)
        {
            if(ModelState.IsValid)
            {
                using (MPTDatabaseEntities db = new MPTDatabaseEntities())
                {
                    var usr = (from u in db.Users
                               where u.ID == model.ID
                               select u).ToList();
                    if (usr.Count == 0)
                    {
                        Users user = new Users
                        {                        
                            Name = model.Name,
                            Surname = model.Surname,
                            ID = model.ID,
                            HasPassword = model.HasPassword.GetHashCode().ToString()
                        };
                        db.Users.Add(user);
                        db.SaveChanges();

                        HttpCookie cookies = new HttpCookie("userInfo");
                        cookies["UserName"] = user.ID;
                        cookies["LoggedNameSurname"] = Server.UrlEncode(user.Name + " " + user.Surname);
                        Response.Cookies.Add(cookies);

                        return RedirectToAction("Calendar");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Użytkownik o takim ID już istnieje");
                        //we'll read data from cookies
                        return View();
                    }
                }
            }


            return View(model);
        }




        public ActionResult Calendar()
        {
            return View();
        }

        public JsonResult GetEvents()
        {
            using(MPTDatabaseEntities dc = new MPTDatabaseEntities())
            {
                var events = dc.Events.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        
        
        
        
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}