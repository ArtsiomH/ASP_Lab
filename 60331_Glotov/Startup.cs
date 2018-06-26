using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_60331_Glotov.Startup))]
namespace _60331_Glotov
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
