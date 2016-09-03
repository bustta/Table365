using System;
using System.Linq;
using System.Linq.Expressions;
using Table365.Core.Repository.Interface;
using Table365.Models.POCO;

namespace Table365.Tests.Core.Repository
{
    internal class StubTablePhotoRepository : ITablePhotoRepository
    {
        public int GetTablePhotoCount()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Create(TablePhoto instance)
        {
            throw new NotImplementedException();
        }

        public void Update(TablePhoto instance)
        {
            throw new NotImplementedException();
        }

        public void Delete(TablePhoto instance)
        {
            throw new NotImplementedException();
        }

        public TablePhoto Get(Expression<Func<TablePhoto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TablePhoto> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}