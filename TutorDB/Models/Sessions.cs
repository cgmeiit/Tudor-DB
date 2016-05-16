using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TutorDB.Models
{
    public class Sessions
    {
        [Key]
        public int SessionsId { get; set; }
        public string SessionTopic { get; set; }
        public DateTime Date {get;set;}
        //Foreign//
        public int CurricId { get; set; }
        public Curriculums Curriculum { get; set; }
        public int TutorId { get; set; }
        public Tutors Tutor { get; set; }
    }
}