using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

namespace Identity.B2b.Presentation.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
