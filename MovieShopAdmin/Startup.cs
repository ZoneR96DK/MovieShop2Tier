using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieShopAdmin.Startup))]
namespace MovieShopAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
