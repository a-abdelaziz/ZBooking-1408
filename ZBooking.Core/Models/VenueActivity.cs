using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBooking.Core.Models
{
    public class VenueActivity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        public VenueActivity()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
