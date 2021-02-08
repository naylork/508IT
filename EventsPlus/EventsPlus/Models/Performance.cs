using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlus.Models
{
    public class Performance
    {
        [Key] //Indicates this variable is a primary key 
        public int PerformanceID { get; set; } //Creates a public variable with the datatype integer called ID 

        [Required] //Is required
        [StringLength(50)] //Allow up to 50 characters
        [DisplayFormat(NullDisplayText = "Yet to be declared")] //Sets a default value for the variable if no text is entered as 'yet to be declared'
        [Display(Name = "Performance Name")] //Changes the variable name to Performance Name
        public string Performance_Name { get; set; } //Creates a public variable with the datatype string called Performance_Name

        [Required] //Is required
        [StringLength(50)] //Allow up to 50 characters
        [DisplayFormat(NullDisplayText = "Yet to be declared")] //Sets a default value for the variable if no text is entered as 'yet to be declared'
        [Display(Name = "Performance Location")] //Changes the variable name to Performance Location
        public string Performance_Location { get; set; } //Creates a public variable with the datatype string called Performance_Location

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

        public int EventID { get; set; }


        //RELATIONSHIPS

        public Event Events { get; set; }
        public ICollection<OrgOcc> OrganizersOccupieds { get; set; }
        public ICollection<Participants> Participants { get; set; }
        public ICollection<AN> AssetsNeeded { get; set; }

    }
}
