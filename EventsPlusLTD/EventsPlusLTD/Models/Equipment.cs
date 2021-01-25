using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlusLTD.Models
{
    public class Equipment
    {
        public int ID { get; set; }
        [Required]
        [StringLength(80)]
        [Display(Name = "Equipment Name")]
        public string Equipment_Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Availability { get; set; }
    }
}
