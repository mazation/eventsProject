using EventsApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventsApp.Data
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Event> Events { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationUserEvent> ApplicationUserEvents { get; set; }
        public DbSet<FileUpload> FileUploads { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUserEvent>().HasKey(ue => new { ue.ApplicationUserId, ue.EventId });
            builder.Entity<ApplicationUserEvent>()
                .HasOne<ApplicationUser>(ue => ue.ApplicationUser).
                WithMany(u => u.ApplicationUserEvents).
                HasForeignKey(sc => sc.ApplicationUserId);
            builder.Entity<ApplicationUserEvent>()
                .HasOne<Event>(ue => ue.Event).
                WithMany(e => e.ApplicationUserEvents).
                HasForeignKey(ue => ue.EventId);

        }
    }
}
