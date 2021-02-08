﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class OrganizerInfo //Use the class OrganizerInfo in the EventsPlus Models folder
    {
        [Key] //Indicates this variable is a primary key 
        public int OrganizerInfoID { get; set; } //Creates a public variable with the datatype integer called ID 

        [Required] //Is required
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")] //Can only have 50 letters in the string and outputs an error message if more than 50 are entered
        [Display(Name = "First Name")] //Changes the variable name to First Name
        public string FirstName { get; set; } //Creates a public variable with the datatype string called FirstName

        [Required] //Is required
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")] //Can only have 50 letters in the string and outputs an error message if more than 50 are entered
        [Display(Name = "Last Name")] //Changes the variable name to Last Name
        public string LastName { get; set; } //Creates a public variable with the datatype string called LastName

        [StringLength(11)] //Can only have 11 characters in the string, like a typical phone number
        [Phone] //Indicates this variable is a phone number
        [RegularExpression(@"^(07[\d]{8, 12})$", ErrorMessage = "Characters are not allowed.")] //Can only follow the expression for the entering of the phone number and any other characters are not allowed
        [Display(Name = "Contact Number")] //Changes the variable name to Contact Number
        public int? ContactNumber { get; set; } //Creates a public variable with the datatype int called ContactNumber and is nullable, so must have a value

        [StringLength(255)] //Can only have 255 characters in the string
        [EmailAddress] //Indicates this variable is an Email Address
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$", ErrorMessage = "Characters are not allowed.")] //Simple email expression that doesn't allow numbers in the domain name and doesn't allow for top level domains that are less than 2 or more than 3 letters
        [Display(Name = "Contact Email")] //Changes the variable name to Contact Email
        public string? ContactEmail { get; set; } //Creates a public variable with the datatype string called ContactEmail and is nullable, so must have a value


        //RELATIONSHIPS

        public ICollection<Organizer> Organizers { get; set; }

    }
}