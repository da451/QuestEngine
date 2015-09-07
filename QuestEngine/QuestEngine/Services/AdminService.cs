using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestEngine.Models;

namespace QuestEngine.Services
{
    public class AdminService
    {

        private static object _lock = new object();

        public int ClearStatistics()
        {
            var context = new ApplicationDbContext();
            context.Statistics.RemoveRange(context.Statistics);
            context.SaveChanges();
            return context.Statistics.Count();
        }

        public int ClearProgress()
        {
            var res = 0;

            using (var context = new ApplicationDbContext())
            {
                foreach (var teamQuest in context.TeamQuests.ToList())
                {
                    teamQuest.RiddleId = null;
                    teamQuest.Riddle = null;
                    teamQuest.RiddleStarTime = null;
                    res++;
                }
                context.SaveChanges();
            }
            return res;

        }


    }
}
