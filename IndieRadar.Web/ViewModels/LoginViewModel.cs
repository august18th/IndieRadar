using System;
using System.ComponentModel.DataAnnotations;

namespace IndieRadar.Web.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Логин должен содержать от 5 до 50 символов")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}