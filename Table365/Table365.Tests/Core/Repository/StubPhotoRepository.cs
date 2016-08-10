using Table365.Core.Repository;

namespace Table365.Tests.Core.Repository
{
    class StubPhotoRepository : IPhotoRepository
    {
        public void Insert(byte[] photo)
        {
            throw new System.NotImplementedException();
        }

        public int GetUserPhotoCount()
        {
            throw new System.NotImplementedException();
        }
    }
}