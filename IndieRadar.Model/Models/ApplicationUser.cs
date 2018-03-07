using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IndieRadar.Model.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            DateCreated = DateTime.Now;
        }

        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime DateCreated { get; set; }

        public IList<UserRating> UserRatings { get; set; }

        public Int32 RoleId { get; set; }
    }
}