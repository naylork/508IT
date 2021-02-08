using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlus.Models
{
    public class Participants
    {
        [Key] //Indicates this variable is a primary key 
        public int ParticipantID { get; set; } //Creates a public variable with the datatype integer called ID 

        [DataType(DataType.Time)] //Has the datatype Time
        [DisplayFormat(DataFormatString = "{0:hh-mm}", ApplyFormatInEditMode = true)] //The display format follows the set format of hh and mm
        [RegularExpression(@"^((([0]?[1-9]|1[0-2])(:|\.)[0-5][0-9]((:|\.)[0-5][0-9])?( )?(AM|am|aM|Am|PM|pm|pM|Pm))|(([0]?[0-9]|1[0-9]|2[0-3])(:|\.)[0-5][0-9]((:|\.)[0-5][0-9])?))$", ErrorMessage = "Characters are not allowed.")] //Matches times seperated by either : or . will match a 24 hour time, or a 12 hour time with AM or PM specified. Allows 0-59 minutes, and 0-59 seconds. Seconds are not required.
        [Display(Name = "Start Time")] //Changes the variable name to Start Time
        public DateTime StartTime { get; set; } //Creates a public variable with the datatype DateTime called StartTime

        [DataType(DataType.Time)] //Has the datatype Time
        [DisplayFormat(DataFormatString = "{0:hh-mm}", ApplyFormatInEditMode = true)] //The display format follows the set format of hh and mm
        [RegularExpression(@"^((([0]?[1-9]|1[0-2])(:|\.)[0-5][0-9]((:|\.)[0-5][0-9])?( )?(AM|am|aM|Am|PM|pm|pM|Pm))|(([0]?[0-9]|1[0-9]|2[0-3])(:|\.)[0-5][0-9]((:|\.)[0-5][0-9])?))$", ErrorMessage = "Characters are not allowed.")] //Matches times seperated by either : or . will match a 24 hour time, or a 12 hour time with AM or PM specified. Allows 0-59 minutes, and 0-59 seconds. Seconds are not required.
        [Display(Name = "End Time")] //Changes the variable name to End Time
        public DateTime? EndTime { get; set; } //Creates a public variable with the datatype DateTime called EndTime, which is not nullable, so a value must be entered 

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

        public int PerformanceID { get; set; }
        public int PerformerID { get; set; }

        //RELATIONSHIPS

        public Performance Performances { get; set; }
        public Performers Performers { get; set; }
    }
}
