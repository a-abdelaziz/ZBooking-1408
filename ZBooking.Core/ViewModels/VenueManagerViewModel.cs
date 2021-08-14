using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZBooking.Core.Models;

namespace ZBooking.Core.ViewModels
{
    public class VenueManagerViewModel
    {
        public Venue Venue { get; set; }
        public IEnumerable<VenueActivity> VenueActivities { get; set; }


    }
}
