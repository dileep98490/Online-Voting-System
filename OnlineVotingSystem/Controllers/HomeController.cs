using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineVotingSystem.Models;


namespace OnlineVotingSystem.Controllers
{
    public class HomeController : Controller
    {

      
        public ActionResult Index()
        {
            ViewBag.msg = "";
            ViewBag.items = new[] { "Admin", "Student", "Candidate" };
            return View();
        }
        SystemDbNaya Db = new SystemDbNaya();
        public ActionResult About()
        {

            return View();
        }
        public ActionResult Login(User user)
        {
            try
            {
                var rev = Db.Users
                     .Single(r => r.UserId == user.UserId);
                if (rev.Password != user.Password)
                    throw new Exception();
               if (user.UserId == "Admin")
                   if (user.TypeOfUser != "Admin")
                   {
                       ViewBag.msg = "Incorrect Username or Password, Try again";
                       return View("Index");
                   }
                //if(user.TypeOfUser=="")
                //    if (rev.TypeOfUser != "Candidate")
                //    {
                //        ViewBag.msg = "Incorrect Username or Password, Try again";
                //        return View("Index");

                //    }

                if (user.TypeOfUser == "Admin")
                    return RedirectToAction("Index", "AdminVoter");
                else if (user.TypeOfUser == "Student")
                    return RedirectToAction("Profile", "VoterMain", new { ID = user.UserId });
                else
                    return RedirectToAction("Profile", "CandidateMain", new { ID = user.UserId });

            }
            catch
            {
                 
                ViewBag.msg = "Incorrect Username or Password, Try again";
                return View("Index");
            }

        }
    }
}
