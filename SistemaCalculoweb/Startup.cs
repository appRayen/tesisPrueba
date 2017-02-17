using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SistemaCalculoweb.Startup))]
namespace SistemaCalculoweb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
