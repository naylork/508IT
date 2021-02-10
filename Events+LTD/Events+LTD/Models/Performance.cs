using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventPlusLTD.Models
{
    public class Performance
    {
        [Key]
        public int PerformanceID { get; set; } //Creates a public variable with the datatype integer called ID 
        public int EventID { get; set; } //Creates a reference to the public variable EventID
        public string PerformanceName { get; set; } //Creates a reference to the public variable PerformanceNameID

        [DataType(DataType.Time)] //Has the datatype Time
        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)] //The display format follows the set format of hh and mm
        [Display(Name = "Time slot Start")] //Changes the variable name to Start Time
        public DateTime TimeSlotStart { get; set; } //Creates a public variable with the datatype DateTime called StartTime

        [DataType(DataType.Time)] //Has the datatype Time
        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)] //The display format follows the set format of hh and mm
        [Display(Name = "Time slot End")] //Changes the variable name to End Time
        public DateTime? TimeSlotEnd { get; set; } //Creates a public variable with the datatype DateTime called EndTime, which is not nullable, so a value must be entered 

        //RELATIONSHIPS

        public Event Event { get; set; } //Creates a relationship as a foreign key of Performance 
        public ICollection<Participants> Participants { get; set; } //Creates a relationship as the primary key of Participants
        public ICollection<OrganizersOccupied> OrganizersOccupied { get; set; } //Creates a relationship as the primary key of OrganizersOccupied
        public ICollection<AssetsNeeded> AssetsNeeded { get; set; } //Creates a relationship as the primary key of AssetsNeeded


    }
}
