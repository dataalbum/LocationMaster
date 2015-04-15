using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.OData;
using LocationMaster.Models;
using System.Web.Http;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Net;

namespace LocationMaster.Controllers
{
    public class LocationsController : ODataController
    {
        LocationsContext db = new LocationsContext();
        private bool ProductExists(int key)
        {
            return db.Locations.Any(p => p.LocationId == key);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        
        //Get all
        [EnableQuery]
        public IQueryable<Location> Get()
        {
            return db.Locations;
        }
        
        //Get single
        [EnableQuery]
        public SingleResult<Location> Get([FromODataUri] int key)
        {
            IQueryable<Location> result = db.Locations.Where(p => p.LocationId == key);
            return SingleResult.Create(result);
        }

        //Post
        public async Task<IHttpActionResult> Post(Location location)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Locations.Add(location);
            await db.SaveChangesAsync();
            return Created(location);
        }

        //Update
        /*
        OData supports two different semantics for updating an entity, PATCH and PUT.
        PATCH performs a partial update. The client specifies just the properties to update.
        PUT replaces the entire entity.
        The disadvantage of PUT is that the client must send values for all of the properties in the entity, including values that are not changing. The OData spec states that PATCH is preferred. 
         */
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Location> product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await db.Locations.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            product.Patch(entity);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(entity);
        }
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Location update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != update.LocationId)
            {
                return BadRequest();
            }
            db.Entry(update).State = EntityState.Modified;
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(update);
        }

        //Delete
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            var location = await db.Locations.FindAsync(key);
            if (location == null)
            {
                return NotFound();
            }
            db.Locations.Remove(location);
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}