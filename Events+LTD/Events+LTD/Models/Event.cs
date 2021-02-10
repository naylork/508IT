using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventPlusLTD.Models
{
    public class Event
    {
        [Key] //Indicates this variable is a primary key 
        public int EventID { get; set; } //Creates a public variable with the datatype integer called ID 

        [Required] //Is required
        [StringLength(100)] //Max character length in the string is 50
        [DisplayFormat(NullDisplayText = "Unnamed Event")] //If no value is entered, by default sets the value to 'Unnamed Event'
        [Display(Name = "Event Name")] //Changes the variable name to Event Name
        public string EventName { get; set; } //Creates a public variable with the datatype string called EventName

        [StringLength(250)] //Max character length in the string is 200
        [DisplayFormat(NullDisplayText = "Enter Text Here")] //If no value is entered, by default sets the value to 'Enter Text Here'
        public string EventDescription { get; set; } //Creates a public variable with the datatype string called EventDescription

        [StringLength(50)] //Max character length in the string is 200
        public string EventType { get; set; }

        [DataType(DataType.Date)] //Has the datatype Date
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)] //Follows the format dd/MM/yyyy
        [Display(Name = "Start Date")] //Changes the variable name to Start Date
        public DateTime Start_Date { get; set; } //Creates a public variable with the datatype DateTime called StartDate

        [DataType(DataType.Date)] //Has the datatype Date
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)] //Follows the format dd/MM/yyyy
        [Display(Name = "End Date")] //Changes the variable name to End Date
        public DateTime? End_Date { get; set; } //Creates a public variable with the datatype DateTime called EndDate, which is not nullable, so a value doesnt have to be entered


        //RELATIONSHIPS
        public ICollection<Performance> Performance { get; set; } //Creates a relationship as the primary key of Performance
        public ICollection<Customer> Customer { get; set; } //Creates a relationship as the primary key of Customer
        public ICollection<Location> Location { get; set; } //Creates a relationship as the primary key of Location

    }
}
