using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ResearchGate.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileImage { get; set; }
        public string University { get; set; }
        public string Mobile { get; set; }

        public virtual ICollection<Papers> Posts { get; set; }
      //  public virtual Categories Category { get; set; }
        public string Category { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<ResearchGate.Models.Papers> Papers { get; set; }

        public System.Data.Entity.DbSet<ResearchGate.Models.Categories> Categories { get; set; }

        // public System.Data.Entity.DbSet<ResearchGate.Models.Categories> Categories { get; set; }
        public System.Data.Entity.DbSet<ResearchGate.Models.RegisterViewModel> RegisterViewModel { get; set; }

        public System.Data.Entity.DbSet<ResearchGate.Models.Comments> Comments { get; set; }

        public System.Data.Entity.DbSet<ResearchGate.Models.Participators> Participators { get; set; }






        // public System.Data.Entity.DbSet<ResearchGate.Models.Category> Categories { get; set; }


    }
}