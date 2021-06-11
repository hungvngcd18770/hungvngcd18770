using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ASPDevApp.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<TraineeProfile> TraineeProfiles { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<TrainerProfile> TrainerProfiles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}