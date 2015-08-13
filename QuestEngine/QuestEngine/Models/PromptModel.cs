namespace QuestEngine.Models
{
    public class PromptModel
    {
        public int Id { get; set; }

        public string Caption { get; set; }

        public string Text { get; set; }

        public int Number { get; set; }

        public int RiddleId { get; set; }

        public virtual RiddleModel Riddle { get; set; }

        /// <summary>
        /// Time to prompt in min
        /// </summary>
        public int Time { get; set; }
    }
}