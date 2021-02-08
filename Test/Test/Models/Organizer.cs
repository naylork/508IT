using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class Organizer
    {

        [Key] //Indicates this variable is a primary key 
        public int OrganizerID { get; set; } //Creates a public variable with the datatype integer called ID 

        public int OrganizerInfoID { get; set; }
        public int OrganizerRoleID { get; set; }

        //RELATIONSHIPS


        public OrganizerInfo OrganizerInfo { get; set; }
        public OrganizerRole OrganizerRole { get; set; }

        public ICollection<OrganizersOccupied> OrganizersOccupieds { get; set; }

    }
}
