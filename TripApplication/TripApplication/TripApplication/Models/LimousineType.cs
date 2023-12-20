using System;
using System.Collections.Generic;

namespace TripApplication.Models
{
    public partial class LimousineType
    {
        public LimousineType()
        {
            Limousines = new HashSet<Limousine>();
        }

        public int Id { get; set; }
        public string? Type { get; set; }
        public decimal? UnitPrice { get; set; }

        public virtual ICollection<Limousine> Limousines { get; set; }
    }
}
