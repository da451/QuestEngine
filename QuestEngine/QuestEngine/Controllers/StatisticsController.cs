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
    public class StatisticsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Statistics
        public ActionResult Index()
        {
            return View(db.Statistics.ToList());
        }

        // GET: Statistics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatisticsModel statisticsModel = db.Statistics.Find(id);
            if (statisticsModel == null)
            {
                return HttpNotFound();
            }
            return View(statisticsModel);
        }

        // GET: Statistics/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Statistics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TeamName,Riddle,StarTime")] StatisticsModel statisticsModel)
        {
            if (ModelState.IsValid)
            {
                db.Statistics.Add(statisticsModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(statisticsModel);
        }

        // GET: Statistics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatisticsModel statisticsModel = db.Statistics.Find(id);
            if (statisticsModel == null)
            {
                return HttpNotFound();
            }
            return View(statisticsModel);
        }

        // POST: Statistics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TeamName,Riddle,StarTime")] StatisticsModel statisticsModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statisticsModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(statisticsModel);
        }

        // GET: Statistics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatisticsModel statisticsModel = db.Statistics.Find(id);
            if (statisticsModel == null)
            {
                return HttpNotFound();
            }
            return View(statisticsModel);
        }

        // POST: Statistics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StatisticsModel statisticsModel = db.Statistics.Find(id);
            db.Statistics.Remove(statisticsModel);
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
