using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventPlusLTD.Models
{
    public class EquipmentType
    {
        [Key] //Indicates this variable is a primary key 
        public int EquipmentTypeID { get; set; } //Creates a public variable with the datatype integer called ID 

        [Required] //Is Required
        [StringLength(50)] //Can only have 50 characters in the string
        [Display(Name = "Type Of Equipment")] //Changes variable name to Type Of Equipment
        public string Type { get; set; } //Creates a public variable with the datatype string called Type

        //RELATIONSHIPS
        public ICollection<Equipment> Equipment { get; set; } //Creates a relationship as the primary key of Equipment
    }
}