﻿using Microsoft.AspNetCore.Identity;

namespace MyFirstMvcApp.Model
{
    public class ApplicationUser:IdentityUser
    {
        public  string FullName { get; set; }
    }
}
