using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlusLTD.Models
{
    public class OrganizerRole
    {
        public int ID { get; set; }

        [Required]
        [StringLength(80)]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }
}
