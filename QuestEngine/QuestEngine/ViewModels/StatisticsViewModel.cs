using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestEngine.ViewModels
{
    public class StatisticsViewModel
    {
        public StatisticsViewModel()
        {
            TeamSatistics = new List<TeamSatisticsViewModel>();
        }

        public List<TeamSatisticsViewModel> TeamSatistics { get; set; }
    }
}
