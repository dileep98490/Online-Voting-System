using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineVotingSystem.Models;

namespace OnlineVotingSystem.Controllers
{
    public class VoterMainController : Controller
    {
        //
        // GET: /VoterMain/
        SystemDbNaya Db = new SystemDbNaya();
        static string ID;
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /VoterMain/Details/5

        public ActionResult Profile(string id)
        {
            try
            {
                var voter = Db.Voters.Single(r => r.VoterId == id);
                ID = id;
                return View(voter);
            }
            catch
            {
                return RedirectToAction("Profile", new { id = ID });
            }
        }

 
        //
        // GET: /VoterMain/Edit/5
 
        public ActionResult Edit(string id)
        {
            var voter = Db.Voters.Single(r => r.VoterId == id);

            return View(voter);
        }

        //
        // POST: /VoterMain/Edit/5

        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var voter = Db.Voters.Single(r => r.VoterId == id);
                TryUpdateModel(voter);
                Db.SaveChanges();
                return RedirectToAction("Profile", new { ID = voter.VoterId });
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /VoterMain/Delete/5

        public ActionResult Vote()
        {
            try
            {
                var voter = Db.Voters.Single(r => r.VoterId == ID && r.Voted==0);
                var model = Db;
                ViewBag.items = new[] { "Technical", "Cultural", "FilmAndMusic", "Sports" };
                return View(model);
            }
            catch
            {

                return View("Voted");
            }
        }

        [HttpPost]
        public ActionResult Vote(string TechnicalId,string CulturalId,string FilmAndMusicId,string SportsId)
        {
            var vote = Db.Candidates
            .Single(r=>r.CandidateId==TechnicalId);
            vote.Votes = vote.Votes + 1;
            vote = Db.Candidates
.Single(r => r.CandidateId == CulturalId);
            vote.Votes = vote.Votes + 1;
            vote = Db.Candidates
            .Single(r => r.CandidateId == FilmAndMusicId);
            vote.Votes = vote.Votes + 1;
            vote = Db.Candidates
            .Single(r => r.CandidateId == SportsId);
            vote.Votes = vote.Votes + 1;
            Db.Voters.Single(r => r.VoterId == ID).Voted = 1;
            Db.SaveChanges();
            return View("Voted");
        }



        //For changing password of the voter
        public ActionResult ChangePassword()
        {
            var user = Db.Users.Single(r => r.UserId == ID);
            return View(user);
        }
        [HttpPost]
        public ActionResult ChangePassword(string OldPassword,string ConfirmPassword,User user)
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
