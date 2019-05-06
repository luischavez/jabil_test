using System;

namespace jabil_test.Models
{
    public class PartReportSearch
    {
        public int? PKPartNumber { get; set; }
        public string PartNumber { get; set; }
        public int? PKCustomer { get; set; }
        public string Customer { get; set; }
        public string Available { get; set; }
    }
}
