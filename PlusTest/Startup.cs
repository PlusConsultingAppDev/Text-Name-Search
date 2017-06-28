using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PlusTest.Startup))]
namespace PlusTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
