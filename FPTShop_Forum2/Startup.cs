using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FPTShop_Forum2.Startup))]
namespace FPTShop_Forum2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
