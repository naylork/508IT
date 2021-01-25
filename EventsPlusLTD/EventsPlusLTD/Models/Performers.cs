using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlusLTD.Models
{
    public class Performers
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [StringLength(11)]
        [Display(Name = "Contact Number")]
        public int? ContactNumber { get; set; }

        [StringLength(255)]
        [Display(Name = "Contact Email")]
        public string? ContactEmail { get; set; }
    }
}
