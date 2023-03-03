using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using Cricket.Models;


namespace Cricket.Data
{
    public class CricketDatabase : DbContext
    {
        public CricketDatabase(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Player> players { get; set; }
        public DbSet<Match> matches { get; set; }
        public DbSet<Team> teams { get; set; }
        public DbSet<PlayerMapModel> playerMapModels { get; set; }
    }
}
