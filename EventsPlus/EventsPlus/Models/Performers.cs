using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlus.Models
{
    public class Performers
    {
        [Key] //Indicates this variable is a primary key 
        public int PerformerID { get; set; } //Creates a public variable with the datatype integer called ID 

        [Required] //Is required
        [StringLength(100)] //Allow up to 100 characters
        [Display(Name = "Full Name")] //Changes the variable name to Full Name
        public string FullName { get; set; } //Creates a public variable with the datatype string called FullName

        [StringLength(11)] //Can only have 11 characters in the string
        [Phone] //Indicates this variable is a Phone number 
        [RegularExpression(@"^(07[\d]{8, 12})$", ErrorMessage = "Characters are not allowed.")] //Can only follow the expression for the entering of the phone number and any other characters are not allowed
        [Display(Name = "Contact Number")]  //Changes the variable name to Contact Number
        public int? ContactNumber { get; set; }  //Creates a public variable with the datatype string called ContactNumber, it is not nullable, meaning it must always have a value

        [StringLength(255)] //Can only have 255 characters in the string
        [EmailAddress] //Indicates this variable is an Email Address
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$", ErrorMessage = "Characters are not allowed.")] //Simple email expression that doesn't allow numbers in the domain name and doesn't allow for top level domains that are less than 2 or more than 3 letters
        [Display(Name = "Contact Email")]  //Changes the variable name to Contact Email
        public string? ContactEmail { get; set; }  //Creates a public variable with the datatype string called ContactEmail, it is not nullable, meaning it must always have a value

        public int ActTypeID { get; set; }

        //RELATIONSHIPS

        public AT ActType { get; set; }
        public ICollection<Participants> Participants { get; set; }
    }
}
