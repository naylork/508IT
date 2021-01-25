using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlusLTD.Models
{
    public class Participants
    {
        public int ID { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh-mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Time")]
        public DateTime Start_Time { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh-mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Time")]
        public DateTime End_Time { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "Money")]
        [Display(Name = "Estimated Costs")]
        public decimal Estimated_Costs { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "Money")]
        [Display(Name = "Actual Costs")]
        public decimal? Actual_Costs { get; set; }

    }
}
