using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IndieRadar.Model.Models
{
    public class Role : IdentityRole
    {
        public IList<UserRole> UserRoles { get; set; }
    }
}