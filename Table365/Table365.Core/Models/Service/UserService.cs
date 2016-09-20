using System;
using Table365.Core.Models.POCO;
using Table365.Core.Models.Repository;
using Table365.Core.Models.Util.Encrypt;

namespace Table365.Core.Models.Service
{
    public class UserService
    {
        private readonly IEncrypt _encryptMethod;

        public UserService()
        {
            _encryptMethod = new Pbkdf2();
        }

        public string GetEncrytPassword(string pw)
        {
            return _encryptMethod.GetEncryptPassword(pw);
        }

        public User VerifyUser(string email, string plainPw)
        {
            var user = new UserRepository().Get(x => x.Email == email);
            if (user == null)
            {
                throw new Exception("user not exist");
            }
            var encryptPw = user.Password;
            var isCorrected =  _encryptMethod.IsCorrectedPassword(plainPw, encryptPw);
            if (!isCorrected)
            {
                throw new Exception("Pw incorrected.");
            }
            return user;
        }
    }
}