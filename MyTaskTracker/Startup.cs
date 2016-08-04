using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyTaskTracker.Startup))]
namespace MyTaskTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
