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

        public int Number { get; set; }

        public string Tag { get; set; }

        public virtual ICollection<RiddleModel> Riddles { get; set; }
    }
}