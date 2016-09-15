namespace Table365.Core.Models.Util.Encrypt
{
    public interface IEncrypt
    {
        string GetEncryptPassword(string pw);
        bool IsCorrectedPassword(string plainPw, string encryptPw);
    }
}