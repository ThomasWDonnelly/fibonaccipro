using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Fibonacci.Web.Startup))]
namespace Fibonacci.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
