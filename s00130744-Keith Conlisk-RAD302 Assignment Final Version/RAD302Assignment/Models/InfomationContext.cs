using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RAD302Assignment.Models
{
    public class InfomationContext : DbContext
    {
        public DbSet<PersonInfo> PersonInfo { get; set; }
        public DbSet<PeopleIndex> People { get; set; }

        public InfomationContext()
          : base("InfomationConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    }
}