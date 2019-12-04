using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MediCsharpASPNET.Startup))]
namespace MediCsharpASPNET
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
