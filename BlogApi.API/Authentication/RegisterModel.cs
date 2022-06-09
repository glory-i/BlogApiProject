﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.API.Authentication
{
    public class RegisterModel
    {
        [Required(ErrorMessage="USERNAME IS REQUIRED")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "EMAIL IS REQUIRED")]
        public string Email { get; set; }

        [Required(ErrorMessage = "PASSWORD IS REQUIRED")]
        public string Password { get; set; }
    }
}
