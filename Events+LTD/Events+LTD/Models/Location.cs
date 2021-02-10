using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventPlusLTD.Models
{
    public class Location
    {
        public int EventID { get; set; } //Creates a reference to the public variable EventID

        [Key] //Indicates this variable is a primary key 
        public int LocationID { get; set; } //Creates a public variable with the datatype integer called ID 

        [Required] //Is required
        [StringLength(100)] //Can only have 100 letters in the string
        [Display(Name = "Venue")] //Changes the variable name to Venue
        public string Venue { get; set; } //Creates a public variable with the datatype string called Variable

        [Required] //Is required
        [Range(0, 100000)] //Can enter any number from 0-100000
        [Display(Name = "Capacity")]
        public int Capacity { get; set; }  //Creates a public variable with the datatype string called Capacity

        [Required] //Is required
        [StringLength(200)] //Can only have 100 letters in the string
        [Display(Name = "Location Address")] //Changes the variable name to Location Address
        public string Location_Address { get; set; }  //Creates a public variable with the datatype string called Location_Address


        //RELATIONSHIPS
        public Event Event { get; set; } //Creates a relationship as a foreign key of Event 
    }
}
