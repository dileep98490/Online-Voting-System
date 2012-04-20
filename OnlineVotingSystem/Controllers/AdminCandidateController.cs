using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineVotingSystem.Models;

namespace OnlineVotingSystem.Controllers
{
    public class AdminCandidateController : Controller
    {
        //
        // GET: /AdminCandidate/
        SystemDbNaya Db = new SystemDbNaya();
        public PartialViewResult Search(string q,string Filter)
        {                  var candidates = Db.Candidates.Where(r => r.Society.Contains(q));
            switch (Filter)
            {
                case "Candidate ID": candidates = Db.Candidates.Where(r => r.CandidateId.Contains(q)); break;
                case "Society": candidates = Db.Candidates.Where(r => r.Society.Contains(q)); break;

            }
   
            return PartialView("_CandidatesDisplay", candidates);

        }
        public ActionResult Index()
        {
            var candidates = Db.Candidates;
            return View(candidates);
        }

        //
        // GET: /AdminCandidate/Details/5

        public ActionResult Details(string CandidateId)
        {
            var candidate = Db.Candidates
                .Single(r => r.CandidateId == CandidateId);
            var voter = Db.Voters.Single(r => r.VoterId == CandidateId);
                  ViewBag.name=voter.Name;
            ViewBag.email=voter.EMail;

            return View(candidate);
        }

        //
        // GET: /AdminCandidate/Create

        public ActionResult Create()
        {
            return View(new Candidate());
        } 

        //
        // POST: /AdminCandidate/Create

        [HttpPost]
        public ActionResult Create(Candidate candidate)
        {
            try
            {
                var candidates = Db.Candidates;
                candidates.Add(candidate);
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
        // GET: /AdminCandidate/Edit/5
 
        public ActionResult Edit(string CandidateId )
        {
            var candidate = Db.Candidates.Single(r => r.CandidateId == CandidateId);

            return View(candidate);
        }

        //
        // POST: /AdminCandidate/Edit/5

        [HttpPost]
        public ActionResult Edit(string CandidateId, FormCollection collection)
        {
            try
            {
                var candidate = Db.Candidates.Single(r => r.CandidateId == CandidateId);
                TryUpdateModel(candidate);
                Db.SaveChanges();

                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /AdminCandidate/Delete/5
 
        public ActionResult Delete(string CandidateId)
        {
            var candidate = Db.Candidates.Single(r => r.CandidateId == CandidateId);

            return View(candidate );
        }

        //
        // POST: /AdminCandidate/Delete/5

        [HttpPost]
        public ActionResult Delete(string CandidateId, FormCollection collection)
        {
            try
            {
                var candidate = Db.Candidates;
                candidate.Remove(Db.Candidates.Single(r => r.CandidateId == CandidateId));
                Db.SaveChanges();
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
