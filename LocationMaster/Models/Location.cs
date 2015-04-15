using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocationMaster.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
    }
}