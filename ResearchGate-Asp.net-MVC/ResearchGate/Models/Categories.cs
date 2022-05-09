using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ResearchGate.Models
{
    public class Categories
    {
        [Key]
        [Required]
        [Display(Name ="CategoryId")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "CategoryName")]
        public string CategoryName { get; set; }
      //  public virtual ICollection<ApplicationUser> Authors { get; set; }
    }
}