using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Projektas.ViewModel
{
    public class RegisterViewModel
    {
        [DisplayName("Username")]
        public string Username { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Password")]
        public string Password { get; set; }
    }
}
