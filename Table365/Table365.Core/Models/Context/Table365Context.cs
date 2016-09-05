using System.Data.Entity;
using Table365.Core.Models.POCO;

namespace Table365.Core.Models.Context
{
    public class Table365Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TablePhoto> TablePhotos { get; set; }

        public Table365Context()
            :base("name=Table365Db")
        {
            
        }

    }
}