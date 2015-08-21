using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestEngine.Models;

namespace QuestEngine.Extensions
{
    public static class TeamQuestModelExtension
    {
        public  static int GetCurrentRiddleNumber(this TeamQuestModel teamQuest)
        {
            return teamQuest.Quest.Riddles.FindIndex(x => x.Id == teamQuest.Riddle.Id) +1;
        }

        public static int GetCurrentRiddleIndex(this TeamQuestModel teamQuest)
        {
            return teamQuest.Quest.Riddles.FindIndex(x => x.Id == teamQuest.Riddle.Id);
        }
        public static bool HasNextRiddle(this TeamQuestModel teamQuest)
        {
            int current = teamQuest.GetCurrentRiddleIndex();
            return teamQuest.Quest.Riddles.Count > current + 1;
        }
        public static RiddleModel NextRiddle(this TeamQuestModel teamQuest)
        {
            int current = teamQuest.GetCurrentRiddleIndex();
            if (teamQuest.Quest.Riddles.Count > current + 1)
            {
                return teamQuest.Quest.Riddles[current + 1];
            }

            return null;
        }


        public static List<string> GetCurrentPromptList(this TeamQuestModel teamQuest, out TimeSpan nextPrompTime)
        {
            var prompts = new List<string>();
            nextPrompTime = new TimeSpan();

            var dateTimeNow = DateTime.Now;

            if (teamQuest.RiddleStarTime.HasValue)
            {
                foreach (var prompt in teamQuest.Riddle.Prompts)
                {
                    if (teamQuest.RiddleStarTime.Value.AddMinutes(prompt.Time) < dateTimeNow)
                    {
                        prompts.Add(prompt.Text);
                    }
                    else
                    {
                        nextPrompTime = (teamQuest.RiddleStarTime.Value.AddMinutes(prompt.Time) - dateTimeNow);
                        break;
                    }
                }
            }

            return prompts;
        }
    }
}
