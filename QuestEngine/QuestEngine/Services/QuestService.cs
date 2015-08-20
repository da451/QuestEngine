using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestEngine.Extensions;
using QuestEngine.Models;
using QuestEngine.ViewModels;

namespace QuestEngine.Services
{
    public class QuestService
    {

        private QuestEngineContext dbQuest = new QuestEngineContext();

        public CurrentTeamRiddleViewModel BuildRiddleForTeam(string teamEmail)
        {
            var teamQuest = getTeamQuest(teamEmail);

            RiddleModel currentRiddle = getCurrentRiddle(teamQuest);

            var currentTeamRiddle = new CurrentTeamRiddleViewModel();

            currentTeamRiddle.Id = currentRiddle.Id;

            currentTeamRiddle.TeamName = teamQuest.Team.Name;

            currentTeamRiddle.RiddleText = currentRiddle.Text;

            currentTeamRiddle.RiddleNumber = teamQuest.GetCurrentRiddleIndex();

            TimeSpan nextPromptTime;

            currentTeamRiddle.Prompts = teamQuest.GetCurrentPromptList(out nextPromptTime);

            currentTeamRiddle.NextPrompTime = nextPromptTime;

            return currentTeamRiddle;
        }

        private TeamQuestModel getTeamQuest(string email)
        {
           return dbQuest.TeamQuests.Single(x => x.Team.Email == email);
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
            }

            return currentRiddle;
        }
    }
}
