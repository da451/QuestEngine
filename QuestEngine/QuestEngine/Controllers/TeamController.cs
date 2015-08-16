using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuestEngine.Models;

namespace QuestEngine.Controllers
{
    public class TeamController : Controller
    {
        private QuestEngineContext db = new QuestEngineContext();

        // GET: Team
        public ActionResult Index()
        {
            var teams = db.Teams;
            return View(teams.ToList());
        }

        // GET: Team/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamModel teamModel = db.Teams.Find(id);
            if (teamModel == null)
            {
                return HttpNotFound();
            }
            return View(teamModel);
        }

        // GET: Team/Create
        public ActionResult Create()
        {
            ViewBag.TeamQuestId = new SelectList(db.TeamQuests, "Id", "Id");
            return View();
        }

        // POST: Team/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeamQuestId,Id,Name")] TeamModel teamModel)
        {
            if (ModelState.IsValid)
            {
                db.Teams.Add(teamModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.TeamQuestId = new SelectList(db.TeamQuests, "Id", "Id", teamModel.TeamQuestId);
            return View(teamModel);
        }

        // GET: Team/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamModel teamModel = db.Teams.Find(id);
            if (teamModel == null)
            {
                return HttpNotFound();
            }
            //ViewBag.TeamQuestId = new SelectList(db.TeamQuests, "Id", "Id", teamModel.TeamQuestId);
            return View(teamModel);
        }

        // POST: Team/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeamQuestId,Id,Name")] TeamModel teamModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teamModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.TeamQuestId = new SelectList(db.TeamQuests, "Id", "Id", teamModel.TeamQuestId);
            return View(teamModel);
        }

        // GET: Team/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamModel teamModel = db.Teams.Find(id);
            if (teamModel == null)
            {
                return HttpNotFound();
            }
            return View(teamModel);
        }

        // POST: Team/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeamModel teamModel = db.Teams.Find(id);
            db.Teams.Remove(teamModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
