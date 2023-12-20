using System;
using System.Collections.Generic;

namespace TripApplication.Models
{
    public partial class Location
    {
        public Location()
        {
            RouteRouteFromNavigations = new HashSet<Route>();
            RouteRouteToNavigations = new HashSet<Route>();
        }

        public string LocationCode { get; set; } = null!;
        public string? LocationName { get; set; }

        public virtual ICollection<Route> RouteRouteFromNavigations { get; set; }
        public virtual ICollection<Route> RouteRouteToNavigations { get; set; }
    }
}
