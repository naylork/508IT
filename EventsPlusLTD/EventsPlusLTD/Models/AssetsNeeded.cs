using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlusLTD.Models
{
    public class AssetsNeeded
    {
        public int ID { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "Money")]
        [Display(Name = "Estimated Costs")]
        public decimal Estimated_Costs { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "Money")]
        [Display(Name = "Actual Costs")]
        public decimal? Actual_Costs { get; set; }

        [Required]
        [Display(Name = "Amount Needed")]
        public int Amount_Needed { get; set; }
    }
}
