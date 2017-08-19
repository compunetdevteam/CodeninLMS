using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace CodeninWebApi.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class CodenimDbContext : IdentityDbContext<ApplicationUser>
    {
        public CodenimDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public static CodenimDbContext Create()
        {
            return new CodenimDbContext();
        }

        public System.Data.Entity.DbSet<CodeninModel.CourseCategory> CourseCategories { get; set; }

        public System.Data.Entity.DbSet<CodeninModel.Course> Courses { get; set; }

        public System.Data.Entity.DbSet<CodeninModel.Module> Modules { get; set; }

        public System.Data.Entity.DbSet<CodeninModel.Topic> Topics { get; set; }
    }
}