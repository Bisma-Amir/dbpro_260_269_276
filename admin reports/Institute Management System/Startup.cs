using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Institute_Management_System.Startup))]
namespace Institute_Management_System
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
