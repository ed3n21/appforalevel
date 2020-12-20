using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Level.Startup))]
namespace Level
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
