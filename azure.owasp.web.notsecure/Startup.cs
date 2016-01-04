using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(azure.owasp.web.notsecure.Startup))]
namespace azure.owasp.web.notsecure
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
