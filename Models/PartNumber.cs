using System;
using System.Collections.Generic;

namespace jabil_test.Models
{
    public partial class PartNumber
    {
        public int PkpartNumber { get; set; }
        public string Name { get; set; }
        public int Fkcustomer { get; set; }
        public bool Available { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
