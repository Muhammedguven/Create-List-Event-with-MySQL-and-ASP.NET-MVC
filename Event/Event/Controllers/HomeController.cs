using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Event.Models;
using System.Data.Entity;
namespace Event.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult EventList()
        {
            using (EventRegistrationDBEntities db = new EventRegistrationDBEntities())
            {
                return View(db.EventData.ToList());
            }

                
        }

        public ActionResult CreateNewEvent()
        {

            return View();
        }
        
        
        [HttpPost]
        public ActionResult CreateNewEvent(EventData eventModel)
        {
            if (ModelState.IsValid) { 
                using (EventRegistrationDBEntities db = new EventRegistrationDBEntities())
            {
                db.EventData.Add(eventModel);
                db.SaveChanges();
                
            }
                ModelState.Clear();
                ViewBag.message = "?";
                
            }
            return RedirectToAction(nameof(Thanks));

        }

        public ActionResult Thanks()
        {

            return View();
        }

        public ActionResult Main()
        {
            
            return View();
        }
        public ActionResult Index()
        {
          
            return View();
        }


        [HttpPost]
        public ActionResult Index(LoginData user)
        {
            using (EventRegistrationDBEntities db = new EventRegistrationDBEntities())
            {
                var usr = db.LoginDatas.Single(u => u.userName == user.userName && u.password == user.password);
                if (usr != null)
                {
                    return RedirectToAction(nameof(Main));
                }
                else
                {
                    ModelState.AddModelError("", "Username or password is wrong.");
                }
            }
            return View();
        }








        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}