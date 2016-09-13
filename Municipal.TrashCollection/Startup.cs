using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Municipal.TrashCollection.Startup))]
namespace Municipal.TrashCollection
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
