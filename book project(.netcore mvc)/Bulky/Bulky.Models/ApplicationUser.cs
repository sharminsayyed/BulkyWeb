using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky_Models
{
    public class ApplicationUser:IdentityUser
    {
        // it extends IdentityUser 
        // application user will have default setting of identity user 
        // here we can add more columns to aspnetuser table
        // it alsa add an extra column called Discriminator
        // this is the column that will be used to identify the type of user(identity user or application user)
        [Required]
        public int Name { get; set; }

        public  string? StreeAddress { get; set; }
        public  string? City { get; set; }
        public  string? State { get; set; }
        public  string? PostalCode { get; set; }
    }
}
