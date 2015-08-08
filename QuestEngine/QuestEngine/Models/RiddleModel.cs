using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestEngine.Models
{
    public class RiddleModel
    {
        public RiddleModel()
        {
            Quests = new List<QuestModel>();
            Prompts = new List<PromptModel>();
        }

        public int RiddleId { get; set; }


        public string Text { get; set; }

        public string Code { get; set; }

        public virtual ICollection<PromptModel> Prompts { get; set; }

        public virtual ICollection<QuestModel> Quests { get; set; }

    }
}
