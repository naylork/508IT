using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EPLTD.Models
{
    public class Performers
    {
        public int GenreID { get; set; } //Creates a reference to the public variable Genre

        [Key] //Indicates this variable is a primary key 
        public int PerformersID { get; set; } //Creates a public variable with the datatype integer called ID 

        [Required] //Is required
        [StringLength(150, ErrorMessage = "First name cannot be longer than 50 characters.")] //Can only have 50 letters in the string and outputs an error message if more than 50 are entered
        [Display(Name = "Full Name")] //Changes the variable name to Full Name
        public string FullName { get; set; } //Creates a public variable with the datatype string called FullName

        [StringLength(255)] //Can only have 255 characters in the string
        [EmailAddress] //Indicates this variable is an Email Address
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$", ErrorMessage = "Characters are not allowed.")] //Simple email expression that doesn't allow numbers in the domain name and doesn't allow for top level domains that are less than 2 or more than 3 letters
        [Display(Name = "Contact Email")] //Changes the variable name to Contact Email
        public string ContactEmail { get; set; } //Creates a public variable with the datatype string called ContactEmail 

        [Display(Name = "Contact Number")] //Changes the variable name to Contact Number
        public int ContactNumber { get; set; } //Creates a public variable with the datatype int called ContactNumber 

        //RELATIONSHIPS

        public ActType ActType { get; set; } //Creates a relationship as a foreign key of ActType 
        public ICollection<Participants> Participants { get; set; } //Creates a relationship as the primary key of Participants


    }
}
