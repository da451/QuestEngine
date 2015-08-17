using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestEngine.Models;
using WebGrease.Css.Extensions;

namespace QuestEngine
{
    public class QuestEngineInitializer : DropCreateDatabaseAlways<QuestEngineContext>
    {
        protected override void Seed(QuestEngineContext context)
        {

            var redTeam = new TeamModel()
            {
                Email = "RedTeam@quest.com",
                Name = "Red Team"
            };

            var greenTeam = new TeamModel()
            {
                Email = "GreenTeam@quest.com",
                Name = "Green Team"
            };

            var yellowTeam = new TeamModel()
            {
                Email = "YellowTeam@quest.com",
                Name = "Yellow Team"
            };


            var blueTeam = new TeamModel()
            {
                Email = "BlueTeam@quest.com",
                Name = "Blue Team"
            };

            var orangeTeam = new TeamModel()
            {
                Email = "OrangeTeam@quest.com",
                Name = "Orange Team"
            };

            List<TeamModel> teams = new List<TeamModel>()
            {
                redTeam,greenTeam,blueTeam,yellowTeam,orangeTeam
            };
            teams.ForEach(x=>context.Teams.AddOrUpdate(x));
            context.SaveChanges();
            var prompt_1_1 = new PromptModel()
            {
                Caption = "Prompt_1_1",
                Number = 1,
                Text = "RidlePropt_1_1",
                Time = 5
            };
            var prompt_1_2 = new PromptModel()
            {
                Caption = "Prompt_1_2",
                Number = 2,
                Text = "RidlePropt_1_2",
                Time = 10
            };
            var prompt_1_3 = new PromptModel()
            {
                Caption = "Prompt_1_3",
                Number = 3,
                Text = "RidlePropt_1_3",
                Time = 15
            };


            var prompt_2_1 = new PromptModel()
            {
                Caption = "Prompt_2_1",
                Number = 1,
                Text = "RidlePropt_2_1",
                Time = 5
            };
            var prompt_2_2 = new PromptModel()
            {
                Caption = "Prompt_2_2",
                Number = 2,
                Text = "RidlePropt_2_2",
                Time = 10
            };
            var prompt_2_3 = new PromptModel()
            {
                Caption = "Prompt_2_3",
                Number = 3,
                Text = "RidlePropt_2_3",
                Time = 15
            };

            var prompt_3_1 = new PromptModel()
            {
                Caption = "Prompt_3_1",
                Number = 1,
                Text = "RidlePropt_3_1",
                Time = 5
            };
            var prompt_3_2 = new PromptModel()
            {
                Caption = "Prompt_3_2",
                Number = 2,
                Text = "RidlePropt_3_2",
                Time = 10
            };
            var prompt_3_3 = new PromptModel()
            {
                Caption = "Prompt_3_3",
                Number = 3,
                Text = "RidlePropt_3_3",
                Time = 15
            };

            var prompt_4_1 = new PromptModel()
            {
                Caption = "Prompt_4_1",
                Number = 1,
                Text = "RidlePropt_4_1",
                Time = 5
            };
            var prompt_4_2 = new PromptModel()
            {
                Caption = "Prompt_4_2",
                Number = 2,
                Text = "RidlePropt_4_2",
                Time = 10
            };
            var prompt_4_3 = new PromptModel()
            {
                Caption = "Prompt_4_3",
                Number = 3,
                Text = "RidlePropt_4_3",
                Time = 15
            };


            var prompts = new List<PromptModel>()
            {
                prompt_1_1,prompt_1_2,prompt_1_3,
                prompt_2_1,prompt_2_2,prompt_2_3,
                prompt_3_1,prompt_3_2,prompt_3_3,
                prompt_4_1,prompt_4_2,prompt_4_3,
            };

            prompts.ForEach(x => context.Prompts.AddOrUpdate(x));
            context.SaveChanges();
            var riddle1 = new RiddleModel()
            {
                Caption ="Riddle 1",
                Code="q1",
                Text = "Text 1",
                Prompts = new List<PromptModel>() { prompt_1_1, prompt_1_2, prompt_1_3}
            };
            var riddle2 = new RiddleModel()
            {
                Caption = "Riddle 2",
                Code = "q2",
                Text = "Text 2",
                Prompts = new List<PromptModel>() { prompt_2_1, prompt_2_2, prompt_2_3 }
            };
            var riddle3 = new RiddleModel()
            {
                Caption = "Riddle 3",
                Code = "q3",
                Text = "Text 3",
                Prompts = new List<PromptModel>() { prompt_3_1, prompt_3_2, prompt_3_3 }
            };
            var riddle4 = new RiddleModel()
            {
                Caption = "Riddle 4",
                Code = "q4",
                Text = "Text 4",
                Prompts = new List<PromptModel>() { prompt_4_1, prompt_4_2, prompt_4_3 }
            };

            var riddles = new List<RiddleModel>()
            {
                riddle1, riddle2, riddle3, riddle4
            };

            riddles.ForEach(x=> context.Riddles.AddOrUpdate(x));
            context.SaveChanges();

            var redQuest= new QuestModel()
            {
                Riddles = new List<RiddleModel>()
                {
                     riddle1, riddle3, riddle4
                }
            };

            var greenQuest = new QuestModel()
            {
                Riddles = new List<RiddleModel>()
                {
                     riddle2, riddle3, riddle4
                }
            };

            var quests = new List<QuestModel>() { redQuest, greenQuest};

            quests.ForEach(x=> context.Quests.AddOrUpdate(x));
            context.SaveChanges();


            var redTeamQuest = new TeamQuestModel()
            {
                Team = redTeam,
                TeamId = redTeam.Id,
                QuestId = redQuest.Id,
                Quest = redQuest
            };

            var greenTeamQuest = new TeamQuestModel()
            {
                Team = greenTeam,
                TeamId = greenTeam.Id,
                QuestId = greenQuest.Id,
                Quest = greenQuest
            };

            var teamQuests = new  List<TeamQuestModel>()
            {
                redTeamQuest,greenTeamQuest
            };

            teamQuests.ForEach(x=> context.TeamQuests.AddOrUpdate(x));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
