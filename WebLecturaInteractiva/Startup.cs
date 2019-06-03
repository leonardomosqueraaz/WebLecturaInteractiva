using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebLecturaInteractiva.Startup))]
namespace WebLecturaInteractiva
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
