using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Table365.Models.POCO;

namespace Table365.Models.Context
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