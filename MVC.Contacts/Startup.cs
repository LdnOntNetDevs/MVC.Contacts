using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC.Contacts.Startup))]
namespace MVC.Contacts
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
