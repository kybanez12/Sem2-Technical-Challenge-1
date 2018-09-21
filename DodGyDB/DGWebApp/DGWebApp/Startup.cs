using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DGWebApp.Startup))]
namespace DGWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
