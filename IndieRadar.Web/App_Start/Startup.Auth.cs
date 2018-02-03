using System;
using System.Web.Mvc;
using IndieRadar.Model.Models;
using IndieRadar.Web.Infrastructure;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace IndieRadar.Web
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext<ISignInService>(IdentityServicesFactory.CreateSignInService);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
        }
    }

    public static class IdentityServicesFactory
    {
        public static ISignInService CreateSignInService(IdentityFactoryOptions<ISignInService> options, IOwinContext context)
        {
            return new SignInService(DependencyResolver.Current.GetService<UserManager<ApplicationUser, String>>(), context.Authentication);
        }
    }
}