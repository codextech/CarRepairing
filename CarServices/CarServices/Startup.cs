using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarServices.Startup))]
namespace CarServices
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
