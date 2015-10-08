using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BoostrapHelpers.Startup))]
namespace BoostrapHelpers
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
