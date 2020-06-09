using System;
using System.Collections.Generic;

namespace EventsApp.Models
{
    public class Event : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Seats { get; set; }
        public DateTime Time { get; set; }
        public virtual IList<ApplicationUserEvent> ApplicationUserEvents { get; set; }
    }
}
