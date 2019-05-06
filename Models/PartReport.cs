using System;

namespace jabil_test.Models
{
    /*
     * Map FindParts procedure results.
     */
    public class PartReport
    {
        public int Id { get; set; }
        public int PKPartNumber { get; set; }
        public string PartNumber { get; set; }
        public bool Available { get; set; }
        public int PKCustomer { get; set; }
        public string Customer { get; set; }
        public int PKBuilding { get; set; }
        public string Building { get; set; }
    }
}
