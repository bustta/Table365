﻿using Table365.Core.Repository;

namespace Table365.Tests.Core.Repository
{
    class StubTablePhotoRepository : ITablePhotoRepository
    {
        public void Insert(byte[] photo)
        {
            throw new System.NotImplementedException();
        }

        public int GetTablePhotoCount()
        {
            throw new System.NotImplementedException();
        }
    }
}