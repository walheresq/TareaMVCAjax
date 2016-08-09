using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TareaMVCAjax.Startup))]
namespace TareaMVCAjax
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
