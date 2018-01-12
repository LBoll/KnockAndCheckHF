using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KnockAndCheckHF.Startup))]
namespace KnockAndCheckHF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
