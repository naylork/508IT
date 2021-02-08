using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlus.Models
{
    public class Event
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int EventID { get; set; } //Creates a public variable with the datatype integer called ID 

        [Required] //Is required
        [StringLength(50)] //Max character length in the string is 50
        [DisplayFormat(NullDisplayText = "Unnamed Event")] //If no value is entered, by default sets the value to 'Unnamed Event'
        [Display(Name = "Event Name")] //Changes the variable name to Event Name
        public string Event_Name { get; set; } //Creates a public variable with the datatype string called Event_Name

        [StringLength(200)] //Max character length in the string is 200
        [DisplayFormat(NullDisplayText = "Enter Text Here")] //If no value is entered, by default sets the value to 'Enter Text Here'
        public string Event_Description { get; set; } //Creates a public variable with the datatype string called Event_Description

        [DataType(DataType.Date)] //Has the datatype Date
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)] //Follows the format dd/MM/yyyy
        [Display(Name = "Start Date")] //Changes the variable name to Start Date
        public DateTime Start_Date { get; set; } //Creates a public variable with the datatype DateTime called Start_Date

        [DataType(DataType.Date)] //Has the datatype Date
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)] //Follows the format dd/MM/yyyy
        [Display(Name = "End Date")] //Changes the variable name to End Date
        public DateTime? End_Date { get; set; } //Creates a public variable with the datatype DateTime called End_Date, which is not nullable, so a value must be entered 

        [DataType(DataType.Time)] //Has the datatype Time
        [DisplayFormat(DataFormatString = "{0:hh-mm}", ApplyFormatInEditMode = true)] //The display format follows the set format of hh and mm
        //[RegularExpression(@"^((([0]?[1-9]|1[0-2])(:|\.)[0-5][0-9]((:|\.)[0-5][0-9])?( )?(AM|am|aM|Am|PM|pm|pM|Pm))|(([0]?[0-9]|1[0-9]|2[0-3])(:|\.)[0-5][0-9]((:|\.)[0-5][0-9])?))$", ErrorMessage = "Characters are not allowed.")] //Matches times seperated by either : or . will match a 24 hour time, or a 12 hour time with AM or PM specified. Allows 0-59 minutes, and 0-59 seconds. Seconds are not required.
        [Display(Name = "Start Time")] //Changes the variable name to Start Time
        public DateTime StartTime { get; set; } //Creates a public variable with the datatype DateTime called StartTime

        [DataType(DataType.Time)] //Has the datatype Time
        [DisplayFormat(DataFormatString = "{0:hh-mm}", ApplyFormatInEditMode = true)] //The display format follows the set format of hh and mm
        //[RegularExpression(@"^((([0]?[1-9]|1[0-2])(:|\.)[0-5][0-9]((:|\.)[0-5][0-9])?( )?(AM|am|aM|Am|PM|pm|pM|Pm))|(([0]?[0-9]|1[0-9]|2[0-3])(:|\.)[0-5][0-9]((:|\.)[0-5][0-9])?))$", ErrorMessage = "Characters are not allowed.")] //Matches times seperated by either : or . will match a 24 hour time, or a 12 hour time with AM or PM specified. Allows 0-59 minutes, and 0-59 seconds. Seconds are not required.
        [Display(Name = "End Time")] //Changes the variable name to End Time
        public DateTime? EndTime { get; set; } //Creates a public variable with the datatype DateTime called EndTime, which is not nullable, so a value must be entered 


        public int TypeOfEventID { get; set; }


        //RELATIONSHIPS

        public TOE TypeOfEvent { get; set; }
        public ICollection<Cust> Customers { get; set; }
        public ICollection<EventLoc> EventLocations { get; set; }
        public ICollection<Performance> Performances { get; set; }

    }
}
