using System;
using System.Collections.Generic;

namespace TripApplication.Models
{
    public partial class Account
    {
        public Account()
        {
            Bookings = new HashSet<Booking>();
            Trips = new HashSet<Trip>();
        }

        public string Username { get; set; } = null!;
        public string? Password { get; set; }
        public string? Role { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Trip> Trips { get; set; }
    }
}
