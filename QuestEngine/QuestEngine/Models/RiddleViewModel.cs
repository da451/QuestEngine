using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestEngine.Models
{
    public class RiddleViewModel
    {
        public RiddleModel Riddle { get; set; }

        public List<PromptModel> Prompts { get; set; }

        public void DeleteRiddlePrompt(int promptId)
        {
            if (promptId >= 0 && promptId < Riddle.Prompts.Count)
                Riddle.Prompts.RemoveAt(promptId);
        }

        public void AddRiddlePrompt(int promptId)
        {
            var prompt = Prompts.Single(x => x.Id == promptId);
            if (prompt!=null)
                Riddle.Prompts.Add(prompt);
        }
    }
}
