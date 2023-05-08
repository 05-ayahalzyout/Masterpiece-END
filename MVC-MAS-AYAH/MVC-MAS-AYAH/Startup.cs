using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_MAS_AYAH.Startup))]
namespace MVC_MAS_AYAH
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
