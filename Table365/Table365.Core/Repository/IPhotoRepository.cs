namespace Table365.Core.Repository
{
    public interface IPhotoRepository
    {
        void Insert(byte[] photo);
        int GetUserPhotoCount();
    }
}