using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Content_Management_System.Startup))]
namespace Content_Management_System
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
