using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlusLTD.Models
{
    public class Event
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name= "Event Name")]
        public string Event_Name { get; set; }
        [Required]
        [StringLength(80, ErrorMessage = "Event Location cannot be longer than 80 characters.")]
        [Display(Name = "Event Location")]
        public string Event_Location { get; set; }
        public string Event_Description { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh-mm}",ApplyFormatInEditMode = true)]
        [Display(Name = "Start Time")]
        public DateTime Start_Time { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh-mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Time")]
        public DateTime? End_Time { get; set; }
    }
}
