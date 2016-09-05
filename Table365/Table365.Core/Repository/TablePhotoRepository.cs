using System;
using Table365.Core.Models.POCO;
using Table365.Core.Repository.Interface;

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