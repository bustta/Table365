using System;
using Table365.Core.Repository.Interface;
using Table365.Models.POCO;

namespace Table365.Core.Repository
{
    public class TablePhotoRepository : GenericRepository<TablePhoto>, ITablePhotoRepository
    {
        public int GetTablePhotoCount()
        {
            throw new NotImplementedException();
        }
    }
}