using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DoctorApp.Startup))]
namespace DoctorApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
