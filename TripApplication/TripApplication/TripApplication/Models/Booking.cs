using System;
using System.Collections.Generic;

namespace TripApplication.Models
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public int? TripId { get; set; }
        public string? Customer { get; set; }
        public string? Phone { get; set; }
        public string? SeatsStatus { get; set; }
        public decimal? Amount { get; set; }
        public string? CreatedBy { get; set; }

        public virtual Account? CreatedByNavigation { get; set; }
        public virtual Trip? Trip { get; set; }
    }
}
