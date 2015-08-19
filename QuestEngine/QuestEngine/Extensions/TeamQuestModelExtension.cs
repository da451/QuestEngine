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
        public  static int GetCurrentRiddleIndex(this TeamQuestModel teamQuest)
        {
            return teamQuest.Quest.Riddles.FindIndex(x => x.Id == teamQuest.Riddle.Id) +1;
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
