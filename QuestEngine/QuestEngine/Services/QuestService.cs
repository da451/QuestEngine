using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using QuestEngine.Extensions;
using QuestEngine.Models;
using QuestEngine.ViewModels;

namespace QuestEngine.Services
{
    public class QuestService
    {

        private ApplicationDbContext dbQuest = new ApplicationDbContext();

         private static object _lock = new object();

        public CurrentTeamRiddleViewModel BuildRiddleForTeam(string teamName)
        {
            var teamQuest = getTeamQuest(teamName);
            var currentTeamRiddle = new CurrentTeamRiddleViewModel();

            RiddleModel currentRiddle = getCurrentRiddle(teamQuest);

            currentTeamRiddle.Id = currentRiddle.Id;
            currentTeamRiddle.IsTheEnd = teamQuest.IsTheEnd;
            currentTeamRiddle.TeamEmail = teamQuest.Team.Email;

            currentTeamRiddle.TeamName = teamQuest.Team.Name;

            currentTeamRiddle.RiddleText = currentRiddle.Text;

            currentTeamRiddle.RiddleNumber = teamQuest.GetCurrentRiddleNumber();

            TimeSpan nextPromptTime;

            currentTeamRiddle.Prompts = teamQuest.GetCurrentPromptList(out nextPromptTime);

            currentTeamRiddle.NextPrompTime = nextPromptTime;

            return currentTeamRiddle;
        }

        private TeamQuestModel getTeamQuest(string name)
        {
           return dbQuest.TeamQuests.Single(x => x.Team.Name == name);
        }
        /// <summary>
        /// Get current team riddle, if where is no current riddle,  will set it
        /// </summary>
        /// <param name="teamQuest"></param>
        /// <returns></returns>
        private RiddleModel getCurrentRiddle(TeamQuestModel teamQuest)
        {
            RiddleModel currentRiddle;

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

                new StatisticsService().Start(teamQuest.Team.Name, teamQuest.RiddleStarTime.Value);
            }

            return currentRiddle;
        }

        public bool IsRiddleCodeCorrect(CurrentTeamRiddleViewModel model)
        {
            var teamQuest = getTeamQuest(model.TeamName);
            var isCodeCorrect = teamQuest.Riddle.Code.ToLower() == model.Code.ToLower();
            var isRiddleSame = teamQuest.Riddle.Id == model.Id;

            return isCodeCorrect && isRiddleSame;
        }
        
        public bool IfRiddleCodeCorrectNextRiddle(CurrentTeamRiddleViewModel model)
        {
            lock (_lock)
            {
                if (IsRiddleCodeCorrect(model))
                {
                    nextRiddle(model);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void nextRiddle(CurrentTeamRiddleViewModel model)
        {
            var teamQuest = getTeamQuest(model.TeamName);
            var statisticsService = new StatisticsService();
            if (teamQuest.HasNextRiddle())
            {
                var nextRiddle = teamQuest.NextRiddle();
                teamQuest.RiddleId = nextRiddle.Id;
                teamQuest.RiddleStarTime = DateTime.Now;
                dbQuest.Entry(teamQuest).State = EntityState.Modified;
                dbQuest.SaveChanges();
                statisticsService.UpdateStatictics(model.TeamName);
            }
            else
            {
                teamQuest.IsTheEnd = true;
                dbQuest.Entry(teamQuest).State = EntityState.Modified;
                dbQuest.SaveChanges();
                statisticsService.Finish(model.TeamName);
            }
        }
    }
}
