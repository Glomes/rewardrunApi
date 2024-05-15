using Microsoft.EntityFrameworkCore;
using RewardRunAPI.Model;

namespace RewardRunAPI.Connections
{
    public class ConnectionContext :DbContext

    {

        public ConnectionContext(DbContextOptions<ConnectionContext> options) : base(options) { }

        public DbSet<Tasks> tasks { get; set; }

        public DbSet<Rewards> rewards { get; set; }
        public DbSet<Users> users { get; set; }
        public DbSet<Admin> admins { get; set; }
        



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("Server=localhost;User Id=rewardrun;Password=@WSXcde3;Database=rewardrun");

    }
}
