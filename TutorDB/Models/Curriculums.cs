using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TutorDB.Models
{
    public class Curriculums
    {
        [Key]
        public int CurricId { get; set; }
        public string CurricName { get; set; }
        public string CurricAuthor { get; set; }
    }
}