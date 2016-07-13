using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hotel_0_One.Startup))]
namespace Hotel_0_One
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
