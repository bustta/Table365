using Table365.Core.Models.POCO;
using Table365.Core.Repository.Interface;

namespace Table365.Core.Repository
{
    public class UserRepository : GenericRepository<User>, IUser
    {
        public User GetUserByAccount(string id)
        {
            return Get(x => x.Account == id);
        }

        public User GetUserByEmail(string email)
        {
            return Get(x => x.Email == email);
        }
    }
}