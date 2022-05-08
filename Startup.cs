using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudyLJ.Startup))]
namespace StudyLJ
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
