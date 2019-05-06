using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace jabil_test.Models
{
    public partial class Building
    {
        public Building()
        {
            Customers = new HashSet<Customer>();
        }

        public int Pkbuilding { get; set; }
        public string Name { get; set; }
        public bool Available { get; set; }

        [JsonIgnore]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
