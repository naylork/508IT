using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlus.Models
{
    public class AN
    {
        [Key] //Indicates this variable is a primary key 
        public int AN_ID { get; set; } //Creates a public variable with the datatype integer called ID 

        [Required] //Is Required
        [DataType(DataType.Currency)] //Has the datatype Currency
        [Column(TypeName = "Money")] //Column has the type Money
        [Display(Name = "Estimated Costs")] //Changes the variable name to Estimated Costs
        [Range(0.01, 100000.00, ErrorMessage = "Price must be between 0.01 and 100,000.00")] //Currency has the range 0.01 to 100000 and prints an error message if outside of the ranges.
        [RegularExpression(@"^\£?([0 - 9]{1, 3},([0 - 9]{3},)*[0 - 9]{ 3}|[0 - 9] +)(.[0 - 9][0 - 9]) ?$", ErrorMessage = "Characters are not allowed.")] //Matches UK currency input with or without commas.
        public decimal Estimated_Costs { get; set; } //Creates a public variable with the datatype Decimal called Estimated_Costs

        [DataType(DataType.Currency)] //Has the datatype Currency
        [Column(TypeName = "Money")] //Column has the type Money
        [Display(Name = "Actual Costs")] //Changes the variable name to Actual Costs
        [Range(0.01, 100000.00, ErrorMessage = "Price must be between 0.01 and 100,000.00")] //Currency has the range 0.01 to 100000 and prints an error message if outside of the ranges.
        [RegularExpression(@"^\£?([0 - 9]{1, 3},([0 - 9]{3},)*[0 - 9]{ 3}|[0 - 9] +)(.[0 - 9][0 - 9]) ?$", ErrorMessage = "Characters are not allowed.")] //Matches UK currency input with or without commas.
        public decimal? Actual_Costs { get; set; } //Creates a public variable with the datatype Decimal called Actual_Costs, which is not nullable, so a value must be entered 

        [Required] //Is Required
        [Display(Name = "Amount Needed")] //Changes the variable name to Amount Needed
        [Range(0, 1000)] //Can only contain numbers from 0-1000
        [RegularExpression(@"^[''-'\s]{0,1000}$", ErrorMessage = "Characters are not allowed.")] //Can contain spaces but the expression details that strictly numbers from 0 - 1000
        public int? Amount_Needed { get; set; } //Creates public variable with datatype Integer called Amount_Needed, which is not nullable, so a value must be entered

        public int EquipmentID { get; set; }
        public int PerformanceID { get; set; }

        //RELATIONSHIPS

        public Performance Performances { get; set; }
        public Equip Equipments { get; set; }
    }
}
