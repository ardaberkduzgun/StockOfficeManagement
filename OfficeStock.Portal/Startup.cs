using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OfficeStock.Portal.Startup))]
namespace OfficeStock.Portal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
