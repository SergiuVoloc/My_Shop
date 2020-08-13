using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(My_Shop.Web_UI.Startup))]
namespace My_Shop.Web_UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
