using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestEngine.ViewModels
{
    public class CurrentTeamRiddleViewModel
    {
        public CurrentTeamRiddleViewModel()
        {
            Prompts = new List<Tuple<string, DateTime>>();
        }

        public int Id { get; set; }
        public string TeamName { get; set; }

        public string RiddleText { get; set; }

        public DateTime RiddleStartTime { get; set; }

        public DateTime NextPrompTime { get; set; }

        public List<Tuple<string,DateTime>> Prompts { get; set; }
    }
}
