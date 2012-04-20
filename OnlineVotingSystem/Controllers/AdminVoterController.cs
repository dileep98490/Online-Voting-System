using System.Linq;
using System.Web.Mvc;
using OnlineVotingSystem.Models;

namespace OnlineVotingSystem.Controllers
{
    public class AdminVoterController : Controller
    {
        //
        // GET: /AdminVoter/
        SystemDbNaya Db = new SystemDbNaya();
        public ActionResult Index()
        {
            var voters = Db.Voters;
            return View(voters);
        }

        //
        // GET: /AdminVoter/Details/5
           
        public ActionResult Details(string VoterId)
        {
            var re = Db.Voters
                .Single(r => r.VoterId == VoterId);

            return View(re);
        }

        //
        // GET: /AdminVoter/Create

        public ActionResult Create()
        {
            return View(new Voter());
        } 

        //
        // POST: /AdminVoter/Create

        [HttpPost]
        public ActionResult Create(Voter voter)
        {
            try
            {
                var rev = Db.Voters;
                rev.Add(voter);//Adding the voters, in the next step, we will be adding the user too

                var user = Db.Users;
                user.Add(new User
                {
                    UserId = voter.VoterId,
                    Password = voter.VoterId,
                    TypeOfUser = "Student"
                });

                Db.SaveChanges();

                // TODO: Add insert logic here
              
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /AdminVoter/Edit/5
 
        public ActionResult Edit(string VoterId)
        {
            var voter = Db.Voters.Single(r => r.VoterId == VoterId);

            return View(voter);
        }

        //
        // POST: /AdminVoter/Edit/5

        [HttpPost]
        public ActionResult Edit(string VoterId, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
               var voter = Db.Voters.Single(r => r.VoterId == VoterId);
               TryUpdateModel(voter);
               Db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /AdminVoter/Delete/5
 
        public ActionResult Delete(string VoterId)
        {
            var voter = Db.Voters
                .Single(r => r.VoterId == VoterId);

            return View(voter);
        }

        //
        // POST: /AdminVoter/Delete/5

        [HttpPost]
        public ActionResult Delete(string VoterId, FormCollection collection)
        {   //No two strings can have same number of arguements
            try
            {
                var voter = Db.Voters;
                voter.Remove(voter.Single(r => r.VoterId == VoterId));
                var user = Db.Users;
                user.Remove(user.Single(r => r.UserId == VoterId));
                Db.SaveChanges();
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Voting()
        {
            ViewBag.items = new[] { "Technical", "Cultural", "FilmAndMusic", "Sports" };
            return View(Db);
        }

         //For change password option
        public ActionResult ChangePassword()
        {
                         
            return View();
        }

        public PartialViewResult search(string q, string Filter)
        {
            var voters = Db.Voters.Where(r => r.Name.Contains(q));
            switch (Filter)
            {
                case "Name": voters = Db.Voters.Where(r => r.Name.Contains(q)); break;

                case "Department": voters = Db.Voters.Where(r => r.Department.Contains(q)); break;
                case "E-mail": voters = Db.Voters.Where(r => r.EMail.Contains(q)); break;
                

            }
           /// var voters = Db.Voters.Where(r => r.Name.Contains(q));
            return PartialView("_VotersDisplay", voters);


        }
        //public ActionResult QuickSearch(string term)
        //{
        //    var voter = Db.Voters
        //        .Where(r => r.Name.Contains(term))
        //        .Take(10)
        //        .Select(r => new { label = r.Name });
        //    return Json(voter, JsonRequestBehavior.AllowGet);

        //}

    }
}
