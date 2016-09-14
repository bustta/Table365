using System;
using AutoMapper;
using Table365.Core.Models.POCO;
using Table365.Core.Models.Repository.Interface;
using Table365.Core.Models.ViewModel;

namespace Table365.Core.Models.Repository
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

        public void Create(UserViewModels userViewMdodel)
        {
            if (userViewMdodel == null)
            {
                throw new ArgumentNullException("userViewMdodel");
            }
            var user = Mapper.Map<User>(userViewMdodel);

            if (userViewMdodel.ImageFile != null)
            {
                var imgBytes = new byte[userViewMdodel.ImageFile.ContentLength];
                userViewMdodel.ImageFile.InputStream.Read(imgBytes, 0, userViewMdodel.ImageFile.ContentLength);
                user.ProfilePhoto = imgBytes;
            }

            Create(user);
        }
    }
}