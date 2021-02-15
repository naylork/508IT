using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPLTD.Models
{
    public class Participants
    {
        [Key]
        public int ParticipantID { get; set; } //Creates a public variable with the datatype integer called ID
        public int PerformanceID { get; set; } //Creates a reference to the public variable PerformanceID
        public int PerformersID { get; set; } //Creates a reference to the public variable PerformersID

        [DataType(DataType.Time)] //Has the datatype Time
        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)] //The display format follows the set format of hh and mm
        [Display(Name = "Time slot Start")] //Changes the variable name to Start Time
        public DateTime TimeSlotStart { get; set; } //Creates a public variable with the datatype DateTime called StartTime

        [DataType(DataType.Time)] //Has the datatype Time
        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)] //The display format follows the set format of hh and mm
        [Display(Name = "Time slot End")] //Changes the variable name to End Time
        public DateTime? TimeSlotEnd { get; set; } //Creates a public variable with the datatype DateTime called EndTime, which is not nullable, so a value must be entered 

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

        //RELATIONSHIPS

        public Performance Performance { get; set; } //Creates a relationship as a foreign key of Performance 
        public Performers Performers { get; set; } //Creates a relationship as a foreign key of Perforers 

    }
}
