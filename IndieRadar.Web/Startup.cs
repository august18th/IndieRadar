using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(IndieRadar.Web.Startup))]
namespace IndieRadar.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}