using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieShopUser.Startup))]
namespace MovieShopUser
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
