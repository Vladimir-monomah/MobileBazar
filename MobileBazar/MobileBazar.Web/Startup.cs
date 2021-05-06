using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MobileBazar.Web.Startup))]
namespace MobileBazar.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
