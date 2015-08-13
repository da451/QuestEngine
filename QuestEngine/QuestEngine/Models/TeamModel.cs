using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestEngine.Models
{
    public class TeamModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Key, ForeignKey("TeamQuest")]
        public int TeamQuestId { get; set; }

        public virtual TeamQuestModel TeamQuest { get; set; }
    }
}
