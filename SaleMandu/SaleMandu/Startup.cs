using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SaleMandu.Startup))]
namespace SaleMandu
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
