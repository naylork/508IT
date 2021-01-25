using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlusLTD.Models
{
    public class TypeOfEvent
    {
        public int ID { get; set; }
        [Required]
        [StringLength(150)]
        [Display(Name = "Event Type")]
        public string Event_Type { get; set; }
    }
}
