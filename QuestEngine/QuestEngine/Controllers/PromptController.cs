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
    public class PromptController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Prompt
        public ActionResult Index()
        {
            var prompts = db.Prompts.Include(p => p.Riddle);
            return View(prompts.ToList());
        }

        // GET: Prompt/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PromptModel promptModel = db.Prompts.Find(id);
            if (promptModel == null)
            {
                return HttpNotFound();
            }
            return View(promptModel);
        }

        // GET: Prompt/Create
        public ActionResult Create()
        {
            ViewBag.RiddleId = new SelectList(db.Riddles, "Id", "Caption");
            return View();
        }

        // POST: Prompt/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Caption,Text,Number,RiddleId,Time")] PromptModel promptModel)
        {
            if (ModelState.IsValid)
            {
                db.Prompts.Add(promptModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RiddleId = new SelectList(db.Riddles, "Id", "Caption", promptModel.RiddleId);
            return View(promptModel);
        }

        // GET: Prompt/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PromptModel promptModel = db.Prompts.Find(id);
            if (promptModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.RiddleId = new SelectList(db.Riddles, "Id", "Caption", promptModel.RiddleId);
            return View(promptModel);
        }

        // POST: Prompt/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Caption,Text,Number,RiddleId,Time")] PromptModel promptModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(promptModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RiddleId = new SelectList(db.Riddles, "Id", "Caption", promptModel.RiddleId);
            return View(promptModel);
        }

        // GET: Prompt/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PromptModel promptModel = db.Prompts.Find(id);
            if (promptModel == null)
            {
                return HttpNotFound();
            }
            return View(promptModel);
        }

        // POST: Prompt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PromptModel promptModel = db.Prompts.Find(id);
            db.Prompts.Remove(promptModel);
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
