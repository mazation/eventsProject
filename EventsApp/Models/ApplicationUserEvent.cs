namespace EventsApp.Models
{
    public class ApplicationUserEvent
    {
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public int EventId { get; set; }
        public virtual Event Event { get; set; }

    }
}
