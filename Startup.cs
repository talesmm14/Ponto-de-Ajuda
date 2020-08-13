using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PontoDeAjuda.Startup))]
namespace PontoDeAjuda
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
