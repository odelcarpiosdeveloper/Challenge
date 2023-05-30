using Microsoft.EntityFrameworkCore;
using System.Security;
using WebApiChallengeCQRS.Models;

namespace WebApiChallengeCQRS.Data
{
    public class DbContextClass : DbContext
    {
        protected readonly IConfiguration Configuration;
        
        public DbContextClass(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("PermissionsDb"));
        }

        public DbSet<Permissions> Permissions => Set<Permissions>();
        public DbSet<PermissionType> PermissionType => Set<PermissionType>();
    }
}
