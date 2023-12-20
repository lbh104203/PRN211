using System;
using System.Collections.Generic;

namespace TripApplication.Models
{
    public partial class Trip
    {
        public Trip()
        {
            Bookings = new HashSet<Booking>();
        }

        public int TripId { get; set; }
        public int? RouteId { get; set; }
        public DateTime? Date { get; set; }
        public int? Slot { get; set; }
        public decimal? Price { get; set; }
        public int? LimousineId { get; set; }
        public int? Status { get; set; }
        public string? CreateBy { get; set; }

        public virtual Account? CreateByNavigation { get; set; }
        public virtual Limousine? Limousine { get; set; }
        public virtual Route? Route { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
