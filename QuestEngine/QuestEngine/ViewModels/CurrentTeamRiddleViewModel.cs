using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestEngine.ViewModels
{
    public class CurrentTeamRiddleViewModel
    {
        public CurrentTeamRiddleViewModel()
        {
            Prompts = new List<string>();
        }

        public int Id { get; set; }

        [Display(Name = "Команда")]

        public string TeamName { get; set; }

        public string TeamEmail { get; set; }

        [Display(Name = "Загадка №")]
        public int RiddleNumber { get; set; }

        [Display(Name = "Загадка")]
        public string RiddleText { get; set; }

        public DateTime RiddleStartTime { get; set; }

        [Display(Name = "След. подсказка")]
        public string NextPrompTime { get; set; }

        [Display(Name = "Подсказки")]
        public List<string> Prompts { get; set; }

        [Display(Name = "Код")]
        public string Code { get; set; }

        
        public bool IsTheEnd { get; set; }
    }
}
