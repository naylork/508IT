using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlus.Models
{
    public class OrgOcc
    {
        [Key] //Indicates this variable is a primary key 
        public int OrganizersOccupiedID { get; set; } //Creates a public variable with the datatype integer called ID 

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

        public int OrganizerID { get; set; }

        public int PerformanceID { get; set; }

        //RELATIONSHIPS
        public Performance Performances { get; set; }
        public Organizers Organizers { get; set; }
    }
}
