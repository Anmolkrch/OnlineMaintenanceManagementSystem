using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ServiceMaintananceApplicationMVC5.Startup))]
namespace ServiceMaintananceApplicationMVC5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
