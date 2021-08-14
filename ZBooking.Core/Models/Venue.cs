using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBooking.Core.Models
{
    public class Venue
    {
        public string Id { get; set; }
        [StringLength(20)]
        [DisplayName("Venue Name")]
        public string Name { get; set; }
        [DisplayName("Venue SubName")]
        public string SubName { get; set; }
        public string Description { get; set; }
        public string Activity { get; set; }
        public string image { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        [Range(0, 10000)]
        public decimal DayPrice { get; set; }
        public decimal HourPrice { get; set; }

        public Venue(){
            this.Id = Guid.NewGuid().ToString();
        }

    }
}
