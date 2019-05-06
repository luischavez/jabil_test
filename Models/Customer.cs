using System;
using System.Collections.Generic;

namespace jabil_test.Models
{
    public partial class Customer
    {
        public Customer()
        {
            PartNumbers = new HashSet<PartNumber>();
        }

        public int Pkcustomer { get; set; }
        public string Name { get; set; }
        public string Prefix { get; set; }
        public int Fkbuilding { get; set; }
        public bool Available { get; set; }

        public virtual Building Building { get; set; }
        public virtual ICollection<PartNumber> PartNumbers { get; set; }
    }
}
