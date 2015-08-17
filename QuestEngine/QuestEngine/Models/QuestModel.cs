using System.Collections.Generic;

namespace QuestEngine.Models
{
    public class QuestModel
    {
        public QuestModel()
        {
            Riddles = new List<RiddleModel>();
        }

        public int Id { get; set; }

        public string Tag { get; set; }

        public virtual List<RiddleModel> Riddles { get; set; }
    }
}