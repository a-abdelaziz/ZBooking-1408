using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using ZBooking.Core.Models;

namespace ZBooking.DataAccess.InMemory
{
    public class VenueRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Venue> venues;

        public VenueRepository() {
            venues = cache["venues"] as List<Venue>;
            if(venues == null){
                venues = new List<Venue>();
            }
        }

        public void Commit(){
            cache["venues"] = venues;
        }

        public void Insert(Venue v){
            venues.Add(v);
        }

        public void Update(Venue venue)
        {
            Venue venueToUpdate = venues.Find(v => v.Id == venue.Id);
            if(venueToUpdate != null)
            {
                venueToUpdate = venue;
            }
            else
            {
                throw new Exception("Venue not found");
            }
        }

        public Venue Find(string Id)
        {
            Venue venue = venues.Find(v => v.Id == Id);
            if (venue != null)
            {
                return venue;
            }
            else
            {
                throw new Exception("Venue not found");
            }
        }

        public IQueryable<Venue> Collection()
        {
            return venues.AsQueryable();
        }

        public void Delete(string Id)
        {
            Venue venueToDelete = venues.Find(v => v.Id == Id);
            if (venueToDelete != null)
            {
                venues.Remove(venueToDelete);
            }
            else
            {
                throw new Exception("Venue not found");
            }
        }
    }
}
