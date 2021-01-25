using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlusLTD.Models
{
    public class OrganizerInfo
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [StringLength(11)]
        [Display(Name = "Contact Number")]
        public int? ContactNumber { get; set; }

        [StringLength(255)]
        [Display(Name = "Contact Email")]
        public string? ContactEmail { get; set; }
    }
}
