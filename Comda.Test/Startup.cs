using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Comda.Test.Startup))]
namespace Comda.Test
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
