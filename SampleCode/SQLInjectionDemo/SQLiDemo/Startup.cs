using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SQLiDemo.Startup))]
namespace SQLiDemo
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
