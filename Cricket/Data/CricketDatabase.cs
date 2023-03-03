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
        public DbSet<TeamModel> teams { get; set; }
        public DbSet<PlayerTeamMap> TeamPlayerMap { get; set; }
    }
}
