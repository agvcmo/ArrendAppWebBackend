using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppArrend.Startup))]
namespace AppArrend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
