using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineVotingSystem.Models;

namespace OnlineVotingSystem.Controllers
{
    public class CandidateMainController : Controller
    {
        static string ID;
        //
        // GET: /CandidateMain/
        SystemDbNaya Db = new SystemDbNaya();
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /CandidateMain/Details/5

        public ActionResult Profile(string id)
        {
            if (id == null)
                id = ID;
            ID = id;
            var candidate = Db.Candidates.Single(r => r.CandidateId == id);

            return View(candidate);
        }

        //
        // GET: /CandidateMain/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /CandidateMain/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /CandidateMain/Edit/5
 
        public ActionResult Edit(string id)
        {
            var candidate = Db.Candidates.Single(r => r.CandidateId == id);
            return View(candidate);
        }

        //
        // POST: /CandidateMain/Edit/5

        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                var candidate = Db.Candidates.Single(r => r.CandidateId == id);
                TryUpdateModel(candidate);
                // TODO: Add update logic here
                Db.SaveChanges();
                return RedirectToAction("Profile", new { ID = candidate.CandidateId });
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /CandidateMain/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /CandidateMain/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //For changing password of the Candidate
        public ActionResult ChangePassword()
        {
            var user = Db.Users.Single(r => r.UserId == ID);
            return View(user);
        }
        [HttpPost]
        public ActionResult ChangePassword(string OldPassword, string ConfirmPassword, User user)
        {
            try
            {
                var us = Db.Users.Single(r => r.UserId == ID);
                if (OldPassword == us.Password)
                {
                    if (user.Password == ConfirmPassword)
                    {
                        TryUpdateModel(us);
                        Db.SaveChanges();
                        return View("ChangeSuccessful");
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                else
                    throw new Exception();

            }
            catch
            {
                // ViewBag.message="The Passwords don't match or your old password is wrong. Please try again";



                return View();
            }

        }
      
    }
}
