using System.Data.Entity;

namespace QuestEngine.Models
{
    public class QuestEngineContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public QuestEngineContext() : base("name=QuestEngineContext")
        {
        }

        public DbSet<QuestModel> Quests { get; set; }

        public DbSet<PromptModel> Prompts { get; set; }

        public DbSet<RiddleModel> Riddles { get; set; }

        public DbSet<TeamModel> Teams { get; set; }

        public DbSet<TeamQuestModel> TeamQuests { get; set; }
    }
}
