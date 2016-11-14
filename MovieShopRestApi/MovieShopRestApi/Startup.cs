using Microsoft.Owin;
using MovieShopRestApi;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace MovieShopRestApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}