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

        public bool IsCorrectedPassword(string plainPw, string encryptPw)
        {
            return _encryptMethod.IsCorrectedPassword(plainPw, encryptPw);
        }
    }
}