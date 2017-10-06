using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TPRM.Startup))]
namespace TPRM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
