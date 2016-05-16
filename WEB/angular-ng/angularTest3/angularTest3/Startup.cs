using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(angularTest3.Startup))]
namespace angularTest3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
