using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace IndieRadar.Web.ViewModels
{
    public class RegisterClientViewModel
    {
        [Required]
        [Remote("CheckUserName", "Account", ErrorMessage = "Имя уже используется")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Логин должен содержать от 5 до 50 символов")]     
        public String UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Пароль должен содержать минимум 6 символов", MinimumLength = 6)]
        public String Password { get; set; }

        [Required]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public String ConfirmPassword { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Имя должно содержать от 2 до 50 символов")]
        public String FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Фамилия должна содержать от 2 до 50 символов")]
        public String LastName { get; set; }

        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public String Email { get; set; }
    }
}