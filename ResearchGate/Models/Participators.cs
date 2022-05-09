using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResearchGate.Models
{
    public class Participators
    {
        public int Id { get; set; }
        public string userId { get; set; }
        public string Name { get; set; }
        public virtual Papers Post { get; set; }
        public int PostID { get; set; }

    }
}