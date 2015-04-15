namespace LocationMaster.Migrations
{
    using LocationMaster.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LocationMaster.Models.LocationsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "LocationMaster.Models.LocationsContext";
        }

        protected override void Seed(LocationMaster.Models.LocationsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            
            //context.Locations.AddOrUpdate(new Location[] {
            context.Locations.AddOrUpdate(p => p.Name,
               new Location
               {
                   Name = "Debra Garcia",
                   Address = "1234 Main St",
                   City = "Redmond",
                   State = "WA",
                   Zip = "10999",
                   Country = "US",
                   Lat = "0",
                   Lon = "0"
               },
                new Location
                {
                    Name = "Thorsten Weinrich",
                    Address = "5678 1st Ave W",
                    City = "Redmond",
                    State = "WA",
                    Zip = "10999",
                    Country = "US",
                    Lat = "0",
                    Lon = "0"
                },
                new Location
                {
                    Name = "Yuhong Li",
                    Address = "9012 State st",
                    City = "Redmond",
                    State = "WA",
                    Zip = "10999",
                    Country = "US",
                    Lat = "0",
                    Lon = "0"
                },
                new Location
                {
                    Name = "Jon Orton",
                    Address = "3456 Maple St",
                    City = "Redmond",
                    State = "WA",
                    Zip = "10999",
                    Country = "US",
                    Lat = "0",
                    Lon = "0"
                },
                new Location
                {
                    Name = "Diliana Alexieva-Bosseva",
                    Address = "7890 2nd Ave E",
                    City = "Redmond",
                    State = "WA",
                    Zip = "10999",
                    Country = "US",
                    Lat = "0",
                    Lon = "0"
                }
                );
        }
    }
}
