using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuestEngine.Startup))]
namespace QuestEngine
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
