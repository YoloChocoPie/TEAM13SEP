using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TEAM13SEP.Startup))]
namespace TEAM13SEP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
