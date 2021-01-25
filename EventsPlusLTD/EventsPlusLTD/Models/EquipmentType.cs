using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlusLTD.Models
{
    public class EquipmentType
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Type")]
        public string Type { get; set; }
    }
}
