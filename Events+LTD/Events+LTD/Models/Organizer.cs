using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventPlusLTD.Models
{
    public class Organizer
    {
        [Key] //Indicates this variable is a primary key 
        public int OrganizerID { get; set; } //Creates a public variable with the datatype integer called ID 
        public int OrganizerRoleID { get; set; } //Creates a reference to the public variable OrganizerRoleID
        public int OrganizerInfoID { get; set; } //Creates a reference to the public variable OrganizerInfoID

        //RELATIONSHIPS
        public OrganizerInfo OrganizerInfo { get; set; } //Creates a relationship as a foreign key of OrganizerInfo 
        public OrganizerRole OrganizerRole { get; set; } //Creates a relationship as a foreign key of OrganizerRole 
        public ICollection<OrganizersOccupied> OrganizersOccupied { get; set; } //Creates a relationship as the primary key of OrganizersOccupied

    }
}
