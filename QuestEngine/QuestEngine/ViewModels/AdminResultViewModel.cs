namespace QuestEngine.ViewModels
{
    public class AdminResultViewModel
    {
        public int Id { get; set; }

        public int StatisticsCount { get; set; }

        public bool IsOk { get; set; }
        public string Error { get; set; }
        public int ProgressCount { get; set; }
    }
}