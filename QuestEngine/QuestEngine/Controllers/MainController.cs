using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuestEngine.Models;
using QuestEngine.Services;
using QuestEngine.ViewModels;

namespace QuestEngine.Controllers
{
    [Authorize]
    public class MainController : Controller
    {

        private ApplicationDbContext dbQuest = new ApplicationDbContext();

        private QuestService questService = new QuestService();

        // GET: Main
        public ActionResult Index()
        {
            var userName = User.Identity.Name;
            
            return View(questService.BuildRiddleForTeam(userName));
        }

        // GET: Main/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Main/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Main/Create
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

        // GET: Main/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Main/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Tag")] QuestModel questModel)
        public ActionResult Index([Bind(Include = "Id,Code,TeamEmail")] CurrentTeamRiddleViewModel model)
        {
            try
            {
                questService.IfRiddleCodeCorrectNextRiddle(model);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Main/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Main/Delete/5
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
    }
}
