using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using QuestEngine.Extensions;
using QuestEngine.Models;
using QuestEngine.ViewModels;

namespace QuestEngine.Services
{
    public class StatisticsService
    {
        public const int FinishCode = 451;
        public const int StarthCode = 1;
        private ApplicationDbContext context = new ApplicationDbContext();



        private static object _lock = new object();

        public void UpdateStatictics(string teamName)
        {
            var teamQuest = context.TeamQuests.Single(x => x.Team.Name == teamName);

            var teamStatistics = context.Statistics.Where(x => x.TeamName == teamName);

            var riddleNumber = teamStatistics.Max(x => x.Riddle);
            var currentRiddleNumber = teamQuest.GetCurrentRiddleNumber();
            if (currentRiddleNumber != riddleNumber && teamQuest.RiddleStarTime.HasValue)
            {
                CreateStatistics(teamName, currentRiddleNumber, teamQuest.RiddleStarTime.Value);
            }
        }

        private void CreateStatistics(string teamName, int currentRiddleNumber, DateTime riddleStarTime)
        {
            TeamQuestModel teamQuest;
            var statistic = new StatisticsModel()
            {
                Riddle = currentRiddleNumber,
                StarTime = riddleStarTime,
                TeamName = teamName
            };

            context.Statistics.Add(statistic);

            context.SaveChanges();
        }

        public void Start(string teamName, DateTime riddleStarTime)
        {
            CreateStatistics(teamName, StarthCode, riddleStarTime);
        }

        public void Finish(string teamName)
        {
            CreateStatistics(teamName, FinishCode, DateTime.Now);
        }

        public StatisticsViewModel GetStatistics()
        {
            var statistics  = context.Statistics;

            var statisticsVM = new StatisticsViewModel();

            foreach (var s in statistics)
            {
                var teamSatistics =  statisticsVM.TeamSatistics.SingleOrDefault(x => x.TeamName == s.TeamName);
                if (teamSatistics == null)
                {
                    teamSatistics = new TeamSatisticsViewModel();
                    teamSatistics.TeamName = s.TeamName;
                    statisticsVM.TeamSatistics.Add(teamSatistics);
                }

                teamSatistics.Riddles.Add(new RiddlesViewModel()
                {
                    StatTime = s.StarTime,
                    RiddleNumber = s.Riddle
                });
            }

            return statisticsVM;

        }
    }
}
