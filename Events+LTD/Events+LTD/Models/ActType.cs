﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventPlusLTD.Models
{
    public class ActType
    {
        [Key] //Indicates this variable is a primary key 
        public int GenreID { get; set; }

        [Required] //Is Required
        [StringLength(255)] //Can only have 255 characters in the string
        [Display(Name = "Act Genre")] //Changes the variable name to Act Genre
        public string Genre { get; set; } //Creates a public variable with the datatype string called Genre

        //RELATIONSHIPS
        public ICollection<Performers> Performers { get; set; }
    }
}
