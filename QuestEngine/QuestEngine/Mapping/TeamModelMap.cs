using System.Data.Entity.ModelConfiguration;
using QuestEngine.Models;

namespace QuestEngine.Mapping
{
    public class TeamModelMap: EntityTypeConfiguration<TeamModel>
    {
        public TeamModelMap()
        {
            this.HasKey(t => t.Id);
            this.HasRequired(t => t.TeamQuest)
                .WithRequiredDependent(t => t.Team)
                .WillCascadeOnDelete(true);
        }
    }
}
