﻿using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Areas.Admin.Models
{
    public class UserEnter
    {
        [Required(ErrorMessage = "Поле не может быть пустым!")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Email должен содержать от 8 до 30 символов")]
        [EmailAddress]
        public string Login { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым!")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Пароль должен содержать от 8 до 30 символов")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
