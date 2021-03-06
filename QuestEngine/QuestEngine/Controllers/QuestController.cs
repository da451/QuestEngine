﻿using System;
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
    public class QuestController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Quest
        public ActionResult Index()
        {
            return View(db.Quests.ToList());
        }

        // GET: Quest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestModel questModel = db.Quests.Find(id);
            if (questModel == null)
            {
                return HttpNotFound();
            }
            return View(questModel);
        }

        // GET: Quest/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Quest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tag")] QuestModel questModel)
        {
            if (ModelState.IsValid)
            {
                db.Quests.Add(questModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(questModel);
        }

        // GET: Quest/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestModel questModel = db.Quests.Find(id);
            if (questModel == null)
            {
                return HttpNotFound();
            }
            return View(questModel);
        }

        // POST: Quest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tag")] QuestModel questModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(questModel);
        }

        // GET: Quest/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestModel questModel = db.Quests.Find(id);
            if (questModel == null)
            {
                return HttpNotFound();
            }
            return View(questModel);
        }

        // POST: Quest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuestModel questModel = db.Quests.Find(id);
            db.Quests.Remove(questModel);
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
