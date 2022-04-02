using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Capstone.Bookstore.Startup))]
namespace Capstone.Bookstore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
