using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TutorDB.Models
{ 
    public class Tutors
    {
        [Key]
        public int TutorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
       

    }
}