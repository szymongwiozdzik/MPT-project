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
            User usr = new User();
            if (Request.Cookies["userInfp"] != null)
            {
                return RedirectToAction("Index");
            }
            return View(usr);
        }
        
        //action after login need to be applied. We have to find in a databe a proped id. Password should be hashed. It could be added, after database creation
        [HttpPost]
        public ActionResult Login(string ID, string HasPassword) // this method could also contain a permissions.
        {
            return View();
  
        }
        
        
        
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}