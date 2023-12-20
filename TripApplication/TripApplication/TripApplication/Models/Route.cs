using System;
using System.Collections.Generic;

namespace TripApplication.Models
{
    public partial class Route
    {
        public Route()
        {
            Trips = new HashSet<Trip>();
        }

        public int RouteId { get; set; }
        public string? RouteName { get; set; }
        public string? RouteFrom { get; set; }
        public string? RouteTo { get; set; }
        public double? Distance { get; set; }

        public virtual Location? RouteFromNavigation { get; set; }
        public virtual Location? RouteToNavigation { get; set; }
        public virtual ICollection<Trip> Trips { get; set; }
    }
}
