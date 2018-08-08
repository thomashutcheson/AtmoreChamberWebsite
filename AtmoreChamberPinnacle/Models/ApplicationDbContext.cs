using Microsoft.AspNet.Identity.EntityFramework;

namespace AtmoreChamber.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //public System.Data.Entity.DbSet<AtmoreChamber.Model.MemberDirectory> MemberDirectories { get; set; }

        public System.Data.Entity.DbSet<Members> Members { get; set; }

        public System.Data.Entity.DbSet<OnlineStore.Product> Products { get; set; }

        public System.Data.Entity.DbSet<Event> Events { get; set; }

        //public System.Data.Entity.DbSet<CalendarEventGroup> EventGroups { get; set; }

    }
}