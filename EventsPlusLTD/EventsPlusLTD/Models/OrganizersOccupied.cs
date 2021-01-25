using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlusLTD.Models
{
    public class OrganizersOccupied
    {
        public int ID { get; set; }
        
        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh-mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh-mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Time")]
        public DateTime? EndTime { get; set; }

    }
}
