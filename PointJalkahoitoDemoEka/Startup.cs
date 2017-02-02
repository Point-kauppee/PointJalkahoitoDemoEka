using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PointJalkahoitoDemoEka.Startup))]
namespace PointJalkahoitoDemoEka
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
