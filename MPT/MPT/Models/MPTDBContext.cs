using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MPT.Models
{
    public class MPTDBContext : DbContext
    {
        public MPTDBContext() : base("name=MPTDBContext")
        {
        }

        public MPTDBContext(DbConnection connect) : base(connect, true)
        {
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}