using System.Web;
using System.Web.Security;
using Table365.Core.Models.Repository;

namespace Table365.Site.Helper
{
    public class WebSiteHelper
    {
        public static string CurrentUserName
        {
            get
            {
                var httpContext = HttpContext.Current;
                var identity = httpContext.User.Identity as FormsIdentity;

                if (identity == null)
                {
                    return string.Empty;
                }
                var userEmail = identity.Name;
                var userRepo = new UserRepository();
                var user = userRepo.Get(x => x.Email == userEmail);
                return user.Name;
            }
        }
    }
}