using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class Equipment
    {
        [Key] //Indicates this variable is a primary key 
        public int EquipmentID { get; set; } //Creates a public variable with the datatype integer called ID 

        [Required] //Is Required
        [StringLength(80)] //Can only contain 80 characters in the string 
        [Display(Name = "Equipment Name")] //Changes variable name to display as Equipment Name
        public string Equipment_Name { get; set; } //Creates a public variable with the datatype string called Equipment_Name

        [Required] //Is Required
        [Range(0, 1000)] //Can only contain numbers from 0-1000
        public int Availability { get; set; } //Creates a public variable with the datatype integer called Availability

        public int EquipmentTypeID { get; set; }

        //RELATIONSHIPS

        public ICollection<AssetsNeeded> AssetsNeeded { get; set; }
        public EquipmentType EquipmentType { get; set; }

    }
}
