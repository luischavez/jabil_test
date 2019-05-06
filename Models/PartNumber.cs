using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace jabil_test.Models
{
    public partial class PartNumber
    {
        public int PkpartNumber { get; set; }

        [Required, MaxLength(100), MinLength(1)]
        public string Name { get; set; }

        [Required]
        public int Fkcustomer { get; set; }

        [Required]
        public bool Available { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
