using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripApplication.DTO
{
    public class LimousineDTO
    {
        public int LimousineId { get; set; }
        public string? Name { get; set; }
        public string? Plate { get; set; }
        public int? NumberRows { get; set; }
        public int? NumberCols { get; set; }
        public string? Type { get; set; }
    }
}
