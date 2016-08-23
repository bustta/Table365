namespace Table365.Core.Repository.Interface
{
    public interface ITablePhotoRepository
    {
        void Insert(byte[] photo);
        int GetTablePhotoCount();
    }
}