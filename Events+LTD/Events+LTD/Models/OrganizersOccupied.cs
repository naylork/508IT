using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventPlusLTD.Models
{
    public class OrganizersOccupied
    {
        public int PerformanceID { get; set; } //Creates a reference to the public variable PerformanceID
        public int OrganizerID { get; set; } //Creates a reference to the public variable OrganizerID

        [Key] //Indicates this variable is a primary key 
        public int OrganizersOccupiedID { get; set; } //Creates a public variable with the datatype integer called ID 

        [DataType(DataType.Time)] //Has the datatype Time
        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)] //The display format follows the set format of hh and mm
        [Display(Name = "Start Time")] //Changes the variable name to Start Time
        public DateTime TimeSlotStart { get; set; } //Creates a public variable with the datatype DateTime called StartTime

        [DataType(DataType.Time)] //Has the datatype Time
        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)] //The display format follows the set format of hh and mm
        [Display(Name = "End Time")] //Changes the variable name to End Time
        public DateTime? TimeSlotEnd { get; set; } //Creates a public variable with the datatype DateTime called EndTime, which is not nullable, so a value must be entered 

        //RELATIONSHIPS

        public Performance Performance { get; set; } //Creates a relationship as a foreign key of Performance 
        public Organizer Organizer { get; set; } //Creates a relationship as a foreign key of Organizer 

    }
}
