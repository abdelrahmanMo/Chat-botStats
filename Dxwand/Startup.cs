using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dxwand.Startup))]
namespace Dxwand
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
