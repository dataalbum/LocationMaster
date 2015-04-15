using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LocationMaster.Models
{
    public class LocationsContext : DbContext
    {
        public LocationsContext()
            : base("name=LocationsContext")
        {
        }
        public DbSet<Location> Locations { get; set; }
    }
}