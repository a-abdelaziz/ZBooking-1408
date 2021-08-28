using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZBooking.Core.Models;

namespace ZBooking.DataAccess.SQL
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("DeafaultConnection")
        {

        }

        public DbSet<Venue> Venue { get; set; }
        public DbSet<VenueActivity> VenueActivities { get; set; }
    }
}
