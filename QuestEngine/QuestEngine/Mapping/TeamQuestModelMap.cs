using System.Data.Entity.ModelConfiguration;
using QuestEngine.Models;

namespace QuestEngine.Mapping
{
    class TeamQuestModelMap : EntityTypeConfiguration<TeamQuestModel>
    {
        public TeamQuestModelMap()
        {
            this.HasKey(t => t.Id);
        }
    }

}
