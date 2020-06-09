using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace EventsApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual IList<ApplicationUserEvent> ApplicationUserEvents { get; set; }

    }
}
