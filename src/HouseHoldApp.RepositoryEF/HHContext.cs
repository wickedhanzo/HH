using System.Data.Entity;
using HouseHoldApp.Domain;

namespace HouseHoldApp.RepositoryEF
{
    public class HhContext : DbContext
    {
        public DbSet<User> Users { get; set; } 
    }
}
