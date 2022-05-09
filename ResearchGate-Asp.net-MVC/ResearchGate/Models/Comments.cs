using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ResearchGate.Models
{
    public class Comments
    {
        public int Id { get; set; }
        [Display(Name = "Comment")]
        public string Comment { get; set; }
        public string Name { get; set; }
        public string userId { get; set; }
        public virtual Papers Post { get; set; }
        public int PostID { get; set; }
    }
}