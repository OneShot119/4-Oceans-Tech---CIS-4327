using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HopeTherapy.Startup))]
namespace HopeTherapy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
