using System.Data.Entity;
using HouseHoldApp.Domain;
using HouseHoldApp.Domain.Entities;

namespace HouseHoldApp.RepositoryEF
{
    public class HhContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<HouseHold> HouseHolds { get; set; }
        public DbSet<HouseHoldMember> HouseHoldMembers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HouseHoldMember>().ToTable("HouseHoldMembers");
        }
    }
}
