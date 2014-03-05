using System.Data.Entity;
using HouseHoldApp.Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HouseHoldApp.RepositoryEF
{
    public class HhContext : IdentityDbContext<User>
    {
        public HhContext(): base ("HouseHoldDb")
        {

        }

        public DbSet<HouseHold> HouseHolds { get; set; }
        public DbSet<HouseHoldMember> HouseHoldMembers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HouseHoldMember>().ToTable("HouseHoldMembers");
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }
    }
}
