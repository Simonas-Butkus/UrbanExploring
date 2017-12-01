using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UrbanExplorer.Startup))]
namespace UrbanExplorer
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
