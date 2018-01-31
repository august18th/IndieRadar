using System;

namespace IndieRadar.Web.ViewModels
{
    public class RegisterClientViewModel
    {
        public String Password { get; set; }
        public String UserName { get; set; }
        public String ConfirmPassword { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
    }
}