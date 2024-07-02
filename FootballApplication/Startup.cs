using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FootballApplication.Startup))]
namespace FootballApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
