using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class EventLocation //Use the class EventLocation in the EventsPlus Models folder
    {
        [Key] //Indicates this variable is a primary key 
        public int EventLocationID { get; set; } //Creates a public variable with the datatype integer called ID 

        [Required] //Is required
        [StringLength(100)] //Can only have 100 letters in the string
        [RegularExpression(@"^[a-zA-Z''-'\s]$", ErrorMessage = "Characters are not allowed.")] //Can only use the Characters a-z in lowercase and uppercase with spaces
        [Display(Name = "Venue")] //Changes the variable name to Venue
        public string Venue { get; set; } //Creates a public variable with the datatype string called Variable

        [Required] //Is required
        [Range(0, 100000)] //Can enter any number from 0-100000
        [RegularExpression(@"^{1,100000}$", ErrorMessage = "Characters are not allowed.")]
        [Display(Name = "Capacity")]
        public int Capacity { get; set; }  //Creates a public variable with the datatype string called Capacity

        [Required] //Is required
        [StringLength(100)] //Can only have 100 letters in the string
        [Display(Name = "Location Address")] //Changes the variable name to Location Address
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,500}$", ErrorMessage = "Characters are not allowed.")] //Can only use the Characters a-z in lowercase and uppercase, with spaces, and numbers from 1-500
        public string Location_Address { get; set; }  //Creates a public variable with the datatype string called Location_Address

        public int EventID { get; set; }


        //Relationships

        public Event Events { get; set; }


    }
}
