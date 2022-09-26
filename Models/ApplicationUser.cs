﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace OnlineVoting.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name="First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public IList<UserElection> UserElections { get; set; }
    }
}
