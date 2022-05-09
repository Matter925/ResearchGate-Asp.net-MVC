using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResearchGate.Models
{
    public class Papers
    {
        [Required]
        [Display(Name = "ID")]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "AuthorName")]
        public string Author { get; set; }
        [Required]
        
        [Display(Name = "ResaerchPost")]
        [AllowHtml]
        public string ResaerchPost { get; set; }
        public DateTime Post_Date { get; set; }
        //public string Comments { get; set; }
        public string UserId { get; set; }
        public int Post_like { get; set; }
        public int Post_Dislike { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Comments> comments { get; set; }
        public virtual ICollection<Participators> participators { get; set; }




    }
}