using Table365.Core.Models.POCO;

namespace Table365.Core.Repository.Interface
{
    public interface IUser : IRepository<User>
    {
        User GetUserByAccount(string id);
        User GetUserByEmail(string email);
    }
}