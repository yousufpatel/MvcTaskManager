using Microsoft.EntityFrameworkCore;

namespace MvcTaskManager.DomainModels
{
    public class MvcTaskManagerDbContext : DbContext
    {
        public MvcTaskManagerDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<ClientLocation> ClientLocations { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

         public DbSet<Country> Countries { get; set; }

        public DbSet<Skill> Skills { get; set; }
    }
}
