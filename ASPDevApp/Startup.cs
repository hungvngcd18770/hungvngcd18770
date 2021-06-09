using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPDevApp.Startup))]
namespace ASPDevApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
