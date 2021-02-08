using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlus.Models
{
    public class Organizers
    {
        [Key] //Indicates this variable is a primary key 
        public int OrganizerID { get; set; } //Creates a public variable with the datatype integer called ID 

        public int OrganizerInfoID { get; set; }
        public int OrganizerRoleID { get; set; }

        //RELATIONSHIPS


        public OrgInfo OrganizerInfo { get; set; }
        public OrgRole OrganizerRole { get; set; }

        public ICollection<OrgOcc> OrganizersOccupieds { get; set; }
    }
}
