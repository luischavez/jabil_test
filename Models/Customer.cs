using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace jabil_test.Models
{
    public partial class Customer
    {
        public Customer()
        {
            PartNumbers = new HashSet<PartNumber>();
        }

        public int PKCustomer { get; set; }

        [Required, MaxLength(100), MinLength(1)]
        public string Name { get; set; }

        [Required, MaxLength(5), MinLength(1)]
        public string Prefix { get; set; }

        [Required]
        public int FKBuilding { get; set; }

        [Required]
        public bool Available { get; set; }

        public virtual Building Building { get; set; }

        [JsonIgnore]
        public virtual ICollection<PartNumber> PartNumbers { get; set; }
    }
}
