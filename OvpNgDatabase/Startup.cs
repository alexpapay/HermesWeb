using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OvpNgDatabase.Startup))]
namespace OvpNgDatabase
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
