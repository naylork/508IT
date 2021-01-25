using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlusLTD.Models
{
    public class Performance
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Performance Name")]
        public string Performance_Name { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Performance Location")]
        public string Performance_Location { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh-mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Time")]
        public DateTime Start_Time { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh-mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Time")]
        public DateTime? End_Time { get; set; }

    }
}
