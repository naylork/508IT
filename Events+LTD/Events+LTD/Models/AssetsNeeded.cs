using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventPlusLTD.Models
{
    public class AssetsNeeded
    {
        [Key] //Indicates this variable is a primary key 
        public int AssetsNeededID { get; set; } //Creates a public variable with the datatype integer called ID 
        public int PerformanceID { get; set; } //Creates a reference to the public variable PerformanceID
        public int EquipmentID { get; set; } //Creates a reference to the public variable EquipmentID

        [Required] //Is Required
        [DataType(DataType.Currency)] //Has the datatype Currency
        [Column(TypeName = "Money")] //Column has the type Money
        [Display(Name = "Estimated Costs")] //Changes the variable name to Estimated Costs
        [Range(0.01, 100000.00, ErrorMessage = "Price must be between 0.01 and 100,000.00")] //Currency has the range 0.01 to 100000 and prints an error message if outside of the ranges.
        public decimal EstimatedCosts { get; set; } //Creates a public variable with the datatype Decimal called EstimatedCosts

        [Required] //Is Required
        [DataType(DataType.Currency)] //Has the datatype Currency
        [Column(TypeName = "Money")] //Column has the type Money
        [Display(Name = "Actual Costs")] //Changes the variable name to Estimated Costs
        [Range(0.01, 100000.00, ErrorMessage = "Price must be between 0.01 and 100,000.00")] //Currency has the range 0.01 to 100000 and prints an error message if outside of the ranges.
        public decimal? ActualCosts { get; set; } //Creates a public variable with the datatype Decimal called ActualCosts

        [Required] //Is Required
        [Display(Name = "Amount Needed")] //Changes the variable name to Amount Needed
        [Range(0, 1000)] //Can only contain numbers from 0-1000
        public int AmountNeeded { get; set; } //Creates public variable with datatype Integer called AmountNeeded, which is nullable, so a value doesnt have to be entered


        //RELATIONSHIPS
        public Performance Performance { get; set; } //Creates a relationship as a foreign key of Performance 
        public Equipment Equipment { get; set; } //Creates a relationship as a foreign key of Equipment 

    }
}
