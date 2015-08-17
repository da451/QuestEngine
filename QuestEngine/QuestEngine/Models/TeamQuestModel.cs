using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestEngine.Models
{
    public class TeamQuestModel
    {
        public int Id { get; set; }

         [ForeignKey("Team")]
        public int? TeamId { get; set; }

        public virtual TeamModel Team { get; set;}

        public int? RiddleId { get; set; }
        public virtual RiddleModel Riddle { get; set; }

        public DateTime? RiddleStarTime { get; set; }

        public int QuestId { get; set; }
        public virtual QuestModel Quest { get; set; }

    }
}
