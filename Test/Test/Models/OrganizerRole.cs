using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class OrganizerRole
    {
        [Key] //Indicates this variable is a primary key 
        public int OrganizerRoleID { get; set; } //Creates a public variable with the datatype integer called ID 

        [Required] //Is required
        [StringLength(80)] //Allow up to 80 characters
        [Display(Name = "Role Name")] //Changes the variable name to Role Name
        public string RoleName { get; set; } //Creates a public variable with the datatype string called RoleName

        //RELATIONSHIPS

        public ICollection<Organizer> Organizers { get; set; }

    }
}
