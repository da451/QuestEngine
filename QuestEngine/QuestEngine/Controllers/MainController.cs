using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuestEngine.Models;
using QuestEngine.ViewModels;

namespace QuestEngine.Controllers
{
    [Authorize]
    public class MainController : Controller
    {
        
        private QuestEngineContext dbQuest = new QuestEngineContext();

        //private A db = new QuestEngineContext();
        // GET: Main
        public ActionResult Index()
        {
            var userEmail = User.Identity.Name;
            
            var team = dbQuest.Teams.Single(x => x.Email == userEmail);

            var teamQuest = dbQuest.TeamQuests.Single(x => x.Team.Id == team.Id);

            RiddleModel currentRiddle = null;

            if (teamQuest.Riddle != null)
            {
                currentRiddle = teamQuest.Riddle;
            }
            else
            {
                currentRiddle = teamQuest.Quest.Riddles.First();

                teamQuest.RiddleStarTime = DateTime.Now;
            }

            var currentTeamRiddle = new CurrentTeamRiddleViewModel();

            currentTeamRiddle.TeamName = team.Name;

            currentTeamRiddle.RiddleText = currentRiddle.Text;

            if (teamQuest.RiddleStarTime.HasValue)
            {
                currentTeamRiddle.RiddleStartTime = teamQuest.RiddleStarTime.Value;

                foreach (var prompt in currentRiddle.Prompts)
                {
                    currentTeamRiddle.Prompts.Add(new Tuple<string, DateTime>(prompt.Text,
                        currentTeamRiddle.RiddleStartTime.AddMinutes(prompt.Time)));
                }
                
            }
                




            
            return View();
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
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
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
