using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using ZBooking.Core.Models;


namespace ZBooking.DataAccess.InMemory
{
    public class VenueActivityRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<VenueActivity> activities;

        public VenueActivityRepository()
        {
            activities = cache["activities"] as List<VenueActivity>;
            if (activities == null)
            {
                activities = new List<VenueActivity>();
            }
        }

        public void Commit()
        {
            cache["activities"] = activities;
        }

        public void Insert(VenueActivity a)
        {
            activities.Add(a);
        }

        public void Update(VenueActivity activity)
        {
            VenueActivity activityToUpdate = activities.Find(a => a.Id == activity.Id);
            if (activityToUpdate != null)
            {
                activityToUpdate = activity;
            }
            else
            {
                throw new Exception("Activity not found");
            }
        }

        public VenueActivity Find(string Id)
        {
            VenueActivity activity = activities.Find(a => a.Id == Id);
            if (activity != null)
            {
                return activity;
            }
            else
            {
                throw new Exception("Activity not found");
            }
        }

        public IQueryable<VenueActivity> Collection()
        {
            return activities.AsQueryable();
        }

        public void Delete(string Id)
        {
            VenueActivity activityToDelete = activities.Find(a => a.Id == Id);
            if (activityToDelete != null)
            {
                activities.Remove(activityToDelete);
            }
            else
            {
                throw new Exception("Activity not found");
            }
        }
    }
}
