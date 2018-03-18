using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Carrenta.Startup))]
namespace Carrenta
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
