using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EPLTD.Models
{
    public class Equipment
    {
        [Key] //Indicates this variable is a primary key 
        public int EquipmentID { get; set; } //Creates a public variable with the datatype integer called EquipmentID 
        public int EquipmentTypeID { get; set; } //Creates a reference to the public variable EquipmentTypeID

        [Required] //Is Required
        [StringLength(80)] //Can only contain 80 characters in the string 
        [Display(Name = "Equipment Name")] //Changes variable name to display as Equipment Name
        public string Equipment_Name { get; set; } //Creates a public variable with the datatype string called EquipmentName

        [Required] //Is Required
        [Range(0, 1000)] //Can only contain numbers from 0-1000
        public int Availability { get; set; } //Creates a public variable with the datatype integer called Availability


        public EquipmentType EquipmentType { get; set; } //Creates a relationship as a foreign key of EquipmentType 
        public ICollection<AssetsNeeded> AssetsNeeded { get; set; } //Creates a relationship as the primary key of AssetsNeeded

    }
}
