using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DiemCong_PhamBachMinhTri.Startup))]
namespace DiemCong_PhamBachMinhTri
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
