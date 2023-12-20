using System;
using System.Collections.Generic;

namespace TripApplication.Models
{
    public partial class Limousine
    {
        public Limousine()
        {
            Trips = new HashSet<Trip>();
        }

        public int LimousineId { get; set; }
        public string? Name { get; set; }
        public string? Plate { get; set; }
        public int? NumberRows { get; set; }
        public int? NumberCols { get; set; }
        public int? Type { get; set; }

        public virtual LimousineType? TypeNavigation { get; set; }
        public virtual ICollection<Trip> Trips { get; set; }
    }
}
