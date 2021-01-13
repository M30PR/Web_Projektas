using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace Web_Projektas.Models
{
    public partial class User : IdentityUser<int>
    {
        public User()
        {
            Quotes = new HashSet<Quote>();
        }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string EMail { get; set; }
        public DateTime LastTimeDate { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Role { get; set; }

        public virtual ICollection<Quote> Quotes { get; set; }
    }
}
