using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlus.Models
{
    public class TOE
    {
        [Key] //Indicates this variable is a primary key 
        public int TypeOfEventID { get; set; } //Creates a public variable with the datatype integer called ID 
        [Required] //Is required
        [StringLength(150)] //Can only have 150 characters in the string
        [Display(Name = "Event Type")] //Changes the variable name to Event Type
        public string Event_Type { get; set; } //Creates a public variable with the datatype string called Event_Type

        //Relationships

        public ICollection<Event> Events { get; set; }
    }
}
