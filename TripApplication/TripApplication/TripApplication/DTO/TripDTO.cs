using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripApplication.DTO
{
    public class TripDTO
    {
        public int TripId { get; set; }
        public string? TripName { get; set; }
        public string TripFrom {  get; set; }
        public string TripTo { get; set; }
        public DateTime? Date { get; set; }
        public int? Slot { get; set; }
        public decimal? Price { get; set; }
        public string? LimousinePlate { get; set; }
        public string? LimousineType { get; set; }  
        public int? Status {  get; set; }
    }
}
