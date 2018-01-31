using System;
using IndieRadar.Model.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace IndieRadar.Web.Infrastructure
{
    public class SignInService : SignInManager<ApplicationUser, String>, ISignInService
    {
        public SignInService(UserManager<ApplicationUser, String> userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }
    }
}