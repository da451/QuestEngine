using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                teamQuest.RiddleId = currentRiddle.Id;


                dbQuest.Entry(teamQuest).State = EntityState.Modified;
                dbQuest.SaveChanges();
            }

            var currentTeamRiddle = new CurrentTeamRiddleViewModel();

            currentTeamRiddle.TeamName = team.Name;
            
            currentTeamRiddle.RiddleText = currentRiddle.Text;

            var r = teamQuest.Quest.Riddles.Single(x => x.Id == currentRiddle.Id);

            currentTeamRiddle.RiddleNumber = teamQuest.Quest.Riddles.IndexOf(r) + 1;


            if (teamQuest.RiddleStarTime.HasValue)
            {
                currentTeamRiddle.RiddleStartTime = teamQuest.RiddleStarTime.Value;

                foreach (var prompt in currentRiddle.Prompts)
                {
                    if (teamQuest.RiddleStarTime.Value.AddMinutes(prompt.Time) < DateTime.Now)
                    {
                        currentTeamRiddle.Prompts.Add(prompt.Text);
                    }
                    else
                    {
                        currentTeamRiddle.NextPrompTime = (teamQuest.RiddleStarTime.Value.AddMinutes(prompt.Time) - DateTime.Now);
                        break;
                    }
                }
            }

            return View(currentTeamRiddle);
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
