using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required, MaxLength(100), MinLength(1)]
        public string Name { get; set; }

        [Required]
        public bool Available { get; set; }

        [JsonIgnore]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
