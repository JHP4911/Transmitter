using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TransmitterWEB.Startup))]

namespace TransmitterWEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
