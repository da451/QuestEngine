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
    [Authorize(Users = "Administrator")]
    public class RiddleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Riddle
        public ActionResult Index()
        {
            return View(db.Riddles.ToList());
        }

        // GET: Riddle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RiddleModel riddleModel = db.Riddles.Find(id);
            if (riddleModel == null)
            {
                return HttpNotFound();
            }
            return View(riddleModel);
        }

        // GET: Riddle/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Riddle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Caption,Text,Code")] RiddleModel riddleModel)
        {
            if (ModelState.IsValid)
            {
                db.Riddles.Add(riddleModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(riddleModel);
        }

        // GET: Riddle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RiddleModel riddleModel = db.Riddles.Find(id);
            if (riddleModel == null)
            {
                return HttpNotFound();
            }
            return View(riddleModel);
        }

        // POST: Riddle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Caption,Text,Code")] RiddleModel riddleModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(riddleModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(riddleModel);
        }

        // GET: Riddle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RiddleModel riddleModel = db.Riddles.Find(id);
            if (riddleModel == null)
            {
                return HttpNotFound();
            }
            return View(riddleModel);
        }

        // POST: Riddle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RiddleModel riddleModel = db.Riddles.Find(id);
            db.Riddles.Remove(riddleModel);
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
