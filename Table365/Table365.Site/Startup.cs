
using Microsoft.Owin;
using Owin;
using Table365.Core.Models.POCO;


[assembly: OwinStartupAttribute(typeof(Table365.Site.Startup))]
namespace Table365.Site
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            //Mapper.Initialize(cfg => cfg.CreateMap<UserViewModels, User>());
            //Mapper.Initialize(cfg => cfg.CreateMap<User, UserViewModels>());
        }
    }
}
