namespace Table365.Core.Repository
{
    public interface ITablePhotoRepository
    {
        void Insert(byte[] photo);
        int GetTablePhotoCount();
    }
}