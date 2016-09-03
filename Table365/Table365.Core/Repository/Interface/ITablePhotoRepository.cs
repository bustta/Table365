using Table365.Models.POCO;

namespace Table365.Core.Repository.Interface
{
    public interface ITablePhotoRepository : IRepository<TablePhoto>
    {
        int GetTablePhotoCount();
    }
}