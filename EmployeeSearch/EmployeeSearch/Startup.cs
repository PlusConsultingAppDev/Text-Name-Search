using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmployeeSearch.Startup))]
namespace EmployeeSearch
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
