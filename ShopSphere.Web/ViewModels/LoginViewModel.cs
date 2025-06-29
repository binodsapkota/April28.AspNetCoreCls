﻿using System.ComponentModel.DataAnnotations;

namespace ShopSphere.Web.ViewModels
{
    public class LoginViewModel
    {
        [Required, EmailAddress]
        public string Username { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
