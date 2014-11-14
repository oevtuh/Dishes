using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dishes.Startup))]
namespace Dishes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
