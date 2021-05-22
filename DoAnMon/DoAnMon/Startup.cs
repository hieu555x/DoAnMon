using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DoAnMon.Startup))]
namespace DoAnMon
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
