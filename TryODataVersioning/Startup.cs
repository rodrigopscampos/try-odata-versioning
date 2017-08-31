using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(TryODataVersioning.Startup))]

namespace TryODataVersioning
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
