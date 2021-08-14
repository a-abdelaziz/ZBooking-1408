using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZBooking.WebUI.Startup))]
namespace ZBooking.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
