using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(azure.owasp.modsecurity.Startup))]
namespace azure.owasp.modsecurity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
