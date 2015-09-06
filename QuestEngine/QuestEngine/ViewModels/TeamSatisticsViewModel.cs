using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestEngine.ViewModels
{
    public class TeamSatisticsViewModel
    {
        public TeamSatisticsViewModel()
        {
            Riddles = new List<RiddlesViewModel>();
        }

        public string TeamName { get; set; }

        public List<RiddlesViewModel> Riddles { get; set; }
    }
}
