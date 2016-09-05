using Table365.Core.Models.POCO;

namespace Table365.Core.Repository.Interface
{
    public interface ITablePhotoRepository : IRepository<TablePhoto>
    {
        int GetTablePhotoCount();
    }
}