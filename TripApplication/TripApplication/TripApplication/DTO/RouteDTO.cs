using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripApplication.DTO
{
    public class RouteDTO
    {
        public int RouteId { get; set; }
        public string? RouteName { get; set; }
        public string? RouteFrom { get; set; }
        public string? RouteTo { get; set; }
        public double? Distance { get; set; }
    }
}
