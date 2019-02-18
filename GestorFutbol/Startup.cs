using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GestorFutbol.Startup))]
namespace GestorFutbol
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
