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
    public class TeamQuestController : Controller
    {
        private QuestEngineContext db = new QuestEngineContext();

        // GET: TeamQuest
        public ActionResult Index()
        {
            var teamQuests = db.TeamQuests.Include(t => t.Riddle).Include(t => t.Team);
            return View(teamQuests.ToList());
        }

        // GET: TeamQuest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamQuestModel teamQuestModel = db.TeamQuests.Find(id);
            if (teamQuestModel == null)
            {
                return HttpNotFound();
            }
            return View(teamQuestModel);
        }

        // GET: TeamQuest/Create
        public ActionResult Create()
        {
            ViewBag.RiddleId = new SelectList(db.Riddles, "Id", "Caption");
            ViewBag.Id = new SelectList(db.Teams, "TeamQuestId", "Name");
            return View();
        }

        // POST: TeamQuest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TeamId,RiddleId,RiddleStarTime")] TeamQuestModel teamQuestModel)
        {
            if (ModelState.IsValid)
            {
                db.TeamQuests.Add(teamQuestModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RiddleId = new SelectList(db.Riddles, "Id", "Caption", teamQuestModel.RiddleId);
            ViewBag.Id = new SelectList(db.Teams, "TeamQuestId", "Name", teamQuestModel.Id);
            return View(teamQuestModel);
        }

        // GET: TeamQuest/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamQuestModel teamQuestModel = db.TeamQuests.Find(id);
            if (teamQuestModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.RiddleId = new SelectList(db.Riddles, "Id", "Caption", teamQuestModel.RiddleId);
            ViewBag.Id = new SelectList(db.Teams, "TeamQuestId", "Name", teamQuestModel.Id);
            return View(teamQuestModel);
        }

        // POST: TeamQuest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TeamId,RiddleId,RiddleStarTime")] TeamQuestModel teamQuestModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teamQuestModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RiddleId = new SelectList(db.Riddles, "Id", "Caption", teamQuestModel.RiddleId);
            ViewBag.Id = new SelectList(db.Teams, "TeamQuestId", "Name", teamQuestModel.Id);
            return View(teamQuestModel);
        }

        // GET: TeamQuest/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamQuestModel teamQuestModel = db.TeamQuests.Find(id);
            if (teamQuestModel == null)
            {
                return HttpNotFound();
            }
            return View(teamQuestModel);
        }

        // POST: TeamQuest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeamQuestModel teamQuestModel = db.TeamQuests.Find(id);
            db.TeamQuests.Remove(teamQuestModel);
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
