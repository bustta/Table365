using Microsoft.Owin;
using Owin;
using Table365;

[assembly: OwinStartup(typeof(Startup))]

namespace Table365
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}