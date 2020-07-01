using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace ComfyPWA.Shared.Models
{
    public class AppUser : Microsoft.AspNetCore.Identity.IdentityUser
    {
        [PersonalData, Required, StringLength(40)]
        public string FirstName { get; set; }

        [PersonalData, Required, StringLength(40)]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
    }
}
