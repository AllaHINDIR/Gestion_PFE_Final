using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_PFE.Models
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsAdmin { get; set; }
    }
}
